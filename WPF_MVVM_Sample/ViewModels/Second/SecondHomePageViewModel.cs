using WPF_MVVM_Sample.Common;
using WPF_MVVM_Sample.Manager;

namespace WPF_MVVM_Sample.ViewModels;

public class SecondHomePageViewModel
{
    private readonly WindowManager windowManager_;
    private readonly NavigationManager navigationManager_;
    private readonly NavigationHost navHost_;


    public SecondHomePageViewModel(WindowManager windowManager, NavigationManager navigationManager, NavigationHost NavHost)
    {
        windowManager_ = windowManager;
        navigationManager_ = navigationManager;
        navHost_ = NavHost;
    }
}
