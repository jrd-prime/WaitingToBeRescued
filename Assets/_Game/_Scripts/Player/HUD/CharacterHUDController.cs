using System;
using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Manager.JCamera;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.Framework.Interact.Character.Processors
{
    public class CharacterHUDController : MonoBehaviour
    {
        private ICameraManager _cameraManager;
        [RequiredField, SerializeField] private string startPointName;
        [RequiredField, SerializeField] private string endPointName;
        private VisualElement startPoint;
        private VisualElement endPoint;
        private Vector2 starttPosition;
        private Vector2 endPosition;
        private VisualElement go;
        private VisualElement icon;
        private Label lab;
        private Vector2 defStartPosition;
        private Vector2 defEndPosition;


        [Inject]
        private void Construct(ICameraManager cameraManager)
        {
            _cameraManager = cameraManager;
        }

        private void Awake()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;

            startPoint = root.Q<VisualElement>(startPointName);
            endPoint = root.Q<VisualElement>(endPointName);
            go = root.Q<VisualElement>("go");

            icon = root.Q<VisualElement>("icon");
            lab = root.Q<Label>("label");

            startPoint.RegisterCallback<GeometryChangedEvent>(SetStartPoint);
            endPoint.RegisterCallback<GeometryChangedEvent>(SetEndPoint);
        }

        private void SetStartPoint(GeometryChangedEvent evt)
        {
            starttPosition = startPoint.worldBound.center;
            defStartPosition = starttPosition;
            Debug.LogWarning($"startPoint: {starttPosition}");

            startPoint.UnregisterCallback<GeometryChangedEvent>(SetStartPoint);
        }

        private void SetEndPoint(GeometryChangedEvent evt)
        {
            endPosition = endPoint.worldBound.center;
            defEndPosition = endPosition;
            Debug.LogWarning($" endPoint: {endPosition}");
            endPoint.UnregisterCallback<GeometryChangedEvent>(SetEndPoint);
        }

        public void NewObjToBackpack(Sprite sprite, string name, float count)
        {
            icon.style.backgroundImage = new StyleBackground(sprite);
            lab.text = $"{name} x {count}";
            go.style.display = DisplayStyle.Flex;


            Anim();
        }


        private void Anim()
        {
            // Сохраняем начальные позиции
            Vector2 initialPosition = new Vector2(go.style.left.value.value, go.style.top.value.value);
            Vector2 initialScale = go.resolvedStyle.scale.value;

            // Получаем размеры элемента
            float elementWidth = go.resolvedStyle.width;
            float elementHeight = go.resolvedStyle.height;

            // Устанавливаем начальную позицию
            go.style.left = starttPosition.x - elementWidth / 2; // Начало анимации, сдвигаем влево на половину ширины
            go.style.top = starttPosition.y - elementHeight / 2; // Начало анимации, сдвигаем вверх на половину высоты

            // Определяем контрольные точки для кривой
            Vector2 controlPoint1 = starttPosition + new Vector2(0, -300); // Резкий подъем вверх
            Vector2 controlPoint2 = endPosition + new Vector2(0, -100); // Плавный спуск вниз

            // Время анимации
            float duration = 2f;

            // Анимация перемещения
            DOTween.To(
                    () => 0f, // Начальное значение параметра t
                    t =>
                    {
                        // Интерполяция через кубическую кривую Безье
                        Vector2 currentPos = CalculateCubicBezierPoint(t, starttPosition, controlPoint1, controlPoint2,
                            endPosition);

                        // Сдвигаем конечную позицию на половину ширины и высоты элемента
                        go.style.left = currentPos.x - elementWidth / 2;
                        go.style.top = currentPos.y - elementHeight / 2;
                    },
                    1f, // Конечное значение параметра t (t=1)
                    duration // Длительность анимации
                )
                .SetEase(Ease.InQuad) // Ускорение к концу
                .OnKill(() =>
                    ResetPosition(initialPosition,
                        initialScale)); // Сбрасываем позицию и масштаб после завершения анимации

            // Анимация изменения масштаба
            DOTween.To(
                    () => go.resolvedStyle.scale.value.x, // Начальный масштаб по оси X (и Y, так как X и Y одинаковы)
                    scale =>
                    {
                        go.style.scale = new StyleScale(new Vector3(scale, scale, 1)); // Применяем новый масштаб
                    },
                    0.2f, // Конечный масштаб
                    duration // Длительность анимации
                )
                .SetEase(Ease.InQuad); // Ускорение к концу
        }

        private void ResetPosition(Vector2 initialPosition, Vector2 initialScale)
        {
            // Сбросить позицию и масштаб элемента
            go.style.left = initialPosition.x;
            go.style.top = initialPosition.y;
            go.style.scale = new StyleScale(new Vector3(initialScale.x, initialScale.y, 1));
        }

        private Vector2 CalculateCubicBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            // Формула кубической кривой Безье: 
            // B(t) = (1-t)^3 * P0 + 3*(1-t)^2*t*P1 + 3*(1-t)*t^2*P2 + t^3*P3
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            return (uuu * p0) + (3 * uu * t * p1) + (3 * u * tt * p2) + (ttt * p3);
        }


        private void Start()
        {
        }
    }
}
