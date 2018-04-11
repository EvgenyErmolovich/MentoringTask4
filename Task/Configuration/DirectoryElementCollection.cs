using System.Configuration;

namespace Task.Configuration
{
    public class DirectoryElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DirectoryElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DirectoryElement)element).DirectoryPath;
        }
    }
}