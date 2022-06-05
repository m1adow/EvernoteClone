﻿using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class LoginCommand : ICommand
    {
        public LoginViewModel? LoginViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public LoginCommand(LoginViewModel? loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //TODO: Login functionality
        }
    }
}
