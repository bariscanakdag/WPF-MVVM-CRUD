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
        PersonelProvider PersonelProvider = new PersonelProvider();
        private PersonelModel personel;

        public PersonelModel Personel
        {
            get { return personel; }
            set { personel = value;
                OnPropertyChanged(nameof(Personel));
            }
        }

        private ICommand editSave;

        public EditPersonelViewModel(PersonelModel selecItem)
        {
            Personel = selecItem;

        }

        public ICommand EditSave
        {
            get
            {

                if (editSave == null)
                    editSave = new RelayCommand(Save);
                return editSave;
            }

        }
        private string selectPozisyon;

        public string SelectPozisyon
        {
            get { return selectPozisyon; }
            set { selectPozisyon = value; }
        }
        public event EventHandler PersonelEdit;
        
        private void Save()
        {

            
            personel.Adi = Personel.Adi;
            personel.Soyadi = Personel.Soyadi;
            personel.Yas = Personel.Yas;
            personel.PozisyonID =  Personel.PozisyonID;
            personel.PersonelID = Personel.PersonelID;
            personel.Cinsiyet = Personel.Cinsiyet;
            PersonelProvider.PersonelEdit(personel);
            if (PersonelEdit != null)
            {
                PersonelEdit(personel, null);
            }


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
