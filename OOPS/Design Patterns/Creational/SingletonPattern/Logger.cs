public sealed class Logger
{
    private static Logger logger = null;
    private static readonly object _lock = new object();
    private Logger()
    {

    }

    public static Logger GetInstance()
    {
        if (logger == null)
        {
            lock (_lock)
            {
                if (logger == null)
                {
                    logger = new Logger();

                }
            }
        }
        return logger;
    }
    public void Log(string message)
    {
        System.Console.WriteLine($"{message}");
    }
}