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
using CLVape;

namespace WPFVapeOOP
{
    /// <summary>
    /// Interaction logic for SeVare.xaml
    /// </summary>
    /// 


    //Måske Add en måde at søge på??


    public partial class SeVare : Window
    {
        public SeVare()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MyDataGrid.ItemsSource

            Vare Vares = new Vare();
            ViewVare.ItemsSource = Vares.GuiGetVare();
        }

        private void ViewVare_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void LookUp_button_Click(object sender, RoutedEventArgs e)
        {
            Vare Vares = new Vare();

            string StVareAntal = LookUpBox.Text;
            int VareID = int.Parse(StVareAntal);

            ViewVare.ItemsSource = Vares.GuiGetVareFromID(VareID);
        }

        private void Clear_button_Click(object sender, RoutedEventArgs e)
        {
            Vare Vares = new Vare();
            ViewVare.ItemsSource = Vares.GuiGetVare();
        }
    }
}
