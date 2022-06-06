using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class SelectedNoteChangedCommand : ICommand
    {
        RichTextBox? _richTextBox;

        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SelectedNoteChangedCommand(NotesViewModel? notesViewModel)
        {
            NotesViewModel = notesViewModel;

            NotesViewModel.SelectedNoteChanged += NotesViewModel_SelectedNoteChanged;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _richTextBox = parameter as RichTextBox;
        }

        private void NotesViewModel_SelectedNoteChanged(object? sender, EventArgs e)
        {
            if (_richTextBox is null)
                return;

            _richTextBox.Document.Blocks.Clear();

            if (NotesViewModel is null)
                return;

            if (NotesViewModel.SelectedNote is null)
                return;

            if (string.IsNullOrEmpty(NotesViewModel.SelectedNote.FileLocation))
                return;

            using (var fileStream = new FileStream(NotesViewModel.SelectedNote.FileLocation, FileMode.Open))
            {
                var content = new TextRange(_richTextBox.Document.ContentStart, _richTextBox.Document.ContentEnd);
                content.Load(fileStream, DataFormats.Rtf);
            }
        }
    }
}
