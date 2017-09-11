namespace WebApiTcc.Models
{
    public class Notification
    {
        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
