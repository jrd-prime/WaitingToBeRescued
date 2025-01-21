﻿using System;
using System.Collections.Generic;

namespace _Game._Scripts.Framework.Data.SO.Item._Base
{
    public abstract class NonLootableItemSO<TItemTypeEnum> : InGameObjectSO
        where TItemTypeEnum : Enum
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
