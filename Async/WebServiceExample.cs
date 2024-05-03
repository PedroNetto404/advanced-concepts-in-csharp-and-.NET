namespace Sandbox.Threads__AsyncAwait__Parallel;

public static class AsyncAwait
{
    public static async Task RunExample()
    {
        Console.WriteLine($"Thread principal: {Thread.CurrentThread.ManagedThreadId}");

        await DownloadConteudoAsync();

        Console.WriteLine($"Fim do método Main na thread: {Thread.CurrentThread.ManagedThreadId}");
    }

    private static async Task DownloadConteudoAsync()
    {
        Console.WriteLine($"Início do método assíncrono na thread: {Thread.CurrentThread.ManagedThreadId}");

        var urls = new List<string>
        {
            "https://www.example.com",
            "https://www.example.org",
            "https://www.example.net"
        };

        var downloadTasks = urls.Select(s =>
        {
            Console.WriteLine($"Iniciando download de {s} na thread: {Thread.CurrentThread.ManagedThreadId}");
            return DownloadAsync(s);
        }).ToList();
    
        var resultados = await Task.WhenAll(downloadTasks);
    
        Console.WriteLine($"Fim do método assíncrono na thread: {Thread.CurrentThread.ManagedThreadId}");
    
        foreach (var resultado in resultados) Console.WriteLine(resultado);
    }

    private static async Task<string> DownloadAsync(string url)
    {
        Console.WriteLine($"Iniciando download de {url} na thread: {Thread.CurrentThread.ManagedThreadId}");

        using var client = new HttpClient();
        var conteudo = await client.GetStringAsync(url);

        Console.WriteLine($"Download concluído de {url} na thread: {Thread.CurrentThread.ManagedThreadId}");

        return conteudo;
    }
}