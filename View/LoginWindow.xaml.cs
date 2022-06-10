using EvernoteClone.ViewModel;
using System.Windows;

namespace EvernoteClone.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginViewModel? _loginViewModel;

        public LoginWindow()
        {
            InitializeComponent();

            _loginViewModel = Resources["viewModel"] as LoginViewModel;
            _loginViewModel.Authenticated += LoginViewModel_Authenticated;
        }

        private void LoginViewModel_Authenticated(object? sender, System.EventArgs e)
        {
            Close();
        }
    }
}
