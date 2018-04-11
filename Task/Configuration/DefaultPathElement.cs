using System.Configuration;

namespace Task.Configuration
{
    public class DefaultPathElement : ConfigurationElement
    {
        [ConfigurationProperty("path", IsKey = true, IsRequired = true)]
        public string Path
        {
            get { return (string)this["path"]; }
        }
    }
}