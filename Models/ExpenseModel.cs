namespace ExpenseTracker.Models;

public class ExpenseModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Date { get; set; }
    public string Spent { get; set; }
    public List<string> CategoryIds { get; set; }  
}