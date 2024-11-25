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
            if (SubViewsCache.Count != Enum.GetNames(subState.GetType()).Length)
            {
                Debug.LogError("SubViewsCache.Count != Enum.GetNames(subState.GetType()).Length");
            }

            foreach (var q in SubViewsCache)
            {
                Debug.LogWarning(q);
            }


            if (!SubViewsCache.ContainsKey(subState))
            {
                throw new KeyNotFoundException("SubView not found in cache. Creating new one: " + subState);
            }

            if (!SubViewsCache.TryGetValue(subState, out var subViewBase))
                throw new KeyNotFoundException($"SubView not found in cache for: {subState}");

            Debug.LogWarning($"Get sub view: {subState} / {subViewBase}");

            return subViewBase;
        }

        public SubViewDto GetSubViewDto(Enum subState)
        {
            Debug.LogWarning("get sub view dto: " + subState);
            var subView = GetSubView(subState);
            Debug.LogWarning("sub view: " + subView);

            return new SubViewDto
            {
                InSafeZone = subView.inSafeZone,
                Template = subView.GetTemplate()
            };
        }
    }
}
