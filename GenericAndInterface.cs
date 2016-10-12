public class Program
{
    static void Main(string[] args)
    {
        var entity = GetEntity<Organization>(Guid.NewGuid());
        Console.WriteLine(entity.Name);
        Console.ReadLine();
    }
    
    public static T GetEntity<T>(Guid id) where T : class, IEntity
    {
        IEntity result = new Organization { Name = "Some corp." };
        return result as T;
    }
}

public interface IEntity
{
    string Name { get; set; }
}
public class Organization : IEntity
{
    public string Name { get; set; }
}
