using System.Configuration;

namespace Task.Configuration
{
    public class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("pattern", IsKey = true, IsRequired = true)]
        public string Pattern
        {
            get { return (string)base["pattern"]; }
        }

        [ConfigurationProperty("path",  IsRequired = true)]
        public string Path
        {
            get { return (string)base["path"]; }
        }
    }
}