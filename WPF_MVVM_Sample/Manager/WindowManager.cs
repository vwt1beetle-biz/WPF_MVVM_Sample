using System.Windows;
using Unity;

namespace WPF_MVVM_Sample.Manager;

public class WindowManager
{
    private readonly IUnityContainer _container;

    public WindowManager(IUnityContainer container)
    {
        _container = container;
    }

    // --- Show ---
    public void Show<TWindow>() where TWindow : Window
    {
        var window = _container.Resolve<TWindow>();
        window.Show();
    }

    public void Show<TWindow, TViewModel>() where TWindow : Window
    {
        var window = _container.Resolve<TWindow>();
        var vm = _container.Resolve<TViewModel>();
        window.DataContext = vm;
        window.Show();
    }

    // --- Switch（引数なし版） ---
    public void Switch<TWindow>() where TWindow : Window
    {
        var current = GetActiveWindow();

        var window = _container.Resolve<TWindow>();
        window.Show();

        current?.Close();
    }

    public void Switch<TWindow, TViewModel>() where TWindow : Window
    {
        var current = GetActiveWindow();

        var window = _container.Resolve<TWindow>();
        var vm = _container.Resolve<TViewModel>();
        window.DataContext = vm;

        window.Show();
        current?.Close();
    }

    // --- Close ---
    public void CloseWindow()
    {
        var current = GetActiveWindow();
        current?.Close();
    }

    private Window? GetActiveWindow()
    {
        return Application.Current.Windows
            .OfType<Window>()
            .SingleOrDefault(w => w.IsActive);
    }
}
