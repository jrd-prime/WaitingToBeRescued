using _Game._Scripts.Framework.Helpers.Editor.Attributes;
using _Game._Scripts.Framework.Interact.Character.Processors;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Game._Scripts.Framework.ContextScope
{
    public class UIContext : LifetimeScope
    {

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("<color=cyan>UI context</color>");

        }
    }
}
