using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Proje.Helper
{
    /// <summary>
    /// Gelen pozisyonID değerine karşılık olarak pozisyon bilgisini gönderir.
    /// </summary>
    public class PozisyonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PozisyonProvider pozisyon = new PozisyonProvider();
            var list= pozisyon.PozisyonGetir();
            foreach (var item in list)
            {
                if (value.Equals(item.PozisyonID))
                {
                    return item.Pozisyon;
                }
            }
            return "Giriş yok";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
