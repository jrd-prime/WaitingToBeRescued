using _Game._Scripts.Framework.Data.Enums.States;
using _Game._Scripts.Framework.JrdStateMachine.BaseState;
using _Game._Scripts.GameStates.Menu.State.SubState;
using _Game._Scripts.UI.Base.Model;

namespace _Game._Scripts.GameStates.Menu.State
{
    public class MenuState : GameStateBase<IMenuModel, EMenuSubState>
    {
        protected override void InitializeSubStates()
        {
            SubStatesCache.TryAdd(EMenuSubState.Main,
                new MenuMainSubState(UIManager, EGameState.Menu, EMenuSubState.Main));
            SubStatesCache.TryAdd(EMenuSubState.Settings,
                new MenuSettingsSubState(UIManager, EGameState.Menu, EMenuSubState.Settings));
        }

        protected override void InitCustomSubscribes()
        {
        }

        protected override void OnBaseStateEnter()
        {
        }

        protected override void OnBaseStateExit()
        {
        }
    }
}
// private async UniTask RunGameTimerAsync(CancellationToken cancellationToken)
// {
//     float remainingTime = timerDuration - _elapsedTime; // Начинаем с оставшегося времени
//
//     while (remainingTime > 0)
//     {
//         remainingTime -= Time.deltaTime;
//         _elapsedTime = timerDuration - remainingTime; // Обновляем прошедшее время
//
//         GameTimeDto.CurrentValue.RemainingDayTime = remainingTime;
//         Debug.LogWarning($"Time left: {GameTimeDto.CurrentValue.RemainingDayTime:F2} seconds");
//
//         UpdateGameTimeDto();
//         await UniTask.Yield(PlayerLoopTiming.FixedUpdate, cancellationToken); // Ожидаем следующий кадр
//     }
//
//     // day++; // Обновляем день
//     GameTimeDto.CurrentValue.SetDay(GameTimeDto.CurrentValue.Day + 1);
//     UpdateGameTimeDto();
//     Debug.LogWarning($"Day updated to: {GameTimeDto.CurrentValue.Day}");
//
//     _elapsedTime = 0f; // Сбрасываем прошедшее время, потому что день обновлен
//
//     // Запускаем новый таймер
//     StartGameTimer();
// }