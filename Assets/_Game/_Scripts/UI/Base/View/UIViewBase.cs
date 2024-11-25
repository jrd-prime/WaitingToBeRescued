using System;
using System.Collections.Generic;
using _Game._Scripts.Framework.Data;
using _Game._Scripts.Framework.Data.Enums.States;
using R3;
using UnityEngine;

namespace _Game._Scripts.UI.Base.View
{
    public abstract class UIViewBase : MonoBehaviour, IUIView
    {
        [SerializeField] public EGameState viewForEGameState = EGameState.NotSet;

        protected readonly Dictionary<Enum, JSubViewBase> SubViewsCache = new();
        protected readonly CompositeDisposable Disposables = new();

        public JSubViewBase GetSubView(Enum subState)
        {
            if (!SubViewsCache.TryGetValue(subState, out var subViewBase))
                throw new KeyNotFoundException($"SubView not found in cache for: {subState}");
            return subViewBase;
        }

        public SubViewDto GetSubViewDto(Enum subState)
        {
            var subView = GetSubView(subState);

            return new SubViewDto
            {
                InSafeZone = subView.inSafeZone,
                Template = subView.GetTemplate()
            };
        }
    }
}
