using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFSinema.Model;

namespace WPFSinema
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //using (SinemaContext context = new SinemaContext())
            //{
            //    context.Database.Create();
            //}
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-V9UFISJV\\SQLEXPRESS; Initial Catalog=SinemaOtomasyonDB; Integrated Security=True");
        private void Login_click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            SqlCommand sqlLogin = new SqlCommand("Select *from Logins Where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", conn);
            sqlLogin.Parameters.AddWithValue("@KullaniciAdi", txtusername.Text);
            sqlLogin.Parameters.AddWithValue("@Sifre", txtpassword.Password);

            SqlDataReader dataReaderLogin = sqlLogin.ExecuteReader();
            if (txtusername.Text != "" && txtpassword.Password != "")
            {
                if (dataReaderLogin.Read())
                {
                    MessageBox.Show("Otomasyon Sistemine Hoşgeldiniz");
                    Anasayfa mainForm = new Anasayfa();
                    mainForm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Tekrar Deneyiniz");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurun");
            }
            conn.Close();
        }
    }
}
