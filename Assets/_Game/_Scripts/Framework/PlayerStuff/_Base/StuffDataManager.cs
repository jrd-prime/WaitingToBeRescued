using System.Collections.Generic;
using _Game._Scripts.Framework.Data.Enums;
using _Game._Scripts.Framework.Helpers.Extensions;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using JetBrains.Annotations;
using UnityEngine;
using VContainer;

namespace _Game._Scripts.Framework.PlayerStuff._Base
{
    public interface IStuffDataManager
    {
        public bool CheckCollectConditions(CollectionConditionsData data, out List<int> missingStuffForCollect);
        public bool CheckUseConditions(UsingConditionsData usingConditions, out List<int> missingStuffForUse);
    }

    /// <summary>
    /// TEMPORARY STUB
    /// </summary>
    [UsedImplicitly]
    public class StuffDataManager : IStuffDataManager
    {
        private IBackpack _backpack;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            _backpack = resolver.Resolve<IBackpack>();
        }

        public bool CheckCollectConditions(CollectionConditionsData data, out List<int> missingStuffForCollect)
        {
            missingStuffForCollect = new List<int>();

            if (!_backpack.IsResourcesEnough(data.resources.ToIdValueDict(), out var missingResources))
            {
                foreach (var resId in missingResources)
                    Debug.LogWarning("Backpack: not enough " + GameItemTypes.GetEnumName(resId) +
                                     " to collect"); // TODO remove

                missingStuffForCollect.AddRange(missingResources);
            }

            data.ShowDebug(); // TODO remove

            return missingStuffForCollect.Count <= 0;
        }

        public bool CheckUseConditions(UsingConditionsData usingConditions, out List<int> missingStuffForUse)
        {
            missingStuffForUse = new List<int>();
            usingConditions.ShowDebug(); // TODO remove
            return true;
        }
    }
}
