namespace Sandbox.Threads__AsyncAwait__Parallel;

public static class AsyncAwait
{
    public static async Task RunExample()
    {
        Console.WriteLine(
            $"{DateTime.Now.GetTodayFormattedTime()} - Thread that running RunExample method before await keyword: {Thread.CurrentThread.ManagedThreadId}");

        var downloadTask = DownloadContentAsync();

        Console.WriteLine(
            $"{DateTime.Now.GetTodayFormattedTime()} - " + 
            "Execution flow continues in thread: {Thread.CurrentThread.ManagedThreadId}" + 
            "because await keyword was reached");

        // return execution flow to the caller
        await downloadTask;

        Console.WriteLine(
            $"{DateTime.Now.GetTodayFormattedTime()} - Thread that running RunExample method after await keyword: {Thread.CurrentThread.ManagedThreadId}");
    }

    private static async Task DownloadContentAsync()
    {
        Console.WriteLine(
            $"{DateTime.Now.GetTodayFormattedTime()} - Thread that running DownloadConteudoAsync method before await keyword: {Thread.CurrentThread.ManagedThreadId}");

        var urls = new List<string>
        {
            "https://www.example.com",
            "https://www.example.org",
            "https://www.example.net"
        };

        var downloadTasks = urls.Select(async s =>
        {
            Console.WriteLine(
                $"{DateTime.Now.GetTodayFormattedTime()} - Starting download of {s} in thread: {Thread.CurrentThread.ManagedThreadId}");
           
            var content = await DownloadAsync(s);

            Console.WriteLine(
                $"{DateTime.Now.GetTodayFormattedTime()} - Download completed of {s} in thread: {Thread.CurrentThread.ManagedThreadId}");

            return content;
        }).ToList();

        var results = await Task.WhenAll(downloadTasks);

        Console.WriteLine(
            $"{DateTime.Now.GetTodayFormattedTime()} - Thread that running DownloadConteudoAsync method after await keyword: {Thread.CurrentThread.ManagedThreadId}");

        foreach (var result in results) Console.WriteLine(result);
    }

    private static async Task<string> DownloadAsync(string url)
    {
        Console.WriteLine(
            $"{DateTime.Now.GetTodayFormattedTime()} - Starting download of {url} in thread: {Thread.CurrentThread.ManagedThreadId}");

        using var client = new HttpClient();
        var content = await client.GetStringAsync(url);

        Console.WriteLine(
            $"{DateTime.Now.GetTodayFormattedTime()} - Download completed of {url} in thread: {Thread.CurrentThread.ManagedThreadId}");

        return content;
    }
}