namespace TestProject;

public class TaskExample{

    private const int N = 100;
    private const int COUNT_OF_THREADS = 5;
    private int[] arr = new int[N];
    private Task[] threads = new Task[COUNT_OF_THREADS];

    public async Task Execute(){

        for(int i = 0; i < N; i++)
            arr[i] = i;

        int count = N / COUNT_OF_THREADS;

        for(int i = 0; i < COUNT_OF_THREADS; i ++){

            int start = i * count;
            int max = start + count;
            threads[i] = Print(start, max, i);

        }

        for(int i = 0; i < COUNT_OF_THREADS; i ++)
            await threads[i];

    }

    private async Task Print(int start, int max, int id){

        for(; start < max; start ++){
                Console.WriteLine($"Task #{id} say {arr[start]}");
                Thread.Sleep(100);
        }

    }


}