// FR-1 Victim Request Logging (member 1)
public static class VictimApp
{
    public static void SendRequest()
    {
        Console.Write("Name: "); var name = Console.ReadLine() ?? "Unknown";
        Console.Write("Phone: "); var phone = Console.ReadLine() ?? "";
        Console.Write("Type (1 Trapped, 2 Medical, 3 Food/Water, 4 Evacuation): ");
        var type = Console.ReadLine() switch { "1" => "Trapped", "2" => "Medical", "3" => "Food/Water", _ => "Evacuation" };
        Console.Write("People: "); int people = int.TryParse(Console.ReadLine(), out var n) ? Math.Max(n, 1) : 1;
        Console.Write("Care flags (b=bedridden i=infant e=elderly, blank=none): "); var care = Console.ReadLine() ?? "";
        var rnd = Random.Shared;   // GPS is simulated in this prototype
        var r = new Request(Store.Server.Count + Store.Queue.Count + 1, name, phone, type, people, care,
                            18.72 + rnd.NextDouble() * .1, 100.72 + rnd.NextDouble() * .1, "New");
        Store.Queue.Add(r);
        SyncService.SaveQueue();
        Console.WriteLine(Store.Online ? "Sending..." : "Offline: saved on device, will sync automatically.");
        SyncService.Sync();
    }
}
