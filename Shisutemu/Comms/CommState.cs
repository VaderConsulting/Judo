using System.Net.Sockets;
using System.Text;

// State object for reading data asynchronously  
public class CommState
{
	// Client  socket.  
	public Socket Socket = null;

	// Size of receive buffer.  
	public const int BufferSize = 1024;

	// Receive buffer.  
	public byte[] ReceiveBuffer = new byte[BufferSize];

	// Received data string.  
	public StringBuilder ReceivedData = new StringBuilder();
}