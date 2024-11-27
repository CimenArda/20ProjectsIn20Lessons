using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace WeatherCardProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/Istanbul/TR"),
                Headers =
    {
        { "x-rapidapi-key", "ff6bd20e1emshe43dd1aa8d4e77cp1185e1jsnb9d0d86109a6" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var fahrenheit = json["main"]["feels_like"].ToString();
                var windSpeed = json["wind"]["speed"].ToString();
                var humadity = json["main"]["humidity"].ToString();
                lblfahrenheit.Text = fahrenheit;
                lblhumidity.Text = humadity;
                lblwindSpeed.Text = windSpeed;

                double celcius = (double.Parse(fahrenheit) - 32);

                double celciusvalue = celcius / 1.8;
                lblcelcius.Text = celciusvalue.ToString("0.00");
            }
        }
    }
}
