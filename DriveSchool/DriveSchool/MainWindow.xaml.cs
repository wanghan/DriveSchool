using System.Windows;
using System.Windows.Controls;

namespace DriveSchool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MinWidth = this.Width;
        }


        public void ResizeGridViewColumns()
        {
            foreach (GridViewColumn column in this.grdTest.Columns)
            {
                if (double.IsNaN(column.Width))
                {
                    column.Width = column.ActualWidth;
                }

                column.Width = double.NaN;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (DBHandler.Instance.HasPendingChange())
            {
                string message = "您的修改还没有保存，退出之前是否保存？";
                MessageBoxResult confirm = MessageBox.Show(message, "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (confirm == MessageBoxResult.Yes)
                {
                    DBHandler.Instance.SubmitChanges();
                }
            }

            base.OnClosing(e);
        }
    }
}
