using System.Configuration;

namespace Task.Configuration
{
    public class DirectoryElement : ConfigurationElement
    {
        [ConfigurationProperty("path", IsKey = true, IsRequired = true)]
        public string DirectoryPath
        {
            get { return (string)base["path"]; }
        }
    }
}