using System.Windows.Controls;
using WPF_MVVM_Sample.ViewModels;

namespace WPF_MVVM_Sample.Views;

/// <summary>
/// HomePageView.xaml の相互作用ロジック
/// </summary>
public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();

        //this.DataContext = vm;
    }
}
