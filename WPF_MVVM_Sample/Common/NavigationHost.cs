using Reactive.Bindings;
using System.Diagnostics;

namespace WPF_MVVM_Sample.Common;

public class NavigationHost
{
    public ReactiveProperty<object?> CurrentView { get; } = new();

    public ReactiveCommand CloseRequest { get; } = new();

    public NavigationHost()
    {
        Debug.WriteLine("NavigationHost: " + GetHashCode());
    }

    public void Set(object view)
    {
        CurrentView.Value = view;
    }
}
