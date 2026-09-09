namespace MSSV_HoTen_SingletonPattern
{
    public sealed class Singleton
    {
        private Singleton() { }
        private static Singleton _instance;
        private static readonly object _lock = new object();

        public static Singleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        public string Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance("FOO");
            Singleton s2 = Singleton.GetInstance("BAR");

            Console.WriteLine($"s1 value: {s1.Value}");
            Console.WriteLine($"s2 value: {s2.Value}");

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
        }
    }
}