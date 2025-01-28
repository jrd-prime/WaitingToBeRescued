﻿using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.Tickers;
using _Game._Scripts.Stuff._Base;
using MessagePack;

namespace _Game._Scripts.Stuff
{
    public class Storage : StuffBase<StorageSO, StorageData>
    {
        protected override void InitializeDataModel()
        {
        }

        protected override StorageData GetDefaultModelData()
        {
            return new StorageData();
        }

        protected override string GetDebugLine()
        {
            return "Storage data";
        }
    }

    [MessagePackObject]
    public sealed class StorageData : IDataComponent
    {
    }
}
