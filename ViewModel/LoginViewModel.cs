using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands.LoginViewModelCommands;
using System.ComponentModel;
using System.Windows;

namespace EvernoteClone.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool _isShowingRegister = false;

        private User? _user;

        public User? User
        {
            get { return _user; }
            set 
            { 
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private string? _username;

        public string? Username
        {
            get { return _username; }
            set
            {
                _username = value;

                this.User = new User
                {
                    Username = _username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.Lastname,
                    ConfirmPassword = this.ConfirmPassword
                };

                OnPropertyChanged(nameof(Username));
            }
        }

        private string? _password;

        public string? Password
        {
            get { return _password; }
            set
            {
                _password = value;

                this.User = new User
                {
                    Username = this.Username,
                    Password = _password,
                    Name = this.Name,
                    Lastname = this.Lastname,
                    ConfirmPassword = this.ConfirmPassword
                };

                OnPropertyChanged(nameof(Password));
            }
        }

        private string? _name;

        public string? Name
        {
            get { return _name; }
            set 
            { 
                _name = value;

                this.User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = _name,
                    Lastname = this.Lastname,
                    ConfirmPassword = this.ConfirmPassword
                };

                OnPropertyChanged(nameof(Name));
            }
        }

        private string? _lastname;

        public string? Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;

                this.User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = _lastname,
                    ConfirmPassword = this.ConfirmPassword
                };

                OnPropertyChanged(nameof(Lastname));
            }
        }

        private string? _confirmPassword;

        public string? ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;

                this.User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.Lastname,
                    ConfirmPassword = _confirmPassword
                };

                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private Visibility _loginVisibility;
       
        public Visibility LoginVisibility
        {
            get { return _loginVisibility; }
            set
            {
                _loginVisibility = value;
                OnPropertyChanged(nameof(LoginVisibility));
            }
        }

        private Visibility _registerVisibility;

        public Visibility RegisterVisibility
        {
            get { return _registerVisibility; }
            set
            {
                _registerVisibility = value;
                OnPropertyChanged(nameof(RegisterVisibility));
            }
        }

        public RegisterCommand? RegisterCommand { get; set; }

        public LoginCommand? LoginCommand { get; set; }

        public ShowRegisterCommand? ShowRegisterCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public LoginViewModel()
        {
            LoginVisibility = Visibility.Visible;
            RegisterVisibility = Visibility.Collapsed;

            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
            ShowRegisterCommand = new ShowRegisterCommand(this);

            User = new User();
        }

        public void SwitchViews()
        {
            _isShowingRegister = !_isShowingRegister;

            if (_isShowingRegister)
            {
                RegisterVisibility = Visibility.Visible;
                LoginVisibility = Visibility.Collapsed;
            }
            else
            {
                RegisterVisibility = Visibility.Collapsed;
                LoginVisibility = Visibility.Visible;
            }
        }

        public void Login()
        {
            //TODO: Login
        }
        
        public void Register()
        {
            //TODO: Register
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
