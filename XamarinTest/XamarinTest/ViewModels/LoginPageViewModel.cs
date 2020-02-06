using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using XamarinTest.Helpers;
using XamarinTest.Services.Interfaces;
using XamarinTest.ViewModels.Base;
using XamarinTest.Views;

namespace XamarinTest.ViewModels {
    public class LoginPageViewModel : BaseViewModel {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        public string Username { get; set; }
        public string Password { get; set; }
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }

        public LoginPageViewModel(IAccountService accountService, INavigationService navigationService, IPageDialogService pageDialogService) {
            _accountService = accountService;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            LoginCommand = new DelegateCommand(Login);
            RegisterCommand = new DelegateCommand(Register);
        }

        private bool IsValid() {
            if (string.IsNullOrEmpty(Username)
                || string.IsNullOrEmpty(Password)) {
                _pageDialogService.DisplayAlertAsync("Please fill in all the form fields.", "", "OK");
                return false;
            }
            if (!Regex.IsMatch(Username, ValidationHelper.EmailPattern)) {
                _pageDialogService.DisplayAlertAsync("Email field is not correct.", "", "OK");
                return false;
            }
            return true;
        }

        private async void Login() {
            if (!IsValid()) return;
            var result = await _accountService.LoginAsync(Username, Password);
            if (!result.IsSuccess) {
                await _pageDialogService.DisplayAlertAsync("Wrong email or password.", "or ConnectFailure (Network is unreachable)", "OK");
                return;
            }
            await _navigationService.NavigateAsync($"/{nameof(ImagePage)}/");
        }

        private async void Register() {
            await _navigationService.NavigateAsync($"/{nameof(RegisterPage)}/");
        }
    }
}
