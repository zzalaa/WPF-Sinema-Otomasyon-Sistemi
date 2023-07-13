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
using WPFSinema.Model;

namespace WPFSinema
{
    /// <summary>
    /// Anasayfa.xaml etkileşim mantığı
    /// </summary>
    public partial class Anasayfa : Window
    {
        public Anasayfa()
        {
            InitializeComponent();
           // using (SinemaContext context = new SinemaContext())
           //{
           //     context.Database.Create(); 
           //}
        }
        

        private void btnfilms_Click(object sender, RoutedEventArgs e)
        {
            Filmler filmler = new Filmler();
            filmler.Show();
        }

        private void btnseans_Click(object sender, RoutedEventArgs e)
        {
            Seanslar seanslar = new Seanslar();
            seanslar.Show();
        }

        private void btnsalon_Click(object sender, RoutedEventArgs e)
        {
            Salonlar salonlar = new Salonlar(); 
            salonlar.Show();
        }

        private void btnbilet_Click(object sender, RoutedEventArgs e)
        {
            BiletKesim biletKesim = new BiletKesim();
            biletKesim.Show();
        }
    }
}
