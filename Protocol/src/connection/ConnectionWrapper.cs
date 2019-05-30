using System.Collections.Generic;

namespace Telemetry.Connection
{
    public class TransmitConnectionWrapper : ITransmitConnection
    {
        private readonly List<ITransmitConnection> connections = new List<ITransmitConnection>();

        #region construction
        public TransmitConnectionWrapper() { }

        public TransmitConnectionWrapper(params ITransmitConnection[] connections)
        {
            this.connections.AddRange(connections);
        }
        #endregion

        #region connections control
        public void Add(ITransmitConnection connection)
        {
            connections.Add(connection);
        }

        public void Remove(ITransmitConnection connection)
        {
            connections.Remove(connection);
        }

        public void Clear()
        {
            connections.Clear();
        }
        #endregion

        #region IConnection 
        public void Send(ref byte[] data)
        {
            foreach (ITransmitConnection connection in connections)
            {
                connection.Send(ref data);
            }
        }
        #endregion
    }
}
