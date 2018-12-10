namespace Telemetry.Read
{
    public class GameData
    {
        public GameData(byte[] data)
        {
            this.RawData = data;
            this.RawSize = data.Length;
        }

        public byte[] RawData { get; set; }
        public int RawSize { get; set; }
    }
}
