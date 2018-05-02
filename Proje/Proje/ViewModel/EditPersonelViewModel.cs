using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Proje.Helper;

using Proje.Model;
using Proje.View;
namespace Proje.ViewModel
{
    public class EditPersonelViewModel : INotifyPropertyChanged
    {

        private PersonelModel personel;

        public PersonelModel Personel
        {
            get { return personel; }
            set { personel = value; }
        }
        
        private ICommand editSave;

        public EditPersonelViewModel(PersonelModel selecItem)
        {
            Personel = selecItem;
           
        }

        public ICommand EditSave
        {
            get {

                if (editSave == null)
                    editSave = new RelayCommand(Save);
                return editSave;
            }
            
        }

        private void Save()
        {
            
         
           
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
