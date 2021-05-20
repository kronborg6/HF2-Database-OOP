using Caliburn.Micro;
using GUIVapeOOP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUIVapeOOP
{
    public class Bootstrapperr : BootstrapperBase
    {
        public Bootstrapperr()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
