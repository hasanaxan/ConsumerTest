// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Task<int> task1 = new Task<int>(() =>
{
    Task.Delay(1000);
    Console.WriteLine("Task Ok");
    return 5;
});

Task tracker = new Task(() =>
{
    while (true)
    {
        //if (task1.Status == TaskStatus.RanToCompletion)
        //    Console.WriteLine(task1.Result);
        Console.WriteLine(task1.Status);
        Task.Delay(500);
    }
});

tracker.Start();
//task1.Start();
