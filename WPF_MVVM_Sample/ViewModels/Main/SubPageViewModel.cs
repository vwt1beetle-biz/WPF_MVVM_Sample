using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using WPF_MVVM_Sample.Manager;
using WPF_MVVM_Sample.Views;

namespace WPF_MVVM_Sample.ViewModels;

public class SubPageViewModel: ViewModelBase
{
    private readonly NavigationManager navigationManager_;

    ReactiveCommand CloseRequest { get; } = new();
    ReactiveCommand NavPageCommand { get; } = new();
    ReactiveCommand CloseCommand { get; } = new();


    public SubPageViewModel(NavigationManager NavManager)
    {
        navigationManager_ = NavManager;


        NavPageCommand.Subscribe(_ =>
        {
            navigationManager_.Navigate<HomePageView, HomePageViewModel>();
        }).AddTo(Disposables);

        CloseCommand.Subscribe(_ =>
        {
            // 自分を閉じる
            CloseRequest.Execute();
        }).AddTo(Disposables);
    }
}
