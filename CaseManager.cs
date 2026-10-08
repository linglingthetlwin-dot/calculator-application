// FR-5 Contact Victim & Case Status (member 5)
public static class CaseManager
{
    public static void Update()
    {
        Console.Write("Case id: "); if (!int.TryParse(Console.ReadLine(), out var id)) return;
        var i = Store.Server.FindIndex(r => r.Id == id);
        if (i < 0) { Console.WriteLine("Not found."); return; }
        Console.Write("Status (Verified/Dispatched/Rescued/FalseReport): ");
        Store.Server[i] = Store.Server[i] with { Status = Console.ReadLine() ?? "Verified" };
        Console.WriteLine($"Calling {Store.Server[i].Phone}... status set to {Store.Server[i].Status}.");
    }
}
