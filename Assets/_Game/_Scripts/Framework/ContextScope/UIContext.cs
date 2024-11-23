using _Game._Scripts.Framework.Manager.UI;
using _Game._Scripts.UI.Gameplay;
using _Game._Scripts.UI.Menu;
using _Game._Scripts.UI.Menu.Base;
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
