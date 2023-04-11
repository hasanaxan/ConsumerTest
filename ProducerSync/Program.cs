using ConsumerSync;
Console.WriteLine("İşlemek istediğiniz mesaj adetini giriniz");
if (int.TryParse(Console.ReadLine(), out int messageCount))
{
    new MessageProcesser().Runner();
    DataPool.CreateMessages(messageCount);
   
}
Console.Read();