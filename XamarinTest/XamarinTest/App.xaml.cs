using AutoMapper;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using XamarinTest.Data;
using XamarinTest.Data.Interfaces;
using XamarinTest.Services;
using XamarinTest.Services.Interfaces;
using XamarinTest.ViewModels;
using XamarinTest.Views;

namespace XamarinTest {
    public partial class App : PrismApplication {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) {
            InitializeComponent();
        }

        protected override async void OnInitialized() {
            if (Application.Current.Properties.ContainsKey("token")) {
                await NavigationService.NavigateAsync($"/{nameof(ImagePage)}");
            } else {
                await NavigationService.NavigateAsync($"/{nameof(LoginPage)}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.Register<IUnitOfWork, UnitOfWork>();
            containerRegistry.RegisterInstance<IMapper>(new Mapper(Mapping.Configuration.Create()));
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IImageService, ImageService>();
            containerRegistry.Register<IAccountService, AccountService>();

            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ImagePage, ImagePageViewModel>();
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}