using System.Windows;
using Unity;
using WPF_MVVM_Sample.Common;
using WPF_MVVM_Sample.Manager;
using WPF_MVVM_Sample.ViewModels;
using WPF_MVVM_Sample.Views;

namespace WPF_MVVM_Sample;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IUnityContainer Container { get; private set; } = null!;

    private void App_Startup(object sender, StartupEventArgs e)
    {
        Container = new UnityContainer();

        // --- Manager ---
        Container.RegisterSingleton<WindowManager>();
        Container.RegisterSingleton<NavigationManager>();
        //Container.RegisterSingleton<NavigationHost>();

        // --- Window ---
        Container.RegisterType<MainWindow>();
        Container.RegisterType<MainWindowViewModel>();
        Container.RegisterType<SecondWindow>();
        Container.RegisterType<SecondWindowViewModel>();

        // --- Page ---
        Container.RegisterType<HomePageView>();
        Container.RegisterType<HomePageViewModel>();
        Container.RegisterType<SubPageView>();
        Container.RegisterType<SubPageViewModel>();
        Container.RegisterType<SecondHomePageView>();
        Container.RegisterType<SecondHomePageViewModel>();


        // Window表示
        var window = Container.Resolve<MainWindow>();
        var vm = Container.Resolve<MainWindowViewModel>();

        window.DataContext = vm;
        window.Show();
    }
    private void App_Exit(object sender, ExitEventArgs e)
    {
        // TODO：起動後処理
    }
}
