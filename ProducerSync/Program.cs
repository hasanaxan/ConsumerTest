using ConsumerSync;
Console.WriteLine("İşlemek istediğiniz mesaj adetini giriniz");
if (int.TryParse(Console.ReadLine(), out int messageCount))
{
    DataPool.CreateMessages(messageCount);
    new MessageProcesser().Runner();
}
Console.Read();