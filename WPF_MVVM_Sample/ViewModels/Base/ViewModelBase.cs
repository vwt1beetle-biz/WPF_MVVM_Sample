using Reactive.Bindings;
using System.Reactive.Disposables;

namespace WPF_MVVM_Sample.ViewModels;

public class ViewModelBase: IDisposable
{
    public CompositeDisposable Disposables { get; } = [];
    public ReactiveProperty<bool> RequestClose { get; } = new(false);

    public void Dispose()
    {
        Disposables.Dispose();
    }
}
