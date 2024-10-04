public sealed class Logger
{

    private static Logger _instance;
    private readonly static object obj = new object();
    private Logger() { }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            lock (obj)
            {
                _instance ??= new Logger();
            }

        }
        return _instance;
    }

}