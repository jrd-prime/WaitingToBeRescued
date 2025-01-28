using System.Collections.Generic;
using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Data.SO.Item.Lootable;
using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using JetBrains.Annotations;
using VContainer;

namespace _Game._Scripts.Stuff._Base
{
    public interface IStuffDataManager
    {
        public bool CheckCollectConditions(CollectionConditionsData collectionConditionsData);
        public bool CheckUseConditions(UsingConditionsData usingConditions);
    }

    /// <summary>
    /// TEMPORARY STUB
    /// </summary>
    [UsedImplicitly]
    public class StuffDataManager : IStuffDataManager
    {
        private IBackpack backpack;

        [Inject]
        private void Construct(IObjectResolver resolver)
        {
            backpack = resolver.Resolve<IBackpack>();
        }

        public bool CheckCollectConditions(CollectionConditionsData collectionConditionsData)
        {
            List<SettingsSO> missingStuff = new List<SettingsSO>();
            if (!backpack.IsResourcesEnough(collectionConditionsData.resources,
                    out Dictionary<int, float> missingResources))
            {
            }


            collectionConditionsData.ShowDebug(); // TODO remove
            return true;
        }

        public bool CheckUseConditions(UsingConditionsData usingConditions)
        {
            usingConditions.ShowDebug(); // TODO remove
            return true;
        }
    }
}
