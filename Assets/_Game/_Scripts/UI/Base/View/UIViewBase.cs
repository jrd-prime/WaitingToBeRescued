using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums.States;
using R3;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class UIViewBase : MonoBehaviour, IUIView
    {
        [SerializeField] public EGameState viewForEGameState = EGameState.NotSet;


        protected readonly CompositeDisposable Disposables = new();


        protected readonly Dictionary<Enum, SubViewBase> subViewsCache = new();

        public TemplateContainer GetTemplateContainer(Enum subState)
        {
            return subViewsCache[subState].GetTemplate();
        }

        public abstract void Initialize();
    }
}
