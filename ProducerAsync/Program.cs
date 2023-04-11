using ConsumerAsync;

Console.WriteLine("İşlemek istediğiniz mesaj adetini giriniz");
if (int.TryParse(Console.ReadLine(), out int messageCount))
{
    new MessageProcesser().RunnerAsync();
    DataPool.CreateMessagesAsync(messageCount);

}
Console.Read();