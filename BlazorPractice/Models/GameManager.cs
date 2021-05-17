﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPractice.Models
{
    public class GameManager : INotifyPropertyChanged
    {
        private readonly int _gravity = 2;

        public event PropertyChangedEventHandler PropertyChanged;
        public BirdModel Bird { get; set; }
        public bool IsRunning { get; set; } = false;
        public GameManager ()
        {
            Bird = new BirdModel();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {
                Bird.Fall(2);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bird)));
               
                if(Bird.DistanceFromGround <= 0)
                {
                    GameOver();
                }
                
                await Task.Delay(20);
            }
        }

        public void StartGame()
        {
            if (!IsRunning)
            {
                Bird = new BirdModel();
                MainLoop();
            }
        }
        public void GameOver()
        {
            IsRunning = false;
        }
    }
}
