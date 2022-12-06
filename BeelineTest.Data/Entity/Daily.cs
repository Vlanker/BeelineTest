namespace BeelineTest.Data.Entity;

public class Daily
{
    public DateTime Date { get; set; }
    public DateTime PreviousDate { get; set; }
    public string PreviousUrl { get; set; } = null!;
    public DateTime Timestamp { get; set; }
    public Dictionary<string, Valute> Valute { get; set; } = null!;
}