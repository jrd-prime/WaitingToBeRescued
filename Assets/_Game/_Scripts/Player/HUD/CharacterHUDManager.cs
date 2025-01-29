using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO.Obj.InGame._Base;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.GameStates.Gameplay.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.Player.HUD
{
    [RequireComponent(typeof(UIDocument))]
    public class CharacterHUDManager : MonoBehaviour
    {
        [RequiredField, SerializeField] private string startPointName;
        [RequiredField, SerializeField] private string endPointName;
        [RequiredField, SerializeField] private VisualTreeAsset itemTemplate;
        [SerializeField] private Vector2 itemTemplateWidthAndHeight;

        private const int ItemTemplatesPoolCount = 10;
        private const float Duration = 2f;
        private const float FinalScale = 0.2f;
        private const string ItemTemplateContainerNameId = "go";
        private const string ItemTemplateIconNameId = "icon";
        private const string ItemTemplateLabelNameId = "label";

        private readonly Vector2 _point1Offset = new(0, -300f);
        private readonly Vector2 _point2Offset = new(0, -100f);


        private VisualElement _startPoint;
        private VisualElement _endPoint;
        private Vector2 _startPosition;
        private Vector2 _endPosition;

        private readonly Queue<VisualElement> _itemTemplateQueue = new();
        private float _elementWidth;
        private float _elementHeight;
        private IGameplayModel _gameplayModel;

        [Inject]
        private void Construct(IGameplayModel gameplayModel)
        {
            _gameplayModel = gameplayModel;
        }

        private void Awake()
        {
            if (itemTemplateWidthAndHeight == Vector2.zero)
                throw new NullReferenceException("itemTemplateWidthAndHeight not set!");

            _elementWidth = itemTemplateWidthAndHeight.x;
            _elementHeight = itemTemplateWidthAndHeight.y;

            var root = GetComponent<UIDocument>().rootVisualElement;

            _startPoint = root.Q<VisualElement>(startPointName);
            _endPoint = root.Q<VisualElement>(endPointName);

            _startPoint.RegisterCallback<GeometryChangedEvent>(SetStartPoint);
            _endPoint.RegisterCallback<GeometryChangedEvent>(SetEndPoint);
            InitItemTemplates(root);
        }


        private void SetStartPoint(GeometryChangedEvent evt)
        {
            _startPosition = _startPoint.worldBound.center;
            _startPoint.UnregisterCallback<GeometryChangedEvent>(SetStartPoint);
        }

        private void SetEndPoint(GeometryChangedEvent evt)
        {
            _endPosition = _endPoint.worldBound.center;
            _endPoint.UnregisterCallback<GeometryChangedEvent>(SetEndPoint);
        }

        private void AnimateElement(VisualElement element)
        {
            element.style.left = _startPosition.x - _elementWidth / 2;
            element.style.top = _startPosition.y - _elementHeight / 2;
            element.style.scale = new StyleScale(Vector3.one);

            Vector2 p1 = _startPosition + _point1Offset;
            Vector2 p2 = _endPosition + _point2Offset;

            var sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(
                    () => 0f,
                    t =>
                    {
                        var currentPos = Formulas.CalculateCubicBezierPoint(t, _startPosition, p1, p2, _endPosition);
                        element.style.left = currentPos.x - _elementWidth / 2;
                        element.style.top = currentPos.y - _elementHeight / 2;
                    },
                    1f,
                    Duration
                )
                .SetEase(Ease.InQuad));

            sequence.Join(DOTween.To(
                    () => element.resolvedStyle.scale.value.x,
                    scale => element.style.scale = new StyleScale(new Vector3(scale, scale, 1)),
                    FinalScale,
                    Duration
                )
                .SetEase(Ease.InQuad));

            sequence.OnKill(() => OnAnimationComplete(element));
        }

        private void InitItemTemplates(VisualElement root)
        {
            for (var i = 0; i < ItemTemplatesPoolCount; i++)
            {
                var itemTemplateInstance = itemTemplate.Instantiate();
                root.Add(itemTemplateInstance);
                _itemTemplateQueue.Enqueue(itemTemplateInstance.Q<VisualElement>(ItemTemplateContainerNameId));
            }
        }

        private VisualElement PrepareItemTemplate(Sprite sprite, string itemName, float count)
        {
            var container = _itemTemplateQueue.Dequeue();
            var icon = container.Q<VisualElement>(ItemTemplateIconNameId);
            var lab = container.Q<Label>(ItemTemplateLabelNameId);

            container.style.display = DisplayStyle.Flex;

            icon.style.backgroundImage = new StyleBackground(sprite);
            lab.text = count > 0 ? $"+{count}" : $"-{count}";

            return container;
        }


        private void OnAnimationComplete(VisualElement go)
        {
            ResetElement(go);
            ShakeBackpackButton();
        }

        private void ShakeBackpackButton()
        {
            _gameplayModel.ShakeBackpack();
        }

        private void ResetElement(VisualElement go)
        {
            go.style.display = DisplayStyle.None;
            go.style.left = 0;
            go.style.top = 0;
            go.style.scale = new StyleScale(Vector3.one);

            _itemTemplateQueue.Enqueue(go);
        }

        public async void NewObjToBackpackAsync(IDictionary<LootableItemSOBase, float> items)
        {
            foreach (var (key, value) in items)
            {
                var sprite = key.icon;
                var itemName = key.name;

                var element = PrepareItemTemplate(sprite, itemName, value);

                AnimateElement(element);
                await UniTask.Delay(500);
            }
        }
    }
}
