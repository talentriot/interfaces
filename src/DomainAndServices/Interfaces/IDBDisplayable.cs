namespace DomainAndServices.Interfaces
{
    public interface IDBDisplayable
    {
        int Id { get; set; }
        string Name { get; }
        int Index { get; set; }
    }
}
