// Entry point / main menu (team lead)
SyncService.LoadQueue();
while (true)
{
    Console.WriteLine($"\n=== Disaster Assistance === [{(Store.Online ? "ONLINE" : "OFFLINE")}] queued on phone: {Store.Queue.Count}");
    Console.WriteLine("1) Victim: send request   2) Toggle network   3) Coordinator: dashboard   4) Coordinator: update case   0) Exit");
    switch (Console.ReadLine())
    {
        case "1": VictimApp.SendRequest(); break;
        case "2": Store.Online = !Store.Online; SyncService.Sync(); break;
        case "3": Dashboard.Show(); break;
        case "4": CaseManager.Update(); break;
        case "0": return;
    }
}
