using Microsoft.Xaml.Behaviors;
using Reactive.Bindings;
using System.Diagnostics;
using System.Reactive;
using System.Windows;

namespace WPF_MVVM_Sample.Behaviors;

public class CloseWindowBehavior : Behavior<Window>
{
    public static readonly DependencyProperty CloseRequestProperty =
        DependencyProperty.Register(
            nameof(CloseRequest),
            //typeof(IObservable<Unit>),
            typeof(ReactiveCommand),
            typeof(CloseWindowBehavior),
            new PropertyMetadata(null, OnChanged));

    public ReactiveCommand? CloseRequest
    {
        get => (ReactiveCommand?)GetValue(CloseRequestProperty);
        set => SetValue(CloseRequestProperty, value);
    }

    private IDisposable? _subscription;

    private static void OnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var behavior = (CloseWindowBehavior)d;

        if (e.OldValue is ReactiveCommand oldCmd)
            behavior._subscription?.Dispose();

        if (e.NewValue is ReactiveCommand newCmd)
        {
            behavior._subscription = newCmd.Subscribe(_ =>
            {
                behavior.AssociatedObject.Dispatcher.Invoke(() =>
                {
                    behavior.AssociatedObject.Close();
                });
            });
        }
    }

    protected override void OnAttached()
    {
        base.OnAttached();
        Subscribe();
    }

    private void Subscribe(ReactiveCommand? command = null)
    {
        _subscription?.Dispose();

        var target = command ?? CloseRequest;

        if (target != null)
        {
            _subscription = target.Subscribe(_ =>
            {
                Debug.WriteLine("CloseRequest received");

                AssociatedObject.Dispatcher.Invoke(() =>
                {
                    AssociatedObject.Close();
                });
            });
        }
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        _subscription?.Dispose();
    }
}