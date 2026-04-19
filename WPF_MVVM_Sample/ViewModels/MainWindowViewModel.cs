using WPF_MVVM_Sample.Common;
using WPF_MVVM_Sample.Manager;
using WPF_MVVM_Sample.Views;

namespace WPF_MVVM_Sample.ViewModels;

public class MainWindowViewModel
{
    public NavigationHost NavHost { get; } = new();

    public MainWindowViewModel(NavigationManager nav)
    {
        nav.SetHost(NavHost);

        // 初期画面
        nav.Navigate<HomePageView, HomePageViewModel>();
    }
}
