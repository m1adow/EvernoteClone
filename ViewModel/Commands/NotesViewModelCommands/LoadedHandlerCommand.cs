using EvernoteClone.View;
using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands.NotesViewModelCommands
{
    public class LoadedHandlerCommand : ICommand
    {
        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public LoadedHandlerCommand(NotesViewModel? notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(App.UserId))
            {
                LoginWindow loginWindow = new();
                loginWindow.ShowDialog();
            }
        }
    }
}
