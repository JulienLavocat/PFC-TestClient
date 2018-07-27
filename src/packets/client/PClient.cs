using LiteNetLib.Utils;
using System;

class PClient
{

    public static NetDataWriter JoinQueue(bool ranked)
    {
        NetDataWriter writer = new NetDataWriter();
		byte id = 1;
		byte mode = Convert.ToByte(ranked);
        writer.Put(id);
		writer.Put(mode);
		Console.WriteLine("Mode id is " + mode);
        return writer;
    }

}
