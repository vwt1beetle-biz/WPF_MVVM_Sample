using System.Windows;
using Unity;
using Unity.Resolution;
using WPF_MVVM_Sample.Common;

namespace WPF_MVVM_Sample.Manager;

public class NavigationManager
{
    private readonly IUnityContainer _container;
    private NavigationHost? _host;

    public NavigationManager(IUnityContainer container)
    {
        _container = container;
    }

    public void SetHost(NavigationHost host)
    {
        _host = host;
    }

    public void Navigate<TPageView, TViewModel>()
    {
        if (_host == null) throw new InvalidOperationException();

        var view = _container.Resolve<TPageView>();

        var vm = _container.Resolve<TViewModel>(
            new ParameterOverride("NavHost", _host)
        );

        if (view is FrameworkElement fe)
        {
            fe.DataContext = vm;
        }

        _host.Set(view);
    }
}