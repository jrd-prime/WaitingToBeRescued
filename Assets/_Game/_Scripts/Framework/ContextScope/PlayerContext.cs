﻿using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class PlayerContext : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>Player context</color>");

        }
    }
}
