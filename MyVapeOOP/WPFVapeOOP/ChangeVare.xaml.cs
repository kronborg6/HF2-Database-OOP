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

            PickVare.ItemsSource = Vare.GuiGetVareID();

            PickVare.DisplayMemberPath = "name";
            PickVare.SelectedValuePath = "number";
        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void GetVareWhitID_Click(object sender, RoutedEventArgs e)
        {
            Vare Vares = new Vare();
            ComboBoxChange icb = (ComboBoxChange)PickVare.SelectedItem;
            int VareID = icb.number;
            CheckVareInfo.ItemsSource = Vares.GuiGetVareFromID(VareID);
        }

        private void ChangeVare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vare Vares = new Vare();
                ComboBoxChange icb = (ComboBoxChange)PickVare.SelectedItem;
                int VareID = icb.number;

                string VareNavn = IVareNavn.Text;

                string StVareAntal = IVareAntal.Text;
                int VareAntal = int.Parse(StVareAntal);

                string StVarePrise = IVarePrise.Text;
                float VarePrise = float.Parse(StVarePrise);



                if (String.IsNullOrEmpty(VareNavn))
                {
                    MessageBox.Show("Du glemt at inpute et navn" + Environment.NewLine, "C# tilføje vare", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                if (String.IsNullOrEmpty(StVareAntal))
                {
                    MessageBox.Show("Du glemt at inpute et Antaæ" + Environment.NewLine, "C# tilføje vare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (String.IsNullOrEmpty(StVarePrise))
                {
                    MessageBox.Show("Du glemt at inpute en Prise " + Environment.NewLine, "C# tilføje vare", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Vare.ChangeVareGui(VareNavn, VarePrise, VareAntal, VareID);

                    MessageBox.Show("Vare er blevet add til databasen", "add Vare", MessageBoxButton.OK);


                    IVareNavn.Text = "";
                    IVareAntal.Text = "";
                    IVarePrise.Text = "";

                    MainWindow mainWindow = new MainWindow();
                    this.Hide();
                    mainWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der var en fejl med at ændre Vare til Databasen " + Environment.NewLine + "Descriptions; " + ex.Message.ToString(), "C# ændre vare", MessageBoxButton.OK, MessageBoxImage.Error);

                throw;
            }

        }
    }
}
