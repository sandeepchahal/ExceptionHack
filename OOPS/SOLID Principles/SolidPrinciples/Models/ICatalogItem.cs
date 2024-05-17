namespace SolidPrinciples.Models;

public interface IItem
{
    public string Title { get;}
}

public interface ICheckout: IItem
{
    public bool IsAvailable { get;}  
}

public interface INonCheckout:IItem
{
    public bool IsAssigned { get;}
}
