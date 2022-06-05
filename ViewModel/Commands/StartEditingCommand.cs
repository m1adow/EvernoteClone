using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class StartEditingCommand : ICommand
    {
        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public StartEditingCommand(NotesViewModel? notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            NotesViewModel?.StartEditing();
        }      
    }
}
