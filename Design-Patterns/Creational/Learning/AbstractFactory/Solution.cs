// Abstract Product Interfaces
public interface IButton
{
    void Paint();
}

public interface ICheckbox
{
    void Paint();
}

// Concrete Product Implementations
public class WinButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in a Windows style.");
    }
}

public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Rendering a button in a MacOS style.");
    }
}

public class WinCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Rendering a checkbox in a Windows style.");
    }
}

public class MacCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Rendering a checkbox in a MacOS style.");
    }
}

// Abstract Factory Interface
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Concrete Factory Implementations
public class WinFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WinButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WinCheckbox();
    }
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

// Client Application
public class Application
{
    private IButton button;
    private ICheckbox checkbox;

    public Application(IGUIFactory factory)
    {
        button = factory.CreateButton();
        checkbox = factory.CreateCheckbox();
    }

    public void Render()
    {
        button.Paint();
        checkbox.Paint();
    }
}
