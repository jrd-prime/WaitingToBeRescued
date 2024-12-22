﻿using _Game._Scripts.Framework.Data.SO.Item;
using _Game._Scripts.Framework.Interacts.WorldObjs.ObjsSettings;

namespace _Game._Scripts.Player.Data
{
    public interface IPlayerDataManager
    {
        bool CheckCollectConditions(CollectionConditionsData settingsCollectionConditions);
    }

    public class PlayerDataManager : IPlayerDataManager
    {
        public bool CheckCollectConditions(CollectionConditionsData settingsCollectionConditions)
        {
            return false;
        }
    }
}
