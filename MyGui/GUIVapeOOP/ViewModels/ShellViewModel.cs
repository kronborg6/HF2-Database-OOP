using Caliburn.Micro;
using GUIVapeOOP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIVapeOOP.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        public ShellViewModel()
        {

        }
        public void LoadPageKunder()
        {
            FirstChildView window1 = new FirstChildView();
            window1.ShowDialog();

            //Actions

            window1.Close();

        }
        public void LoadPageVare()
        {
            //ActiveItem(new ShellViewModel());
        }
        public void LoadPageOrder()
        {

        }
        public void LoadPageOne()
        {
            //ActiveItem(new FirstChildViewModel());
            //ActiveItem(new FirstChildViewModel());
            //Activate(FirstChildViewModel);
        }
    }
}
