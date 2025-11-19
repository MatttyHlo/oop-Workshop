interface IDownloadable
{
    void Download(string url)
    {
        Console.WriteLine($"Downloading from {url}...");
    }
}