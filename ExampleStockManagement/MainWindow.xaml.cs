using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleStockManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            Window itemsWindow = new ItemsWindow();
            itemsWindow.Show();
        }

        private void StockBtn_Click(object sender, RoutedEventArgs e)
        {
            Window stockManagementWindow = new StockManagementWindow();
            stockManagementWindow.Show();
        }
    }
}
