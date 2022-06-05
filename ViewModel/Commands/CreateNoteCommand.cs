using EvernoteClone.Model;
using System;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class CreateNoteCommand : ICommand
    {
        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreateNoteCommand(NotesViewModel? notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            Notebook? selectedNotebook = parameter as Notebook;
            return selectedNotebook is null ? false : true;
        }

        public void Execute(object? parameter)
        {
            Notebook? selectedNotebook = parameter as Notebook;

            if (selectedNotebook is null)
                return;

            NotesViewModel?.CreateNote(selectedNotebook.Id);
        }
    }
}
