using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
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
    /// Filmler.xaml etkileşim mantığı
    /// </summary>
    public partial class Filmler : Window
    {
        SinemaContext context = new SinemaContext();
        private string FilmAdi;
        private string FilmTur;
        private int FilmSure;
        private string FilmYonetmen;
        private int Film_Id;
        
        public void filmlistele()
        {
            dgwfilmler.ItemsSource=context.Filmlers.ToList();
        }
        public Filmler()
        {
            InitializeComponent();
            filmlistele();
        }
        

        private void dgwfilmler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = (DataGrid)sender;
            DataRowView dataRow = data.SelectedItems as DataRowView;
            if (dataRow != null)
            {
                TxtId.Text = dataRow["Film_Id"].ToString();
                txtfilmad.Text = dataRow["FilmAdi"].ToString();
                txttur.Text = dataRow["FilmTur"].ToString();
                txtsure.Text = dataRow["FilmSure"].ToString();
                txtyonetmen.Text = dataRow["FilmYonetmen"].ToString();
            }

        }

        private void btnekle_Click(object sender, RoutedEventArgs e)
        {
          
           WPFSinema.Model.Filmler film = new WPFSinema.Model.Filmler();
            //Filmler film = new Filmler();
           film.FilmAdi = txtfilmad.Text;
           film.FilmTur= txttur.Text;
           film.FilmSure = int.Parse(txtsure.Text);
           film.FilmYonetmen = txtyonetmen.Text;
           context.Filmlers.Add(film);
           context.SaveChanges();
           MessageBox.Show("Kaydedildi");
           filmlistele();

        }

        private void btnsil_Click(object sender, RoutedEventArgs e)
        {
            
            int ıd = int.Parse(TxtId.Text);
            var filmsil = context.Filmlers.FirstOrDefault(x => x.Film_Id == ıd);
            context.Filmlers.Remove(filmsil);
            context.SaveChanges();
            MessageBox.Show("silindi");
            filmlistele();
        }

        private void btnguncelle_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var filmgun = context.Filmlers.FirstOrDefault(x => x.Film_Id == id);
            filmgun.FilmAdi = txtfilmad.Text;
            filmgun.FilmTur = txttur.Text;
            filmgun.FilmSure = int.Parse(txtsure.Text);
            filmgun.FilmYonetmen = txtyonetmen.Text;
            context.SaveChanges();
            MessageBox.Show("güncellendi");
            filmlistele();
        }

        private void btnguncelle_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btntemizle_Click(object sender, RoutedEventArgs e)
        {
            txtfilmad.Text = txttur.Text = txtsure.Text = txtyonetmen.Text = TxtId.Text = string.Empty;
        }
    }
}
