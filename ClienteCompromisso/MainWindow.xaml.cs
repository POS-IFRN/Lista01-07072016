using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ClienteCompromisso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ip = "http://10.21.0.137";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Compromisso c = new Models.Compromisso
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDesc.Text,
                Local = txtLocal.Text,
                Data = Convert.ToDateTime(dpData.SelectedDate),
                Realizado = bool.Parse(cmbRealizado.Text)
            };
            List<Models.Compromisso> co = new List<Models.Compromisso>();
            co.Add(c);
            string s = "=" + JsonConvert.SerializeObject(co);
            var content = new StringContent(s, Encoding.UTF8,
            "application/x-www-form-urlencoded");
            await httpClient.PostAsync("/20131011110380/api/compromisso", content);
        }

        private async void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/20131011110380/api/compromisso");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Compromisso> obj = JsonConvert.DeserializeObject<List<Models.Compromisso>>(str);
            ListBoxCompromissos.ItemsSource = obj;
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Compromisso c = new Models.Compromisso
            {
                Id = int.Parse(txtId.Text),
                Descricao = txtDesc.Text,
                Local = txtLocal.Text,
                Data = Convert.ToDateTime(dpData.SelectedDate),
                Realizado = bool.Parse(cmbRealizado.Text)
            };

            string s = "=" + JsonConvert.SerializeObject(c);
            var content = new StringContent(s, Encoding.UTF8,
            "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/20131011110380/api/compromisso/" + c.Id,
            content);

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            await httpClient.DeleteAsync("/20131011110380/api/compromisso/" +
            txtId.Text);
        }
    }
}
