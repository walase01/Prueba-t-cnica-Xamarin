using Prism;
using Prism.Ioc;
using Prism.Unity;
using pruebaTecnica.Services;
using pruebaTecnica.ViewModels;
using pruebaTecnica.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pruebaTecnica
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected async override void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{NavigationConst.nav}/{NavigationConst.main}");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IDatabaseService, DabaseService>();

            containerRegistry.RegisterInstance<IDatabaseService>(new DabaseService());

            containerRegistry.RegisterForNavigation<NavigationPage>(NavigationConst.nav);
            containerRegistry.RegisterForNavigation<MainPage,MainViewModel>(NavigationConst.main);
        }
    }
}
