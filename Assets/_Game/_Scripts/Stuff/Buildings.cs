using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.Tickers;
using _Game._Scripts.Stuff._Base;
using MessagePack;

namespace _Game._Scripts.Stuff
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
