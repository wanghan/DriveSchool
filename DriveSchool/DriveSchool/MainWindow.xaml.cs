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
    }
}
