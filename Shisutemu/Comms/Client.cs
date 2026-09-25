using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;


public class Client
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

	// The port number for the remote device.  
	private static int _port = 11000;

	// ManualResetEvent instances signal completion.  
	private static ManualResetEvent _connectComplete = new ManualResetEvent(false);
	private static ManualResetEvent _sendComplete = new ManualResetEvent(false);
	private static ManualResetEvent _receiveComplete = new ManualResetEvent(false);

	// The response from the remote device.  
	private static String _response = String.Empty;

	private static Socket _Socket = null;

	#endregion

	#region Properties

	public string Response
	{
		get
		{
			return _response;
		}
	}

	#endregion

	#region Constructors and Destructor

	#endregion

	#region Event Handlers

	private static void ConnectCallback(IAsyncResult asyncResult)
	{
		try
		{
			// Retrieve the socket from the state object.  
			Socket client = (Socket)asyncResult.AsyncState;

			// Complete the connection.  
			client.EndConnect(asyncResult);

			Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());

			// Signal that the connection has been made.  
			_connectComplete.Set();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static void Receive(Socket socket)
	{
		try
		{
			// Create the state object.  
			CommState state = new CommState();
			state.Socket = socket;

			// Begin receiving the data from the remote device.  
			socket.BeginReceive(state.ReceiveBuffer, 0, CommState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static void ReceiveCallback(IAsyncResult asyncResult)
	{
		try
		{
			// Retrieve the state object and the client socket   
			// from the asynchronous state object.  
			CommState state = (CommState)asyncResult.AsyncState;
			Socket socket = state.Socket;

			// Read data from the remote device.  
			int bytesRead = socket.EndReceive(asyncResult);

			if (bytesRead > 0)
			{
				// There might be more data, so store the data received so far.  
				state.ReceivedData.Append(Encoding.ASCII.GetString(state.ReceiveBuffer, 0, bytesRead));

				// Get the rest of the data.  
				socket.BeginReceive(state.ReceiveBuffer, 0, CommState.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
			}
			else
			{
				// All the data has arrived; put it in response.  
				if (state.ReceivedData.Length > 1)
				{
					_response = state.ReceivedData.ToString();
				}
				// Signal that all bytes have been received.  
				_receiveComplete.Set();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	private static void InternalSend(String data)
	{
		// Convert the string data to byte data using ASCII encoding.  
		byte[] byteData = Encoding.ASCII.GetBytes(data);

		// Begin sending the data to the remote device.  
		_Socket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), _Socket);
	}

	private static void SendCallback(IAsyncResult asyncResult)
	{
		try
		{
			// Retrieve the socket from the state object.  
			Socket client = (Socket)asyncResult.AsyncState;

			// Complete sending the data to the remote device.  
			int bytesSent = client.EndSend(asyncResult);
			Console.WriteLine("Sent {0} bytes to server.", bytesSent);

			// Signal that all bytes have been sent.  
			_sendComplete.Set();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	#endregion

	#region Private Methods



	#endregion

	#region Public Methods

	public static void Start(string RemoteHostname, int RemotePort)
	{
		_port = RemotePort;

		// Connect to a remote device.  
		try
		{
			// Establish the remote endpoint for the socket.   
			IPHostEntry ipHostInfo = Dns.GetHostEntry(RemoteHostname);
			IPAddress ipAddress = ipHostInfo.AddressList[0];
			IPEndPoint remoteEP = new IPEndPoint(ipAddress, _port);

			// Create a TCP/IP socket.  
			_Socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			// Connect to the remote endpoint.  
			_Socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), _Socket);
			_connectComplete.WaitOne();

			//// Send test data to the remote device.  
			//InternalSend("This is a test<EOF>");
			//_sendComplete.WaitOne(); // <== Wait for a response

			//// Receive the response from the remote device.  
			//Receive(_Socket);
			//_receiveComplete.WaitOne(); // <== Wait for a response

			//// Write the response to the console.  
			//Console.WriteLine("Response received : {0}", _response);

			//// Release the socket.  
			//_Socket.Shutdown(SocketShutdown.Both);
			//_Socket.Close();

		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}

	public static void Stop()
	{
		// Release the socket.  
		_Socket.Shutdown(SocketShutdown.Both);
		_Socket.Close();
	}

	public static void Send(string Data)
	{
		// Send test data to the remote device.  
		InternalSend("This is a test<EOF>");
		_sendComplete.WaitOne(); // <== Wait for a response

		// Receive the response from the remote device.  
		Receive(_Socket);
		_receiveComplete.WaitOne(); // <== Wait for a response

		// Write the response to the console.  
		Console.WriteLine("Response received : {0}", _response);
	}

	#endregion

	#region Classes

	// By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

	#endregion



}