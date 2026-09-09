namespace MSSV_HoTen_BuilderPattern
{
    public class Product
    {
        private List<string> _parts = new List<string>();
        public void Add(string part) => _parts.Add(part);
        public void Show() => Console.WriteLine("Product parts: " + string.Join(", ", _parts));
    }

    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
        Product GetProduct();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();
        public void Reset() => _product = new Product();
        public void BuildPartA() => _product.Add("PartA1");
        public void BuildPartB() => _product.Add("PartB1");
        public void BuildPartC() => _product.Add("PartC1");
        public Product GetProduct()
        {
            Product result = _product;
            Reset();
            return result;
        }
    }

    public class Director
    {
        private IBuilder _builder;
        public Director(IBuilder builder) => _builder = builder;

        public void BuildMinimalViableProduct() => _builder.BuildPartA();
        public void BuildFullFeaturedProduct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConcreteBuilder();
            var director = new Director(builder);

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            builder.GetProduct().Show();

            Console.WriteLine("\nStandard full featured product:");
            director.BuildFullFeaturedProduct();
            builder.GetProduct().Show();
        }
    }
}