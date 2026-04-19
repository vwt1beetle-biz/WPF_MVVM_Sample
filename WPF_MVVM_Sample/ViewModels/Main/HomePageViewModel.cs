using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Diagnostics;
using WPF_MVVM_Sample.Common;
using WPF_MVVM_Sample.Manager;
using WPF_MVVM_Sample.Views;

namespace WPF_MVVM_Sample.ViewModels;

public class HomePageViewModel: ViewModelBase
{
    public ReactiveCommand ShowWindow1Command { get; } = new();
    public ReactiveCommand ShowWindow2Command { get; } = new();
    public ReactiveCommand ShowWindow3Command { get; } = new();

    public ReactiveCommand NavPageCommand { get; } = new();
    public ReactiveCommand CloseCommand { get; } = new();

    private readonly WindowManager windowManager_;
    private readonly NavigationManager navigationManager_;
    private readonly NavigationHost navHost_;


    public HomePageViewModel(WindowManager windowManager, NavigationManager navigationManager, NavigationHost NavHost)
    {
        windowManager_ = windowManager;
        navigationManager_ = navigationManager;
        navHost_ = NavHost;


        ShowWindow1Command.Subscribe(_ =>
        {
            windowManager_.Show<SecondWindow, SecondWindowViewModel>();
        }).AddTo(Disposables);

        ShowWindow2Command.Subscribe(_ =>
        {
            windowManager_.Show<SecondWindow, SecondWindowViewModel>();
        }).AddTo(Disposables);

        NavPageCommand.Subscribe(_ =>
        {
            navigationManager_.Navigate<SubPageView, SubPageViewModel>();
        }).AddTo(Disposables);

        CloseCommand.Subscribe(_ =>
        {
            Debug.WriteLine("Page Host: " + navHost_.GetHashCode());
            // 自分を閉じる
            navHost_.CloseRequest.Execute();
        }).AddTo(Disposables);
    }
}
