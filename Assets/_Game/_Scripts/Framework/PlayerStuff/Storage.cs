using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.PlayerStuff._Base;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.PlayerStuff
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
