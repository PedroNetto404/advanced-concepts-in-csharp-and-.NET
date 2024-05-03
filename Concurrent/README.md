# Concurrent Programming
Concurrent programming is a programming technique that allows multiple threads to execute concurrently. It is used to take advantage of multi-core processors to increase the speed of program execution. Concurrent programming can be implemented using the Task Parallel Library (TPL) in .NET.

## Task Parallel Library (TPL)
The Task Parallel Library (TPL) is a set of types and APIs in the System.Threading.Tasks namespace that simplifies the process of adding parallelism and concurrency to applications. The TPL provides a task-based programming model that enables you to write asynchronous and parallel code more easily. The TPL is used in conjunction with the async and await keywords in C# to write asynchronous code.

```C#
    // Example of concurrent programming using TPL
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            Parallel.For(0, 10, Work);
        }

        // This method is called by the parallel loop and start a new thread to execute the Work method.
        public static void Work(int i) =>
            Console.WriteLine(i);
    }
```

## References
- [Task Parallel Library (TPL)](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl)