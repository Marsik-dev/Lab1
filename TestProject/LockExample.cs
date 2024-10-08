namespace TestProject;

public class LockExample{

    private const int N = 100;
    private const int COUNT_OF_THREADS = 5;
    private int[] arr = new int[N];
    private Thread[] threads = new Thread[COUNT_OF_THREADS];

    public async Task Execute(){

        for(int i = 0; i < N; i++)
            arr[i] = i;

        int count = N / COUNT_OF_THREADS;

        for(int i = 0; i < COUNT_OF_THREADS; i ++){

            int start = i * count;
            int max = start + count;
            threads[i] = new Thread(() => Print(start, max));
            threads[i].Name = i.ToString();
            threads[i].Start();

        }

        for(int i = 0; i < COUNT_OF_THREADS; i ++)
            threads[i].Join();

    }

    private void Print(int start, int max){

        for(; start < max; start ++)
            lock(arr)
                Console.WriteLine($"Thread #{Thread.CurrentThread.Name} say {arr[start]}");

    }

}