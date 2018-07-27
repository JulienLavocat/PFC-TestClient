using LiteNetLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static NetPeer server;
	public static NetManager client;
	public static Guid clientId;
	public static bool running = true;

    static void Main(string[] args)
    {
        Console.WriteLine("Starting PFC client.");
        EventBasedNetListener listener = new EventBasedNetListener();
		client = new NetManager(listener, "pfcMasterserver");
        client.Start();
        //server = client.Connect("localhost", 9100);
		
        listener.NetworkReceiveEvent += (fromPeer, dataReader) =>
        {
			switch (dataReader.GetByte())
			{
				case 0:	//Login confirm
					clientId = new Guid(dataReader.GetRemainingBytes());
					Console.WriteLine("Assigned client uuid is : " + clientId);
					break;

				case 1:	//Match found

					break;
			}
        };

		Thread t = new Thread(PollConsole);
		t.Start();

        while (running)
        {
            client.PollEvents();
            Thread.Sleep(150);
        }

        client.Stop();

    }

	static void PollConsole()
	{
		while(running)
		{
			Console.Write("Command > ");
			string[] args = Console.ReadLine().Split(' ');

			if(args[0] == "stop")
			{
				Console.WriteLine("Stopping client...");
				running = false;
			}
			
			if(args[0] == "connect")
			{
				Console.WriteLine("Connecting to masterserver...");
				server = client.Connect("localhost", 9100);
				Thread.Sleep(1000);
				Console.WriteLine("Connection state : " + server.ConnectionState);
			}

			if(args[0] == "join")
			{
				bool ranked = (args[1] == "r");
				if (ranked)
					Console.WriteLine("Joining ranked match.");
				else
					Console.WriteLine("Joining normal match.");
				server.Send(PClient.JoinQueue(ranked), SendOptions.ReliableOrdered);
			}

		}
	}

}
