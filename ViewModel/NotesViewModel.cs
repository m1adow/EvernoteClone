using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;
using EvernoteClone.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EvernoteClone.ViewModel
{
    public class NotesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Notebook>? Notebooks { get; set; }

        public ObservableCollection<Note>? Notes { get; set; }

        private Notebook? _selectedNotebook;

        public Notebook? SelectedNotebook
        {
            get { return _selectedNotebook; }
            set
            {
                _selectedNotebook = value;
                OnPropertyChanged(nameof(SelectedNotebook));
                GetNotes();
            }
        }

        private FontFamily? _fontFamily;

        public FontFamily? FontFamily
        {
            get { return _fontFamily; }
            set
            {
                _fontFamily = value;
                OnPropertyChanged(nameof(FontFamily));
                FontFamilyChangeCommand?.Execute(null);
            }
        }

        private bool _isBold;

        public bool IsBold
        {
            get { return _isBold; }
            set
            {
                _isBold = value;
                OnPropertyChanged(nameof(_isBold));
            }
        }

        private bool _isItalic;

        public bool IsItalic
        {
            get { return _isItalic; }
            set
            {
                _isItalic = value;
                OnPropertyChanged(nameof(_isItalic));
            }
        }

        private bool _isUnderline;

        public bool IsUnderline
        {
            get { return _isUnderline; }
            set
            {
                _isUnderline = value;
                OnPropertyChanged(nameof(_isUnderline));
            }
        }

        private Visibility? _isVisible;

        public Visibility? IsVisible
        {
            get { return _isVisible; }
            set 
            { 
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }


        public List<FontFamily>? FontsFamilies { get; set; }

        public List<double> FontSizes { get; set; }

        public CreateNotebookCommand? CreateNotebookCommand { get; set; }

        public CreateNoteCommand? CreateNoteCommand { get; set; }

        public ShutdownCommand? ShutdownCommand { get; set; }

        public SpeechCommand? SpeechCommand { get; set; }

        public StylingCommand? StylingCommand { get; set; }

        public FontFamilyChangeCommand? FontFamilyChangeCommand { get; set; }
        public StartEditingCommand? StartEditingCommand { get; set; }

        public EndEditingCommand? EndEditingCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public NotesViewModel()
        {
            CreateNotebookCommand = new CreateNotebookCommand(this);
            CreateNoteCommand = new CreateNoteCommand(this);
            ShutdownCommand = new ShutdownCommand(this);
            SpeechCommand = new SpeechCommand(this);
            StylingCommand = new StylingCommand(this);
            FontFamilyChangeCommand = new FontFamilyChangeCommand(this);
            StartEditingCommand = new StartEditingCommand(this);
            EndEditingCommand = new EndEditingCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            IsVisible = Visibility.Collapsed;

            FontsFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source).ToList();
            FontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 28, 48, 64, 72 };

            GetNotebooks();
        }

        public void CreateNotebook()
        {
            Notebook notebook = new()
            {
                Name = "New notebook"
            };

            DatabaseHelper.Insert(notebook);

            GetNotebooks();
        }

        public void CreateNote(int notebookId)
        {
            Note note = new()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = $"Note for {DateTime.Now}"
            };

            DatabaseHelper.Insert(note);

            GetNotes();
        }

        private void GetNotebooks()
        {
            var notebooks = DatabaseHelper.Read<Notebook>();

            Notebooks?.Clear();

            foreach (var notebook in notebooks)
                Notebooks?.Add(notebook);
        }

        private void GetNotes()
        {
            var notes = DatabaseHelper.Read<Note>().Where(n => n.Id == SelectedNotebook?.Id).ToList();

            Notes?.Clear();

            foreach (var note in notes)
                Notes?.Add(note);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StartEditing()
        {
            IsVisible = Visibility.Visible;
        }

        public void StopEditing(Notebook notebook)
        {
            IsVisible = Visibility.Collapsed;
            DatabaseHelper.Update(notebook);
            GetNotebooks();
        }
    }
}
