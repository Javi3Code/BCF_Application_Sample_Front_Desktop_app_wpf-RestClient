using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JPA_Porra_Burgos.View
{
    public partial class AppQuestDialog : Window
    {
        public bool Result { get; set; }
        public AppQuestDialog()
        {
            InitializeComponent();
            AllowDrag();
        }

        private void AllowDrag() => MouseLeftButtonDown += (s, e) =>
                                      DragMove();


        private void OnEnterFGChange(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var btn = sender as Button;
            btn.Foreground = Brushes.Black;
        }

        private void OnLeaveFGChange(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var btn = sender as Button;
            btn.Foreground = Brushes.WhiteSmoke;
        }

        public static AppQuestDialog Show(string message)
        {
            var questDialog = new AppQuestDialog();
            questDialog.txtRMessage.Text = message;
            questDialog.ShowDialog();
            return questDialog;
        }

        private void OnClick_Accept(object sender, RoutedEventArgs e)
        {
            Result = true;
            Close();
        }

        private void OnClick_Cancel(object sender, RoutedEventArgs e)
        {
            Result = false;
            Close();
        }
    }
}
