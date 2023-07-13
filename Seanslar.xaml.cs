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
    /// Seanslar.xaml etkileşim mantığı
    /// </summary>
    public partial class Seanslar : Window
    {
        SinemaContext context = new SinemaContext();
        private string FilmAdi;
        private string FilmTur;
        private int FilmSure;
        private string Seans;
        private int Film_Id;

        public void seanslistele()
        {
            dgwseans.ItemsSource = context.Seanslars.ToList();
        }
        public Seanslar()
        {
            InitializeComponent();
            seanslistele();
        }

        private void dgwseans_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = (DataGrid)sender;
            DataRowView dataRow = data.SelectedItems as DataRowView;
            if (dataRow != null)
            {
                TxtId.Text = dataRow["Film_Id"].ToString();
                txtfilmad.Text = dataRow["FilmAdi"].ToString();
                txttur.Text = dataRow["FilmTur"].ToString();
                txtsure.Text = dataRow["FilmSure"].ToString();
                txtseans.Text = dataRow["Seans"].ToString();
            }
        }

        private void btnekle_Click(object sender, RoutedEventArgs e)
        {
            WPFSinema.Model.Seanslar seans = new WPFSinema.Model.Seanslar();
            seans.FilmAdi = txtfilmad.Text;
            seans.FilmTur = txttur.Text;
            seans.FilmSure = int.Parse(txtsure.Text);
            seans.Seans = txtseans.Text;
            context.Seanslars.Add(seans);
            context.SaveChanges();
            MessageBox.Show("Kaydedildi");
            seanslistele();
        }

        private void btnsil_Click(object sender, RoutedEventArgs e)
        {
            int ıd = int.Parse(TxtId.Text);
            var seanssil = context.Seanslars.FirstOrDefault(x => x.Film_Id == ıd);
            context.Seanslars.Remove(seanssil);
            context.SaveChanges();
            MessageBox.Show("silindi");
            seanslistele();
        }

        private void btnguncelle_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var seansgun = context.Seanslars.FirstOrDefault(x => x.Film_Id == id);
            seansgun.FilmAdi = txtfilmad.Text;
            seansgun.FilmTur = txttur.Text;
            seansgun.FilmSure = int.Parse(txtsure.Text);
            seansgun.Seans = txtseans.Text;
            
            context.SaveChanges();
            MessageBox.Show("güncellendi");
            seanslistele();
        }

        private void btntemizle_Click(object sender, RoutedEventArgs e)
        {
            txtfilmad.Text = txttur.Text = txtsure.Text = txtseans.Text = TxtId.Text = string.Empty;
        }
    }
}
