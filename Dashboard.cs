// FR-3 Coordinator Live List with Filters (member 4)
public static class Dashboard
{
    public static void Show()
    {
        Console.Write("Filter (RED/YELLOW/GREEN, blank=all): "); var f = (Console.ReadLine() ?? "").ToUpper();
        var rows = Store.Server.Where(r => f == "" || Scoring.Score(r) == f).OrderBy(Scoring.Rank).ToList();
        foreach (var r in rows)
        {
            var s = Scoring.Score(r);
            Console.ForegroundColor = s switch { "RED" => ConsoleColor.Red, "YELLOW" => ConsoleColor.Yellow, _ => ConsoleColor.Green };
            Console.WriteLine($"#{r.Id,-3} [{s,-6}] {r.Name,-10} {r.Type,-10} {r.People} ppl care:{(r.Care == "" ? "-" : r.Care),-4} {r.Status,-10} ({r.Lat:F3},{r.Lon:F3}) tel:{r.Phone}");
            Console.ResetColor();
        }
        if (rows.Count == 0) Console.WriteLine("No requests.");
    }
}
