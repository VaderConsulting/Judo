using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class Server
{
	#region Constants

	#endregion

	#region Delegates

	#endregion

	#region Events

	#endregion

	#region Enums

	#endregion

	#region DLL Imports

	#endregion

	#region Fields

	// Thread signal.  
	public static ManualResetEvent allDone = new ManualResetEvent(false);

	private static int _Port = 0;

	#endregion

	#region Properties

	#endregion

	#region Constructors and Destructor

	public Server()
	{
	}

	#endregion

	#region Event Handlers

	public static void AcceptCallback(IAsyncResult asyncResult)
	{
		// Signal the main thread to continue.  
		allDone.Set();

		// Get the socket that handles the client request.  
		Socket listener = (Socket)asyncResult.AsyncState;
		Socket handler = listener.EndAccept(asyncResult);

		// Create the state object.  
		CommState state = new CommState();
		state.Socket = handler;

		Console.WriteLine("Connecting...");
		handler.BeginReceive(state.ReceiveBuffer, 0, CommState.BufferSize, 0, new AsyncCallback(ReadCallback), state);
		Console.WriteLine("Connected");
	}

	public static void ReadCallback(IAsyncResult asyncResult)
	{
		String content = String.Empty;

		// Retrieve the state object and the handler socket  
		// from the asynchronous state object.  
		CommState state = (CommState)asyncResult.AsyncState;
		Socket handler = state.Socket;

		// Read data from the client socket.   
		int bytesRead = handler.EndReceive(asyncResult);

		if (bytesRead > 0)
		{
			// There  might be more data, so store the data received so far.  
			state.ReceivedData.Append(Encoding.ASCII.GetString(state.ReceiveBuffer, 0, bytesRead));

			// Check for end-of-file tag. If it is not there, read   
			// more data.  
			content = state.ReceivedData.ToString();
			if (content.IndexOf("<EOF>") > -1)
			{
				// All the data has been read from the   
				// client. Display it on the console.  
				Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
				// Echo the data back to the client.  
				Send(handler, content);
			}
			else
			{
				// Not all data received. Get more.  
				handler.BeginReceive(state.ReceiveBuffer, 0, CommState.BufferSize, 0, new AsyncCallback(ReadCallback), state);
			}
		}
	}

	private static void Send(Socket handler, String data)
	{
		// Convert the string data to byte data using ASCII encoding.  
		byte[] byteData = Encoding.ASCII.GetBytes(data);

		// Begin sending the data to the remote device.  
		handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
	}

	private static void SendCallback(IAsyncResult asyncResult)
	{
		try
		{
			// Retrieve the socket from the state object.  
			Socket handler = (Socket)asyncResult.AsyncState;

			// Complete sending the data to the remote device.  
			int bytesSent = handler.EndSend(asyncResult);
			Console.WriteLine("Sent {0} bytes to client.", bytesSent);

			handler.Shutdown(SocketShutdown.Both);
			handler.Close();

		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	#endregion

	#region Private Methods

	private static void StartListening(int Port)
	{
		// Data buffer for incoming data.  
		byte[] bytes = new Byte[1024];
		_Port = Port;

		// Establish the local endpoint for the socket.  
		IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

		IPAddress ipAddress = null;

		foreach (IPAddress address in ipHostInfo.AddressList)
		{
			if (address.AddressFamily == AddressFamily.InterNetwork)
			{
				ipAddress = address;
				break;
			}
		}
		
		IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _Port);

		// Create a TCP/IP socket.  
		Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

		// Bind the socket to the local endpoint and listen for incoming connections.  
		try
		{
			listener.Bind(localEndPoint);
			listener.Listen(100);

			while (true)
			{
				// Set the event to nonsignaled state.  
				allDone.Reset();

				// Start an asynchronous socket to listen for connections.  
				Console.WriteLine("Waiting for a connection...");
				listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

				// Wait until a connection is made before continuing.  
				allDone.WaitOne();
			}

		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}

		//Console.WriteLine("\nPress ENTER to continue...");
		//Console.Read();

	}

	#endregion

	#region Public Methods

	public static void Start(int Port)
	{
		Task t = new Task(() =>
		{
			StartListening(Port);
		});

		t.Start();
		

		//while (true)
		//{
		//	System.Threading.Thread.Sleep(2);
		//}
	}

	#endregion

	#region Classes

	// By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

	#endregion





}