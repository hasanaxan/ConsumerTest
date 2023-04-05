using ConsumerAsync;
Console.WriteLine("İşlemek istediğiniz mesaj adetini giriniz");
if (int.TryParse(Console.ReadLine(), out int messageCount))
{
    DataPool.CreateMessagesAsync(messageCount);
    new MessageProcesser().RunnerAsync();
}
Console.Read();