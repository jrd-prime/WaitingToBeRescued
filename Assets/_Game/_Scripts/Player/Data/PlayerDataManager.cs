using _Game._Scripts.Framework.Interacts.WorldObjs.Data;
using JetBrains.Annotations;

namespace _Game._Scripts.Player.Data
{
    public interface IPlayerDataManager
    {
        public bool CheckCollectConditions(CollectionConditionsData settingsCollectionConditions);
        public bool CheckUseConditions(UsingConditionsData usingConditions);
    }

    /// <summary>
    /// Временно
    /// </summary>
    [UsedImplicitly]
    public class PlayerDataManager : IPlayerDataManager
    {
        public bool CheckCollectConditions(CollectionConditionsData settingsCollectionConditions)
        {
            return false;
        }

        public bool CheckUseConditions(UsingConditionsData usingConditions)
        {
            return false;
        }
    }
}
