namespace TestProject;

public class MutexExample{

    private Mutex mutex = new Mutex();

    private const int N = 100;
    private const int COUNT_OF_THREADS = 5;
    private int[] arr = new int[N];
    private Thread[] threads = new Thread[COUNT_OF_THREADS];

    private int sleepTime, startDelay;

    public async Task Execute(){

        for(int i = 0; i < N; i++)
            arr[i] = i;

        int count = N / COUNT_OF_THREADS;

        string? str;

        do{

            Console.Clear();

            Console.Write("Введите задежку вывода в мс: ");
            str = Console.ReadLine();

        }while(!int.TryParse(str, out sleepTime));

        do{

            Console.Clear();

            Console.Write("Введите задежку старта запуска в мс: ");
            str = Console.ReadLine();

        }while(!int.TryParse(str, out startDelay));


        for(int i = 0; i < COUNT_OF_THREADS; i ++){

            int start = i * count;
            int max = start + count;
            threads[i] = new Thread(() => Print(start, max));
            threads[i].Name = i.ToString();
            threads[i].Start();
            Thread.Sleep(startDelay);

        }

        for(int i = 0; i < COUNT_OF_THREADS; i ++)
            threads[i].Join();

    }

    private void Print(int start, int max){


        if(!mutex.WaitOne(1000, false)){

            Console.WriteLine($"Thread #{Thread.CurrentThread.Name} was blocked by another thread");
            return;

        }
        for(; start < max; start ++){
            
            Console.WriteLine($"Thread #{Thread.CurrentThread.Name} say {arr[start]}");
            Thread.Sleep(sleepTime);
            
        }
        
        mutex.ReleaseMutex();
        

    }


}