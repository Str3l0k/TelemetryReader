namespace TelemetryReader.src.settings.impl
{
    public class TelemetryReaderConfig : Config
    {
        public TelemetryReaderConfig(string folderPath) : base(folderPath)
        {
        }

        public override void initConfigOptions()
        {
            addOption("ip_device_0", ConfigTypes.TYPE_IP);
            addOption("port_device_0", ConfigTypes.TYPE_INTEGER);
            addOption("delay_device_0", ConfigTypes.TYPE_INTEGER);

            addOption("\nip_device_1", ConfigTypes.TYPE_IP);
            addOption("port_device_1", ConfigTypes.TYPE_INTEGER);
            addOption("delay_device_1", ConfigTypes.TYPE_INTEGER);
            addOption("device_1_enabled", ConfigTypes.TYPE_BOOL);
            
            addOption("\nip_device_2", ConfigTypes.TYPE_IP);
            addOption("port_device_3", ConfigTypes.TYPE_INTEGER);
            addOption("delay_device_2", ConfigTypes.TYPE_INTEGER);
            addOption("device_2_enabled", ConfigTypes.TYPE_BOOL);
        }
    }
}
