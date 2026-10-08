// Shared data model + in-memory "server" and phone queue
public record Request(int Id, string Name, string Phone, string Type, int People, string Care, double Lat, double Lon, string Status);

public static class Store
{
    public static List<Request> Server = new();   // stands in for the server database
    public static List<Request> Queue = new();    // offline queue on the victim's phone
    public static bool Online = true;
    public const string QueueFile = "offline_queue.json";
}
