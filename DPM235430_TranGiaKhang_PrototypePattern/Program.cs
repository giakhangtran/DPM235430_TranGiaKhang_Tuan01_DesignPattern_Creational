namespace MSSV_HoTen_PrototypePattern
{
    public abstract class Prototype
    {
        public string Id { get; }
        public Prototype(string id) => Id = id;
        public abstract Prototype Clone();
    }

    public class ConcretePrototype : Prototype
    {
        public string Data { get; set; }
        public ConcretePrototype(string id, string data) : base(id) => Data = data;

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new ConcretePrototype("001", "Initial Config");
            var c1 = (ConcretePrototype)p1.Clone();

            Console.WriteLine($"Original: Id={p1.Id}, Data={p1.Data}");
            Console.WriteLine($"Cloned:   Id={c1.Id}, Data={c1.Data}");

            c1.Data = "Modified Config";
            Console.WriteLine($"After change -> Original: {p1.Data} | Cloned: {c1.Data}");
        }
    }
}