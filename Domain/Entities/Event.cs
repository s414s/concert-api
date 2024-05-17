namespace Domain.Entities;

public class Event
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string ZipCode { get; set; }
    public int Capacity { get; set; }
    public bool OnlyAdults { get; set; }
}
