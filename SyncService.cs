// FR-2 Offline Capture & Automatic Sync (member 2)
using System.Text.Json;

public static class SyncService
{
    public static void LoadQueue()
    {
        if (File.Exists(Store.QueueFile))
            Store.Queue = JsonSerializer.Deserialize<List<Request>>(File.ReadAllText(Store.QueueFile)) ?? new();
    }
    public static void SaveQueue() => File.WriteAllText(Store.QueueFile, JsonSerializer.Serialize(Store.Queue));

    public static void Sync()
    {
        if (!Store.Online || Store.Queue.Count == 0) return;
        Store.Server.AddRange(Store.Queue); Store.Queue.Clear(); SaveQueue();
        Console.WriteLine("Request received by coordinators.");
    }
}
