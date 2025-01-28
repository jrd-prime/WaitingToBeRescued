using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.Tickers;
using _Game._Scripts.Stuff._Base;
using MessagePack;

namespace _Game._Scripts.Stuff
{
    public class Buildings : StuffBase<BuildingsSO, BuildingsData>
    {
        protected override void InitializeDataModel()
        {
        }

        protected override BuildingsData GetDefaultModelData()
        {
            return new BuildingsData();
        }

        protected override string GetDebugLine()
        {
            return "Buildings data";
        }
    }

    [MessagePackObject]
    public sealed class BuildingsData : IDataComponent
    {
    }
}
