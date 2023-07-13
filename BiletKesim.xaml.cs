using System;
using System.Collections.Generic;
using System.Data;
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
    /// BiletKesim.xaml etkileşim mantığı
    /// </summary>
    public partial class BiletKesim : Window
    {
        SinemaContext context = new SinemaContext();
        private string FilmAdi;
        private string FilmTur;
        private int FilmSure;
        private string Unvan;
        private int BiletUcreti;
        private int Film_Id;

        public void biletlistele()
        {
            dgwbilet.ItemsSource = context.BiletKesims.ToList();
        }
        public BiletKesim()
        {
            InitializeComponent();
            biletlistele();
        }

        private void dgwbilet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = (DataGrid)sender;
            DataRowView dataRow = data.SelectedItems as DataRowView;
            if (dataRow != null)
            {
                TxtId.Text = dataRow["Film_Id"].ToString();
                txtfilmad.Text = dataRow["FilmAdi"].ToString();
                txttur.Text = dataRow["FilmTur"].ToString();
                txtunvan.Text = dataRow["Unvan"].ToString();
                txtucret.Text = dataRow["BiletUcreti"].ToString();
                txtsüre.Text = dataRow["FilmSure"].ToString();
            }
        }

        private void btnekle_Click(object sender, RoutedEventArgs e)
        {
            WPFSinema.Model.BiletKesim bilet = new WPFSinema.Model.BiletKesim();
            bilet.FilmAdi = txtfilmad.Text;
            bilet.FilmTur = txttur.Text;
            bilet.Unvan = txtunvan.Text;
            bilet.BiletUcreti = int.Parse(txtucret.Text);
            bilet.FilmSure = int.Parse(txtsüre.Text);
            context.BiletKesims.Add(bilet);
            context.SaveChanges();
            MessageBox.Show("Kaydedildi");
            biletlistele();
        }

        private void btnsil_Click(object sender, RoutedEventArgs e)
        {
            int ıd = int.Parse(TxtId.Text);
            var biletsil = context.BiletKesims.FirstOrDefault(x => x.Film_Id == ıd);
            context.BiletKesims.Remove(biletsil);
            context.SaveChanges();
            MessageBox.Show("silindi");
            biletlistele();
        }

        private void btnguncelle_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var biletgun = context.BiletKesims.FirstOrDefault(x => x.Film_Id == id);
            biletgun.FilmAdi = txtfilmad.Text;
            biletgun.FilmTur = txttur.Text;
            biletgun.FilmSure = int.Parse(txtsüre.Text);
            biletgun.Unvan = txtunvan.Text;
            biletgun.BiletUcreti = int.Parse(txtucret.Text);
            context.SaveChanges();
            MessageBox.Show("güncellendi");
            biletlistele();
        }

        private void btntemizle_Click(object sender, RoutedEventArgs e)
        {
            txtfilmad.Text = txttur.Text = txtsüre.Text = txtucret.Text = TxtId.Text = txtunvan.Text = string.Empty;
        }
    }
}
