public static class StorageSingleton
{
    private static int _counter = 0;
    private static Storage _instance;

    public static Storage GetInstance()
    {
        if (_instance is null)
        {
            _instance = new();
        }

        _counter++;

        return _instance;
    }

    public static void Reset(Storage newStorage)
    {
        _instance = newStorage;
    }
}