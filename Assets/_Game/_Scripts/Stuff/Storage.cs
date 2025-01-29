using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.Systems.SaveLoad;
using _Game._Scripts.Framework.Tickers;
using _Game._Scripts.Stuff._Base;
using MessagePack;

namespace _Game._Scripts.Stuff
{
    public class Storage : StuffBase<StorageSO, StorageSavableData>
    {
        protected override void InitializeDataModel()
        {
        }

        protected override StorageSavableData GetDefaultModelData()
        {
            return new StorageSavableData();
        }

        protected override string GetDebugLine()
        {
            return "Storage data";
        }
    }

    [MessagePackObject]
    public sealed class StorageSavableData : ISavableData
    {
    }
}
