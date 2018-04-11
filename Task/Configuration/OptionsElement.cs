using System.Configuration;

namespace Task.Configuration
{
    public class OptionsElement : ConfigurationElement
    {
        [ConfigurationProperty("addDate", IsKey = true, DefaultValue = false)]
        public bool AddDate
        {
            get { return (bool)this["addDate"]; }
        }

        [ConfigurationProperty("addNumber", IsKey = true, DefaultValue = false)]
        public bool AddNumber
        {
            get { return (bool)this["addNumber"]; }
        }
    }
}