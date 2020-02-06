using System.Text.RegularExpressions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using XamarinTest.Helpers;
using XamarinTest.Services.Interfaces;
using XamarinTest.ViewModels.Base;
using XamarinTest.Views;

namespace XamarinTest.ViewModels {
    public class RegisterPageViewModel : BaseViewModel {
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        public DelegateCommand LoginCommand { get; set; }

        public RegisterPageViewModel(IAccountService accountService, INavigationService navigationService, IPageDialogService pageDialogService) {
            _accountService = accountService;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            RegisterCommand = new DelegateCommand(Register);
            LoginCommand = new DelegateCommand(Login);
        }

        private bool IsValid() {
            if (string.IsNullOrEmpty(Username)
                || string.IsNullOrEmpty(Password)
                || string.IsNullOrEmpty(ConfirmPassword)) {
                _pageDialogService.DisplayAlertAsync("Please fill in all the form fields.", "", "OK");
                return false;
            }

            if (!Regex.IsMatch(Username, ValidationHelper.EmailPattern)) {
                _pageDialogService.DisplayAlertAsync("Email field is not correct.", "", "OK");
                return false;
            }

            if (!string.Equals(Password, ConfirmPassword)) {
                _pageDialogService.DisplayAlertAsync("Passwords do not match.", "", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(Username)) {
                _pageDialogService.DisplayAlertAsync("Please enter your user name.", "", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(Password)) {
                _pageDialogService.DisplayAlertAsync("Please enter your password.", "", "OK");
                return false;
            }
            return true;
        }

        private async void Register() {
            if (!IsValid()) return;

            var emailResult = _accountService.CheckEmailAsync(Username);
            if (emailResult.Result.IsSuccess) {
                await _pageDialogService.DisplayAlertAsync("Such email already exists.", "", "OK");
            } else {
                var registerResult = await _accountService.RegisterAsync(Username, Password);
                if (registerResult.IsSuccess) {
                    await _navigationService.NavigateAsync($"/{nameof(LoginPage)}");
                } else {
                    await _pageDialogService.DisplayAlertAsync(registerResult.Error, "", "OK");
                }
            }
        }

        private async void Login() {
            await _navigationService.NavigateAsync($"/{nameof(LoginPage)}/");
        }
    }
}
