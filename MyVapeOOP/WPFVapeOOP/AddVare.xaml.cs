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
    /// Interaction logic for AddVare.xaml
    /// </summary>
    public partial class AddVare : Window
    {
        public AddVare()
        {
            InitializeComponent();
        }

        private void Button_AddVare(object sender, RoutedEventArgs e)
        {
            try
            {
                string VareNavn = INavn.Text;

                int antal;
                if (String.IsNullOrEmpty(IAntal.Text))
                {
                    antal = 0;
                }
                else
                {
                    string StVareAntal = IAntal.Text;
                    antal = int.Parse(StVareAntal);
                }
                string StVarePrise = IPrise.Text;
                float price = float.Parse(StVarePrise);

                string StFirmaID = IFirmaID.Text;
                int firmaID = int.Parse(StFirmaID);

                Vare Vares = new Vare();

                Vare.InestVare(VareNavn, price, antal, firmaID);
                MessageBox.Show("Vare er blevet add til databasen", "add Vare", MessageBoxButton.OK);

                INavn.Text = "";
                IAntal.Text = "";
                IPrise.Text = "";
                IFirmaID.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der var en fejl med at add Vare til Databasen " + Environment.NewLine + "Descriptions; " + ex.Message.ToString(), "C# tilføje vare", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Button_Tilbage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

    }
}
