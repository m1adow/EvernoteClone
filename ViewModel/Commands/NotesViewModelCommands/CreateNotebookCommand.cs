using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands.NotesViewModelCommands
{
    public class CreateNotebookCommand : ICommand
    {
        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public CreateNotebookCommand(NotesViewModel? notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            NotesViewModel?.CreateNotebook();
        }
    }
}
