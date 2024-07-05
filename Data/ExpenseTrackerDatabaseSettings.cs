namespace ExpenseTracker.Models;

public class ExpenseTrackerDatabaseSettings
{
    public string DatabaseName { get; set; } = null!;
    public string ExpenseCollectionName { get; set; } = null!;
    public string CategoryCollectionName { get; set; } = null!;
}