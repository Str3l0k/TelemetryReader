using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TelemetryReader.src.settings
{
    public abstract class Config
    {
        public const string CONFIG_FILE_NAME = "config.ini";

        private ConfigReader configReader;
        private ConfigWriter configWriter;

        private string parentFolderPath;

        private List<IConfigOption> configOptions;

        public Config(string folderPath)
        {
            this.parentFolderPath = folderPath;

            configReader = new ConfigReader();
            configWriter = new ConfigWriter();
            configOptions = new List<IConfigOption>();

            initConfigOptions();
        }

        public bool configFileExists()
        {
            return File.Exists(getFullFilePath());
        }

        public void readConfig()
        {
            if (configFileExists())
            {
                string[] configLines = File.ReadAllLines(getFullFilePath());

                Dictionary<string, string> lines = new Dictionary<string, string>();

                foreach (string line in configLines)
                {
                    string[] splits = line.Split('=');
                    if (splits.Length == 2)
                    {
                        splits[0] = splits[0].Remove(splits[0].Length - 1);
                        splits[1] = splits[1].Remove(0, 1);

                        lines.Add(splits[0], splits[1]);
                    }
                }

                foreach (string item in lines.Values)
                {
                    Debug.WriteLine(item);
                }
            }
        }

        public void writeConfig()
        {
            if (!configFileExists())
            {
                File.Create(getFullFilePath());
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("====================================");
            stringBuilder.AppendLine("=        Configuration file.       =");
            stringBuilder.AppendLine("=          DO NOT MODIFY!          =");
            stringBuilder.AppendLine("====================================");

            foreach (IConfigOption item in configOptions)
            {
                stringBuilder.AppendFormat("{0} = {1}\n", item.getNameString(), item.getValueString());
            }

            File.WriteAllText(getFullFilePath(), stringBuilder.ToString());
        }

        public string getFullFilePath()
        {
            return Path.Combine(parentFolderPath, CONFIG_FILE_NAME);
        }

        public void addOption(string name, int value)
        {
            configOptions.Add(new ConfigOption<int>(name, value));
        }
        
        public abstract void initConfigOptions();
    }
}
