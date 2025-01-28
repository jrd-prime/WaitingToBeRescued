using _Game._Scripts.Framework.Data.SO.Stuff;
using _Game._Scripts.Framework.Tickers;
using _Game._Scripts.Stuff._Base;
using MessagePack;

namespace _Game._Scripts.Stuff
{
    public class Skills : StuffBase<SkillsSO, SkillsData>
    {
        protected override void InitializeDataModel()
        {
        }

        protected override SkillsData GetDefaultModelData()
        {
            return new SkillsData();
        }

        protected override string GetDebugLine()
        {
            return "Skills data";
        }
    }

    [MessagePackObject]
    public sealed class SkillsData : IDataComponent
    {
    }
}
