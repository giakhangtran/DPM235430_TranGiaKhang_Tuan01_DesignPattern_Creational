namespace MSSV_HoTen_FactoryPattern
{
    // 1. Product Interface
    public interface IProduct
    {
        string Operation();
    }

    // 2. Concrete Products
    public class ConcreteProductA : IProduct
    {
        public string Operation() => "{Result of ConcreteProductA}";
    }

    public class ConcreteProductB : IProduct
    {
        public string Operation() => "{Result of ConcreteProductB}";
    }

    // 3. Creator (Factory)
    public abstract class Creator
    {
        public abstract IProduct FactoryMethod();

        public string SomeOperation()
        {
            var product = FactoryMethod();
            return "Creator: Working with " + product.Operation();
        }
    }

    // 4. Concrete Creators
    public class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProductA();
    }

    public class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod() => new ConcreteProductB();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App: Launched with ConcreteCreatorA.");
            ClientCode(new ConcreteCreatorA());

            Console.WriteLine("\nApp: Launched with ConcreteCreatorB.");
            ClientCode(new ConcreteCreatorB());
        }

        static void ClientCode(Creator creator)
        {
            Console.WriteLine(creator.SomeOperation());
        }
    }
}