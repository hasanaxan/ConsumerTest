// See https://aka.ms/new-console-template for more information
using ProducerSync;

//Console.WriteLine("Hello, World!");

//Console.WriteLine(DataPool.Messages.Count);
//Console.WriteLine(DataPool.Messages.Count);

DataPool.CreateMessages();

new MessageProcesserTask().Runner();


Console.Read();