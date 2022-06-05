using System;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class FontSizeChangeCommand : ICommand
    {
        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public FontSizeChangeCommand(NotesViewModel? notesViewModel)
        {
            NotesViewModel = notesViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            RichTextBox? richTextBox = parameter as RichTextBox;

            if (richTextBox is null)
                return;

            richTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, NotesViewModel?.FontSize);
        }
    }
}
