using System.Configuration;

namespace Task.Configuration
{
    public class SimpleConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("directories")]
        public DirectoryElementCollection Directories
        {
            get { return (DirectoryElementCollection)this["directories"]; }
        }

        [ConfigurationProperty("rules")]
        public RuleElementCollection Rules
        {
            get { return (RuleElementCollection)this["rules"]; }
        }

        [ConfigurationProperty("defaultPath")]
        public DefaultPathElement DefaultPath
        {
            get { return (DefaultPathElement)this["defaultPath"]; }
        }

        [ConfigurationProperty("options")]
        public OptionsElement Options
        {
            get { return (OptionsElement)this["options"]; }
        }

        [ConfigurationProperty("culture")]
        public CultureElement CultureInfo
        {
            get { return (CultureElement)this["culture"]; }
        }
    }
}
