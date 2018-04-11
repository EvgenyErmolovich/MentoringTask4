using System.Configuration;

namespace Task.Configuration
{
    public class CultureElement : ConfigurationElement
    {
        [ConfigurationProperty("culture", IsKey = true, DefaultValue = "en-US")]
        public string Culture
        {
            get { return (string)this["culture"]; }
        }
    }
}