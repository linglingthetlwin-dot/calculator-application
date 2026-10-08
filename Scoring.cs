// FR-4 Rule-based Priority Scoring (member 3)
public static class Scoring
{
    public static string Score(Request r) =>
        r.Care != "" || r.Type is "Medical" or "Trapped" ? "RED"
        : r.People >= 4 || r.Type == "Evacuation" ? "YELLOW" : "GREEN";

    public static int Rank(Request r) => Score(r) == "RED" ? 0 : Score(r) == "YELLOW" ? 1 : 2;
}
