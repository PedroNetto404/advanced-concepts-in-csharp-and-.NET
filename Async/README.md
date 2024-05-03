### Asyncronous
Asyncronous programming style is a way to write code that can perform long-running operations without blocking the main thread. This is useful when you want your application to remain responsive to user input while it performs work in the background. 

- In UI applications, asyncronous programming is useful when you want to keep the UI thread responsive to user input while performing work in the background.
- In server applications, asyncronous programming is useful when you want to process multiple requests while you wait for responses from external resources like databases queries, web services, I/O operations, etc. ASP.NET Core is a good example of a server application that uses asyncronous programming to process multiple requests concurrently. A action method in a controller can return a Task object to represent an asyncronous operation. A part of ASP.NET Core that receives a Action Task can be used to process other requests while the Task is running.

### .NET Asynchronous Programming Models

1. **Event-based Asynchronous Pattern (EAP)**
This model is based on the event pattern. It uses the Event-based Asynchronous Pattern (EAP) to provide asynchronous operations. In this model, the class that provides the asynchronous operation exposes a pair of methods that are named in the form of BeginOperationName and EndOperationName. The BeginOperationName method starts the operation and returns immediately. The EndOperationName method is called when the operation completes. The EAP model is based on the IAsyncResult interface.

2. **Asynchronous Programming Model (APM)**
This model is based on the IAsyncResult interface. It uses the Asynchronous Programming Model (APM) to provide asynchronous operations. In this model, the class that provides the asynchronous operation exposes a pair of methods that are named in the form of BeginOperationName and EndOperationName. The BeginOperationName method starts the operation and returns immediately. The EndOperationName method is called when the operation completes. The APM model is based on the IAsyncResult interface.

3. **Task-based Asynchronous Pattern (TAP)**
The most recent model and the recommended model for asynchronous programming in .NET is the Task-based Asynchronous Pattern (TAP). This model is based on the Task and **Task<TResult>** types in the System.Threading.Tasks namespace. The TAP model is easier to use than the EAP and APM models. It provides better support for exception handling, resource management, and composition of asynchronous operations. The TAP model is used in the **async** and **await** keywords in C#.

Example:
```C#
    public async Task<int> GetPageLengthAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            Task<string> fetchTextTask = client.GetStringAsync(url);
            string text = await fetchTextTask;
            return text.Length;
        }
    }
```
Note: when execution flow reaches the await keyword, the method returns to the caller. When the asynchronous operation completes, the method resumes execution at the await keyword.

You can be operation like this:
```C#
    // Observations: GetPageLengthAsync run synchronously until the await keyword is reached.
    Task<int> task = GetPageLengthAsync("http://www.example.com");

    SomeOtherWork();

    // Wait for the task to complete
    int length = await task;

    HandleResult(length);
```

**IMPORTANT** Please, avoid using blocking calls like **Task.Wait()** or **Task.Result** in asyncronous methods. This can cause **deadlocks in your application**.
```C#
    public async Task<int> GetPageLengthAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            Task<string> fetchTextTask = client.GetStringAsync(url);
            // Don't do this. It blocks the current thread until the task completes.
            string text = fetchTextTask.Result; 
            return text.Length;
        }
    }

```

# References
- [Asynchronous programming with async and await](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)