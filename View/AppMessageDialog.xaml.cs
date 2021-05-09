using System.Windows;
using System.Windows.Media;

namespace JPA_Porra_Burgos.View
{
    public partial class AppMessageDialog : Window
    {
        public AppMessageDialog()
        {
            InitializeComponent();
            AllowDrag();
        }

        private void AllowDrag() => MouseLeftButtonDown += (s, e) =>
                                      DragMove();

        private void OnClick_Continue(object sender, RoutedEventArgs e) => Close();

        private void OnEnterFGChange(object sender, System.Windows.Input.MouseEventArgs e) => btnContinue.Foreground = Brushes.Black;
        private void OnLeaveFGChange(object sender, System.Windows.Input.MouseEventArgs e) => btnContinue.Foreground = Brushes.WhiteSmoke;

        public static AppMessageDialog Show(string message)
        {
            var messageDialog = new AppMessageDialog();
            messageDialog.txtMessage.Text = message;
            messageDialog.ShowDialog();
            return messageDialog;
        }
    }
}
