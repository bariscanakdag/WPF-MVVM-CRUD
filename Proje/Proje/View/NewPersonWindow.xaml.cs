using Proje.ViewModel;
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

namespace Proje.View
{
    /// <summary>
    /// Interaction logic for NewPersonWindow.xaml
    /// </summary>
    public partial class NewPersonWindow : Window
    {
        public NewPersonWindow()
        {
            InitializeComponent();
            DataContext = new NewPersonelViewModel();
        }

    
    }
}
