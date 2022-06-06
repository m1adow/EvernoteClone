using EvernoteClone.Model;
using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands.LoginViewModelCommands
{
    public class LoginCommand : ICommand
    {
        public LoginViewModel? LoginViewModel { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public LoginCommand(LoginViewModel? loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            User? user = parameter as User;

            if (user is null)
                return false;

            if (string.IsNullOrEmpty(user?.Username) || string.IsNullOrEmpty(user?.Password))
                return false;

            return true;
        }

        public void Execute(object? parameter)
        {
            LoginViewModel?.Login();
        }
    }
}
