using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class SetStylingCommand : ICommand
    {
        public NotesViewModel? NotesViewModel { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SetStylingCommand(NotesViewModel? notesViewModel)
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

            if (richTextBox is null || NotesViewModel is null)
                return;         

            if (NotesViewModel.IsBold)
                richTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            else
                richTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);

            if (NotesViewModel.IsItalic)
                richTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            else
                richTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);

            if (NotesViewModel.IsUnderline)
                richTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else
            {
                TextDecorationCollection textDecorations;

                (richTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                richTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }      
    }
}
