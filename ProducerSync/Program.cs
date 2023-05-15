using ConsumerSync;
Console.WriteLine("İşlemek istediğiniz mesaj adetini giriniz");
if (int.TryParse(Console.ReadLine(), out int messageCount))
{
    DataPool.CreateMessages(messageCount);
    Console.WriteLine("Paralel işleme yapılacak Y değilse N");
    var isParallel = Console.ReadLine();
    if (isParallel?.ToLower() == "y")
        new MessageProcesser().ParallelRunner();
    else
        new MessageProcesser().Runner();
}

Console.Read();