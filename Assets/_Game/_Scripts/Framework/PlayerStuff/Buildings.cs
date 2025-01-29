using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.PlayerStuff._Base;
using _Game._Scripts.Framework.Systems.SaveLoad;
using MessagePack;

namespace _Game._Scripts.Framework.PlayerStuff
{
    public class Buildings : StuffBase<BuildingsSO, BuildingsSavableData>
    {
        protected override void InitializeDataModel()
        {
        }

        protected override BuildingsSavableData GetDefaultModelData()
        {
            return new BuildingsSavableData();
        }

        protected override string GetDebugLine()
        {
            return "Buildings data";
        }
    }

    [MessagePackObject]
    public sealed class BuildingsSavableData : ISavableData
    {
    }
}
