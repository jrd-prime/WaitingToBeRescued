using System;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.UI.Menu.Base
{
    public interface IMenuModel<TSubStateEnum> : IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
    }

    public interface IGameplayModel<TSubStateEnum> : IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
    }

    public interface IGameoverModel<TSubStateEnum> : IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
    }
    public interface IPauseModel<TSubStateEnum> : IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
    }  public interface IWinModel<TSubStateEnum> : IUIModel<TSubStateEnum>
        where TSubStateEnum : Enum
    {
    }
}
