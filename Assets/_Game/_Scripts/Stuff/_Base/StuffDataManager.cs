using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using JetBrains.Annotations;

namespace _Game._Scripts.Stuff._Base
{
    public interface IStuffDataManager
    {
        public bool CheckCollectConditions(CollectionConditionsData settingsCollectionConditions);
        public bool CheckUseConditions(UsingConditionsData usingConditions);
    }

    // TODO TEMPORARY!!
    /// <summary>
    /// TEMPORARY STUB
    /// </summary>
    [UsedImplicitly]
    public class StuffDataManager : IStuffDataManager
    {
        public bool CheckCollectConditions(CollectionConditionsData settingsCollectionConditions)
        {
            settingsCollectionConditions.ShowDebug(); // TODO remove
            return true;
        }

        public bool CheckUseConditions(UsingConditionsData usingConditions)
        {
            usingConditions.ShowDebug(); // TODO remove
            return true;
        }
    }
}
