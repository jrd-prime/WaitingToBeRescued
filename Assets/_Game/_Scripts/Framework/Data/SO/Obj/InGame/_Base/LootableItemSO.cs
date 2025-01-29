using System;
using System.Collections.Generic;

namespace _Game._Scripts.Framework.Data.SO.Obj.InGame._Base
{
    public abstract class LootableItemSOBase : InGameObjectSO
    {
    }

    public abstract class LootableItemSO<TItemTypeEnum> : LootableItemSOBase where TItemTypeEnum : Enum
    {
        public TItemTypeEnum itemId;


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (EqualityComparer<TItemTypeEnum>.Default.Equals(itemId, default))
                throw new Exception($"Item type/id is not set. {name}");
            RenameAsset(itemId);
        }
#endif
    }
}
