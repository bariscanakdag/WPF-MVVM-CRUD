using Microsoft.Win32;
using Proje.Helper;
using Proje.Model;
using Proje.View;
using System; using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using System.Windows.Media.Imaging;

namespace Proje.ViewModel
{
    public class NewPersonelViewModel : INotifyPropertyChanged
    {
        ResimProvaider ResimProvaider = new ResimProvaider();
        private PersonelModel personel;

        public PersonelModel Personel
        {
            get { return personel; }
            set { personel = value;
                OnPropertyChanged(nameof(Personel));
            }
        }

        public NewPersonelViewModel(PersonelModel personel)
        {
            Personel = personel;
        }

        private string  selectPozisyon ;

        public string SelectPozisyon
        {
            get { return selectPozisyon; }
            set { selectPozisyon = value; }
        }
        private ICommand savePersonel;

        public ICommand SavePersonel
        {
            get {
                if (savePersonel == null)
                    savePersonel = new RelayCommand(Save);
                return savePersonel;

            }
            
        }
        public event EventHandler PersonelSave;
     


        private void Save()
        {
            PersonelModel person = new PersonelModel();
            person.Adi = Personel.Adi;
            person.Soyadi = Personel.Soyadi;
            person.Yas = Personel.Yas;
            person.Cinsiyet = Personel.Cinsiyet;
            person.PozisyonID = int.Parse(SelectPozisyon);
           PersonelProvider personelProvider = new PersonelProvider();
            personelProvider.PersonelEkle(person);
            //listview de dogru id gözükmesi için
            person = personelProvider.TekPersonelGetir();
            ResimProvaider.ResimEkle(base64Encoded,person.PersonelID);
           
            if (PersonelSave != null)
            {
                
                PersonelSave(person,null);
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
        private ICommand imageAdd;

        public ICommand ImageAdd
        {
            get{
                if (imageAdd == null)
                    imageAdd = new RelayCommand(AddImage);
                return imageAdd;

            }
        }
        public string base64Encoded { get; set; }

        private void AddImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "RESİM AÇ";
            openFile.Filter= "Resim Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            openFile.ShowDialog();
            base64Encoded = Convert.ToBase64String(File.ReadAllBytes(openFile.FileName));
            ImageSource = openFile.FileName;
         

            
            
           
            
            
        }

       

        private string imageSource;

        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        
    }
}
