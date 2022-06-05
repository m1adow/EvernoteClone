using EvernoteClone.ViewModel.Helpers;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class SaveCommand : ICommand
    {
        private RichTextBox? _richTextBox;

        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SaveCommand(NotesViewModel? notesViewModel)
        {
            NotesViewModel = notesViewModel;

            NotesViewModel.SelectedNoteChanged += NotesViewModel_SelectedNoteChanged;
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

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _richTextBox = parameter as RichTextBox;

            if (_richTextBox is null || NotesViewModel is null)
                return;

            string rtfFile = Path.Combine(Environment.CurrentDirectory, $"{NotesViewModel.SelectedNote.Id}.rtf");
            NotesViewModel.SelectedNote.FileLocation = rtfFile;
            DatabaseHelper.Update(NotesViewModel.SelectedNote);

            using (var fileStream = new FileStream(rtfFile, FileMode.Create))
            {
                var content = new TextRange(_richTextBox.Document.ContentStart, _richTextBox.Document.ContentEnd);
                content.Save(fileStream, DataFormats.Rtf);
            }
        }
    }
}
