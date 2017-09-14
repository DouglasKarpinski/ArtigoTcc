namespace WebApiTcc.Models
{
    public static class Parameters
    {
        public static UriApi UriApi { get; set; }
       
    }

    public class UriApi
    {
        public string Ecommerce => "http://localhost:30019/";
        public string Azure => "http://emotionwebapi.azurewebsites.net";
    }
}
