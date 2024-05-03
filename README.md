# Threads, Asyncronous Programming, Parallel Programming

# Core concepts

## Process :computer:
A process is an instance of a program that is being executed. It contains the program code and its current activity. Depending on the operating system (OS), a process may be made up of multiple threads of execution that execute instructions concurrently.

### Learnig with linux :penguin:
1. **Start a example process**
```bash
    code &
```

2. **See infomation about process**
```bash
    ps -aux | grep code
```
2.1 You can see Process ID (PID), Parent Process ID (PPID), CPU usage, Memory usage, etc. Register PID, we will use it later.

3. **Kill a process**
```bash
    kill -9 PID
```

4. **See process tree**: It's a amazing command that show all process in a tree format graph! :deciduous_tree:
```bash
    pstree
```

## Thread :thread:
A thread is the smallest unit of execution that can be scheduled by an operating system. A thread is a component of a process. Multiple threads can exist within the same process and share resources such as memory, while different processes do not share these resources.

### Learnig with linux :penguin:
1. **Start a example process**
```bash
    code &
```
2. **See all threads of a process**
```bash
    ps -T -p [PID]
```
- Note SPID is the thread ID (TID), register it.

3. **Send a signal to a thread**
```bash
    kill -9 TID
```

## Asyncronous Programming :hourglass_flowing_sand:
Asyncronous programming style is a way to write code that can perform long-running operations without blocking the main thread. This is useful when you want your application to remain responsive to user input while it performs work in the background.

## Parallel Programming :computer: :computer: :computer:
In computer science, parallel programming is a type of computation in which many calculations or processes are carried out simultaneously. Large problems can often be divided into smaller ones, which can then be solved at the same time. There are several different forms of parallel computing: bit-level, instruction-level, data, and task parallelism.

## Concurrent Programming

It's a type of parallel programming that allows multiple threads to execute concurrently. Different from parallel programming, concurrent programming is used with shared resources and synchronization mechanisms to ensure that threads do not interfere with each other.

### The main techniques and concepts used in concurrent programming are:
- **Locks/Mutexes**: These are synchronization primitives used to prevent multiple threads from accessing the critical section of code simultaneously.
- **Semaphores**: These are more general than mutexes and can be used to control access to a given resource by multiple processes.
- **Deadlocks**: A situation where two or more processes are unable to proceed because each is waiting for the other to release resources.

If you want to lean more, see [Dinner Philosophers Problem](https://en.wikipedia.org/wiki/Dining_philosophers_problem)

# References

## C# and .NET
- [Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/standard/async-in-depth)
- [How Thread Works?](https://en.wikipedia.org/wiki/Thread_(computing))
- [How Process Works](https://en.wikipedia.org/wiki/Process_(computing))
- [Asyncronous Programming](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)
- [Parallel Programming](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/)
- [Concurrent Programming](https://docs.microsoft.com/en-us/dotnet/standard/concurrency-and-asynchrony/)
- [.NET Tutorials](https://dotnettutorials.net/)

## Linux
- [Linux Commands](https://www.tecmint.com/linux-commands-cheat-sheet/)
- [Linux Process Management](https://www.tecmint.com/linux-process-management/)
- [Linux Threads](https://www.tecmint.com/linux-thread-management/)