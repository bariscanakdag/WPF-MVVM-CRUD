using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Proje.View;
using Proje.ViewModel;

namespace Proje
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
         {
            base.OnStartup(e);
            PersonelView window = new PersonelView();
            PersonelViewModel VM = new PersonelViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }

}

