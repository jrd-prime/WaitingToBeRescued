﻿using System;
using _Game._Scripts.Framework.Manager.Shelter;
using _Game._Scripts.Framework.Manager.Shelter.Timer;
using MessagePack;
using R3;
using VContainer.Unity;

namespace _Game._Scripts.Framework.Manager.Game
{
    public interface IGameManager : IInitializable
    {
        public ReactiveProperty<int> PlayerInitialHealth { get; }
        public ReadOnlyReactiveProperty<int> PlayerHealth { get; }
        public ReactiveProperty<bool> IsGameRunning { get; }
        public ReactiveProperty<GameTimerData> GameTimeData { get; }


        public void GameOver();

        public void StopTheGame();

        public void StartNewGame();

        public void Pause();

        public void UnPause();
    }

    
}
