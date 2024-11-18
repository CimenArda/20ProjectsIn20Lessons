namespace APIWeatherProject.Entities
{
    public class City
    {
        public int CityID { get; set; }

        public string CityName { get; set; }    
        public string Country { get; set; }    

        public decimal Temp {  get; set; }

        public string Detail { get; set; }
    }
}
