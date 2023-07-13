using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Salonlar.xaml etkileşim mantığı
    /// </summary>
    public partial class Salonlar : Window
    {
        SinemaContext context = new SinemaContext();
        private string FilmAdi;
        private string FilmTur;
        private int FilmSure;
        private int SalonNumarasi;
        private int Film_Id;
        private int KoltukSayisi;

        public void salonlistele()
        {
            dgwsalon.ItemsSource = context.SalonBilgileris.ToList();
        }
        public Salonlar()
        {
            InitializeComponent();
            salonlistele();
        }

        private void dgwsalon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = (DataGrid)sender;
            DataRowView dataRow = data.SelectedItems as DataRowView;
            if (dataRow != null)
            {
                TxtId.Text = dataRow["Film_Id"].ToString();
                txtfilmad.Text = dataRow["FilmAdi"].ToString();
                txttur.Text = dataRow["FilmTur"].ToString();
                txtsure.Text = dataRow["FilmSure"].ToString();
                txtsalon.Text = dataRow["SalonNumarasi"].ToString();
                txtkoltuk.Text = dataRow["KoltukSayisi"].ToString();
            }
        }

        private void btnekle_Click(object sender, RoutedEventArgs e)
        {
            WPFSinema.Model.SalonBilgileri salon = new WPFSinema.Model.SalonBilgileri();
            salon.FilmAdi = txtfilmad.Text;
            salon.FilmTur = txttur.Text;
            salon.FilmSure = int.Parse(txtsure.Text);
            salon.SalonNumarasi = int.Parse(txtsalon.Text);
            salon.KoltukSayisi = int.Parse(txtkoltuk.Text);
            context.SalonBilgileris.Add(salon);
            context.SaveChanges();
            MessageBox.Show("Kaydedildi");
            salonlistele();
        }

        private void btnsil_Click(object sender, RoutedEventArgs e)
        {
            int ıd = int.Parse(TxtId.Text);
            var salonsil = context.SalonBilgileris.FirstOrDefault(x => x.Film_Id == ıd);
            context.SalonBilgileris.Remove(salonsil);
            context.SaveChanges();
            MessageBox.Show("silindi");
            salonlistele();
        }

        private void btnguncelle_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var salongun = context.SalonBilgileris.FirstOrDefault(x => x.Film_Id == id);
            salongun.FilmAdi = txtfilmad.Text;
            salongun.FilmTur = txttur.Text;
            salongun.FilmSure = int.Parse(txtsure.Text);
            salongun.SalonNumarasi = int.Parse(txtsalon.Text);
            salongun.KoltukSayisi = int.Parse(txtkoltuk.Text);
            context.SaveChanges();
            MessageBox.Show("güncellendi");
            salonlistele();
        }

        private void btntemizle_Click(object sender, RoutedEventArgs e)
        {
            txtfilmad.Text = txttur.Text = txtsure.Text = txtsalon.Text = TxtId.Text = txtkoltuk.Text =string.Empty;
        }
    }
}
