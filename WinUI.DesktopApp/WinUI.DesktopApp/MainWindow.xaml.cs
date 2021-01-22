using Microsoft.UI.Xaml;
using Windows.Foundation;
using WinUI.Desktop.Extensions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI.DesktopApp
{
  /// <summary>
  /// An empty window that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class MainWindow : Window
  {
    public MainWindow()
    {
      this.InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var rect = new Rect();
      rect.X = int.TryParse(txtX.Text, out int x) ? x : this.Bounds.X;
      rect.Y = int.TryParse(txtY.Text, out int y) ? y : this.Bounds.X;
      rect.Width = int.TryParse(txtWidth.Text, out int width) ? width : this.Bounds.Width;
      rect.Height = int.TryParse(txtHeight.Text, out int height) ? height : this.Bounds.Height;

      this.SetWidth((int)rect.Width);
      this.SetHeight((int)rect.Height);
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      //this.CenterOnScreen();
    }
  }
}
