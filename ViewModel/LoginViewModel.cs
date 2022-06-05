using EvernoteClone.Model;
using EvernoteClone.ViewModel.Commands;

namespace EvernoteClone.ViewModel
{
    public class LoginViewModel
    {
        private User? _user;

        public User? User
        {
            get { return _user; }
            set 
            { 
                _user = value;
                //OnPropertyChanged(nameof(User));
            }
        }

        public RegisterCommand? RegisterCommand { get; set; }

        public LoginCommand? LoginCommand { get; set; }

        public LoginViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }
    }
}
