using System;
using R3;
using VContainer;

namespace _Game._Scripts.NewUI.Menus.Main
{
    public class MainUIViewModel : CustomUIViewModel<IMainMainMenuModel>, IMainMenu_ViewModel
    {
        public Subject<Unit> PlayButtonClicked { get; } = new();
        public Subject<Unit> SettingsButtonClicked { get; } = new();
        public Subject<Unit> ExitButtonClicked { get; } = new();


        public override void Initialize()
        {
            PlayButtonClicked.Subscribe(_ => Model.StartButtonClicked()).AddTo(Disposables);
            SettingsButtonClicked.Subscribe(_ => Model.SettingsButtonClicked()).AddTo(Disposables);
            ExitButtonClicked.Subscribe(_ => Model.ExitButtonClicked()).AddTo(Disposables);
        }
    }

    public abstract class CustomUIViewModel<T> : UIViewModelBase where T : class, IMainMenuModel
    {
        protected T Model { get; private set; }

        [Inject]
        private void Construct(T model)
        {
            Model = model;

            if (Model == null) throw new NullReferenceException($"{typeof(T)} is null");
        }
    }

    public interface IMainMenuModel
    {
        public void StartButtonClicked();
        public void SettingsButtonClicked();
        public void ExitButtonClicked();
    }

    public abstract class UIViewModelBase
    {
        protected readonly CompositeDisposable Disposables = new();

        public abstract void Initialize();
    }

    public interface IMainMainMenuModel : IMainMenuModel
    {
    }
}
