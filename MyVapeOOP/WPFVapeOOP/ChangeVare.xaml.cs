using CLVape;
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
using System.Windows.Shapes;

namespace WPFVapeOOP
{
    /// <summary>
    /// Interaction logic for ChangeVare.xaml
    /// </summary>
    public partial class ChangeVare : Window
    {
        public ChangeVare()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MyDataGrid.ItemsSource

            List<ComboBoxChange> icb = new List<ComboBoxChange>();


            Vare.GuiGetVareID();
            //icb.Add(new ComboBoxChange("Sødt", 100));

            PickVare.DisplayMemberPath = "name";
            PickVare.SelectedValuePath = "number";
            PickVare.ItemsSource = icb;



        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}
