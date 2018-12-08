namespace TelemetryReader.src.settings
{
    public class ConfigOption<T> : IConfigOption
    {
        public string optionName { get; private set; }
        public int optionType { get; private set; }
        public T optionValue { get; set; }

        public ConfigOption(string name, int type)
        {
            optionName = name;
            optionType = type;
        }
        
        public string getNameString()
        {
            return optionName;
        }

        public string getValueString()
        {
            return optionValue.ToString();
        }

        public int getItemType()
        {
            return optionType;
        }
    }

    public interface IConfigOption
    {
        string getNameString();
        string getValueString();
        int getItemType();
    }
}
