namespace MSSV_HoTen_AbstractFactoryPattern
{
    public interface IAbstractProductA { string UsefulFunctionA(); }
    public interface IAbstractProductB { string UsefulFunctionB(); }

    public class ConcreteProductA1 : IAbstractProductA { public string UsefulFunctionA() => "Result of Product A1"; }
    public class ConcreteProductA2 : IAbstractProductA { public string UsefulFunctionA() => "Result of Product A2"; }

    public class ConcreteProductB1 : IAbstractProductB { public string UsefulFunctionB() => "Result of Product B1"; }
    public class ConcreteProductB2 : IAbstractProductB { public string UsefulFunctionB() => "Result of Product B2"; }

    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA() => new ConcreteProductA1();
        public IAbstractProductB CreateProductB() => new ConcreteProductB1();
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA() => new ConcreteProductA2();
        public IAbstractProductB CreateProductB() => new ConcreteProductB2();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client testing Factory 1:");
            ClientMethod(new ConcreteFactory1());

            Console.WriteLine("\nClient testing Factory 2:");
            ClientMethod(new ConcreteFactory2());
        }

        static void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();
            Console.WriteLine(productA.UsefulFunctionA());
            Console.WriteLine(productB.UsefulFunctionB());
        }
    }
}