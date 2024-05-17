namespace Application.DTOs;

public class EventDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ZipCode { get; set; }
    public int Capacity { get; set; }
    public bool OnlyAdults { get; set; }
}
