using _Game._Scripts.Framework.Data.SO;
using _Game._Scripts.Framework.Systems.SaveLoad;
using _Game._Scripts.Framework.Tickers;

namespace _Game._Scripts.Stuff._Base
{
    public abstract class StuffBase<TSettings, TSavableDto> : SavableDataModelBase<TSettings, TSavableDto>
        where TSettings : SettingsSO where TSavableDto : IDataComponent
    {
    }
}
