using System.Windows;
using System.Windows.Media;

namespace JPA_Porra_Burgos.View
{
    /// <summary>
    /// Lógica de interacción para AppWarnDialog.xaml
    /// </summary>
    public partial class AppWarnDialog : Window
    {
        public AppWarnDialog()
        {
            InitializeComponent();
            AllowDrag();
        }

        private void AllowDrag() => MouseLeftButtonDown += (s, e) =>
                                      DragMove();

        private void OnClick_Continue(object sender, RoutedEventArgs e) => Close();

        private void OnEnterFGChange(object sender, System.Windows.Input.MouseEventArgs e) => btnContinue.Foreground = Brushes.Black;
        private void OnLeaveFGChange(object sender, System.Windows.Input.MouseEventArgs e) => btnContinue.Foreground = Brushes.WhiteSmoke;

        public static AppWarnDialog Show(string message)
        {
            var warnDialog = new AppWarnDialog();
            warnDialog.txtWarnMessage.Text = message;
            warnDialog.ShowDialog();
            return warnDialog;
        }
    }
}
