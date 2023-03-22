// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

//Console.WriteLine(DataPool.Messages.Count);
//Console.WriteLine(DataPool.Messages.Count);

using ConsumerAsync;

DataPool.CreateMessages();
new MessageProcesserTask().Runner();

Console.Read();