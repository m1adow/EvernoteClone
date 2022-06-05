using EvernoteClone.Model;
using System.Windows;
using System.Windows.Controls;

namespace EvernoteClone.View.UserControls
{
    /// <summary>
    /// Interaction logic for NoteControl.xaml
    /// </summary>
    public partial class NoteControl : UserControl
    {
        public Note Note
        {
            get { return (Note)GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(Note), typeof(NoteControl), new PropertyMetadata(null, SetValues));

        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NoteControl? noteControl = d as NoteControl;

            if (noteControl is null)
                return;

            noteControl.DataContext = noteControl.Note;
        }
        public NoteControl()
        {
            InitializeComponent();
        }
    }
}
