using System;
using _Game._Scripts.Framework.Helpers;
using _Game._Scripts.Framework.Helpers.Attributes;
using _Game._Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using VContainer;

namespace _Game._Scripts.NewUI.Menus.Main
{
    public class ViewBase : MonoBehaviour
    {
        [SerializeField] public GameStateType viewForGameStateType = GameStateType.NotSet;

        [RequiredField, SerializeField] protected VisualTreeAsset viewTemplate;
        private TemplateContainer template;

        private void Awake()
        {
            Debug.Log("Awake ViewBase");
            if (viewForGameStateType == GameStateType.NotSet)
                throw new Exception("GameStateType for view is not set. " + name);
            if (viewTemplate == null) throw new NullReferenceException("ViewTemplate is null. " + name);
            template = viewTemplate.Instantiate();
        }

        private void Start()
        {
            Debug.Log("Start ViewBase");
        }

        public TemplateContainer GetTemplateContainer()
        {
            return template;
        }
    }

    public class CustomView<T> : ViewBase where T : IUINewViewModel
    {
        protected T ViewModel { get; private set; }

        [Inject]
        private void Construct(T viewModel)
        {
            Debug.Log("CustomView Construct " + name);
            ViewModel = viewModel;
        }
    }
}
