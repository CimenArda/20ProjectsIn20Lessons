using Newtonsoft.Json.Linq;
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

namespace GasPriceSimulationProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double gasolinePrice = 0;
        double motorinPrice = 0;
        double lpgPrice = 0;
        double gasAmount= 0;
        double motorinAmount= 0;
        double lpgAmount= 0;
        double progressbarValue = 0;
        double totalPrice = 0;
        int count = 0;
        private void btnstart_Click(object sender, EventArgs e)
        {
            gasAmount = Convert.ToDouble(txtGasAmount.Text);
            motorinAmount = Convert.ToDouble(txtGasAmount.Text);
            lpgAmount = Convert.ToDouble(txtGasAmount.Text);

            timer1.Start();
            timer1.Interval = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            this.Text = count.ToString();
            if (rdbBenzin.Checked)
            {
                count++;
                if (count<=gasolinePrice)
                {
                    totalPrice += gasolinePrice;
                    txttotalPrice.Text = totalPrice.ToString() + "TL";

                }
                else
                {
                    txttotalPrice.Text = totalPrice.ToString() + "TL";
                }
                progressBar1.Value += 3;
                if (progressBar1.Value ==99)
                {
                    timer1.Stop();

                }
            }
            if (rdbMotorin.Checked)
            {
                count++;
                if (count <= motorinAmount)
                {
                    totalPrice += motorinPrice;
                    txttotalPrice.Text = totalPrice.ToString() + "TL";

                }
                else
                {
                    txttotalPrice.Text = totalPrice.ToString() + "TL";
                }
                progressBar1.Value += 3;
                if (progressBar1.Value == 99)
                {
                    timer1.Stop();

                }
            }
            if (rdbLPG.Checked)
            {
                count++;
                if (count <= lpgAmount)
                {
                    totalPrice += lpgPrice;
                    txttotalPrice.Text = totalPrice.ToString() + "TL";

                }
                else
                {
                    txttotalPrice.Text = totalPrice.ToString() + "TL";
                }
                progressBar1.Value += 1;
                if (progressBar1.Value == 99)
                {
                    timer1.Stop();

                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            //MessageBox.Show("Yakıt Verileri Alınıyor....");
            //
            //txtlpgprice.Text = lpgPrice.ToString() + " TL";
            //txtmotoringprice.Text = motorinPrice.ToString() + " TL";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://akaryakit-fiyatlari.p.rapidapi.com/fuel/istanbul"),
                Headers =
    {
        { "x-rapidapi-key", "ff6bd20e1emshe43dd1aa8d4e77cp1185e1jsnb9d0d86109a6" },
        { "x-rapidapi-host", "akaryakit-fiyatlari.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var gasolinejsonvalue = json["data"][16]["prices"][0]["benzin"];
                var motorinjsonvalue = json["data"][16]["prices"][0]["motorin"];
                var lpgjsonvalue = json["data"][16]["prices"][0]["lpg"];
                txtgasolineprice.Text = gasolinejsonvalue.ToString() + " TL";
                txtmotoringprice.Text = motorinjsonvalue.ToString() + " TL";
                txtlpgprice.Text = lpgjsonvalue.ToString() + " TL";

            }
        }
    }
}
