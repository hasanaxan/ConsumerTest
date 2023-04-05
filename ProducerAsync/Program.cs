// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine(DataPool.Messages.Count);
//Console.WriteLine(DataPool.Messages.Count);
using ConsumerAsync;
Console.WriteLine("İşlemek istediğiniz mesaj adetini giriniz");
if (int.TryParse(Console.ReadLine(), out int messageCount))
{
    DataPool.CreateMessages(messageCount);
    new MessageProcesser().Runner();
}
Console.Read();