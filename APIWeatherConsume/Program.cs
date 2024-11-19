


#region Menü Başlangıcı
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;

Console.WriteLine("API Consume İşlemine Hoşgeldiniz");
Console.WriteLine();
Console.WriteLine("### Yapmak İstediğiniz İşlemi Seçiniz. ###");
Console.WriteLine();
Console.WriteLine("1- Şehir Listesini Getir");
Console.WriteLine("2- Şehir ve Hava Durumu Listesini Getirin");
Console.WriteLine("3- Yeni Şehir Ekleme İşlemi");
Console.WriteLine("4- Şehir Silme İşlemi");
Console.WriteLine("5- Şehir Güncelleme İşlemi");
Console.WriteLine("6- ID'ye Göre Şehir Bilgisi Getirme");
Console.WriteLine();
#endregion



string number;

Console.WriteLine("Tercihiniz:");
number = Console.ReadLine();
if (number =="1")
{
    string url = "https://localhost:7269/api/Weather";
    using (HttpClient client = new HttpClient())
    {
     HttpResponseMessage response = await client.GetAsync(url);
        string responseBody =await response.Content.ReadAsStringAsync();
        JArray jArray= JArray.Parse(responseBody);
        foreach (var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            Console.WriteLine($"Şehir:{cityName}");
        }
    }

}
if (number == "2")
{
    string url = "https://localhost:7269/api/Weather";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);
        foreach (var item in jArray)
        {
            string cityName = item["cityName"].ToString();
            string temp = item["temp"].ToString();
            string country = item["country"].ToString();
            Console.WriteLine(cityName + "-" + country +"- Hava Durumu:" +temp+"Derece");
            Console.WriteLine("****************************************************");
        }
    }
}
if (number == "3")
{
    Console.WriteLine("### Yeni Şehir Verisi Girişi ###");
    Console.WriteLine();
    string cityName, country, detail;
    decimal temp;

    Console.Write("Şehir Adı:");
    cityName =Console.ReadLine();

    Console.Write("Ülke Adı:");
    country = Console.ReadLine();

    Console.Write("Sıcaklık:");
    temp =decimal.Parse(Console.ReadLine());

    Console.Write("Hava Durumu Detayı:");
    detail = Console.ReadLine();



    string url = "https://localhost:7269/api/Weather";
    var newWeatherCity = new
    {
        CityName = cityName,
        Country = country,
        Detail = detail,
        Temp = temp
    };

    using (HttpClient client = new HttpClient())
    {
        string json = JsonConvert.SerializeObject(newWeatherCity);
        StringContent content = new StringContent(json,Encoding.UTF8,"application/json");
        HttpResponseMessage response = await client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

}
if (number == "4")
{
    string url = "https://localhost:7269/api/Weather?id=";
    Console.Write("Silmek İstediğiniz Bilginin ID Değeri:");
    int id =int.Parse(Console.ReadLine());

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.DeleteAsync(url + id);
        response.EnsureSuccessStatusCode();
    }

}
if (number == "5")
{
    string url = "https://localhost:7269/api/Weather";

    Console.WriteLine("### Veri Güncelleme İşlemi ###");
    Console.WriteLine();
    string cityName, country, detail;
    decimal temp;
    int cityID;

    Console.Write("Şehir ID:");
    cityID = int.Parse(Console.ReadLine());

    Console.Write("Şehir Adı:");
    cityName = Console.ReadLine();

    Console.Write("Ülke Adı:");
    country = Console.ReadLine();

    Console.Write("Sıcaklık:");
    temp = decimal.Parse(Console.ReadLine());

    Console.Write("Hava Durumu Detayı:");
    detail = Console.ReadLine();


    var updatedWeatherValues = new
    {
        CityID = cityID,
        Country = country,
        Detail = detail,
        Temp = temp,
        CityName = cityName

    };

    using(HttpClient client = new HttpClient())
    {
        string json = JsonConvert.SerializeObject(updatedWeatherValues);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, content);
        response.EnsureSuccessStatusCode();
    }


}
if (number == "6")
{
    string url = "https://localhost:7269/api/Weather/";
    Console.Write("Bilgilerini Getirmek İstediğiniz ID Değeri:");

    int id = int.Parse(Console.ReadLine());

    using(HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url + id);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        JObject weatherCityObject =JObject.Parse(responseBody);

        string cityName = weatherCityObject["cityName"].ToString();
        string country = weatherCityObject["country"].ToString();
        string detail = weatherCityObject["detail"].ToString();
        decimal temp = decimal.Parse(weatherCityObject["temp"].ToString());

        Console.Write("Girmiş Oldugunuz ID Değerine Ait Bilgiler");
        Console.WriteLine();
        Console.Write($"Şehir:{cityName} - Ülke:{country} - Sıcaklık Değeri:{temp} - Detay:{detail}");
        
    }




}