using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.Tickers;
using _Game._Scripts.Stuff._Base;
using MessagePack;

namespace _Game._Scripts.Stuff
{
    public class Tools : StuffBase<ToolsSO, ToolsSavableData>
    {
        protected override void InitializeDataModel()
        {
        }

        protected override ToolsSavableData GetDefaultModelData()
        {
            return new ToolsSavableData();
        }

        protected override string GetDebugLine()
        {
            return "Tools data";
        }
    }

    [MessagePackObject]
    public sealed class ToolsSavableData : ISavableData
    {
    }
}
