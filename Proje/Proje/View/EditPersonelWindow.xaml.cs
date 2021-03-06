﻿using Proje.ViewModel;
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
    /// Interaction logic for EditPersonelWindow.xaml
    /// </summary>
    public partial class EditPersonelWindow : Window,IDisposable
    {
        public EditPersonelViewModel EditPersonelViewModel;
        public EditPersonelWindow(Model.PersonelModel selecItem)
        {
            InitializeComponent();
            EditPersonelViewModel = new EditPersonelViewModel(selecItem);
            //EditPersonelViewModel editPersonelViewModel = new EditPersonelViewModel(selecItem);
            DataContext = EditPersonelViewModel;
        }

        public void Dispose()
        {
            EditPersonelViewModel = null;
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
