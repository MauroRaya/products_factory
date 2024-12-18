namespace ProductsFactory {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Choose one of the below:");
            Console.WriteLine("1. Chair");
            Console.WriteLine("2. Sofa");
            Console.WriteLine("3. Table");

            if (!int.TryParse(Console.ReadLine(), out int productChoice)) {
                throw new InvalidOperationException();
            }

            IProductFactory productFactory = productChoice switch {
                1 => new ChairFactory(),
                2 => new SofaFactory(),
                3 => new TableFactory(),
                _ => throw new InvalidOperationException(),
            };

            var product = productFactory.CreateProduct();

            product.Describe();
            Console.WriteLine(product.GetType());
        }

        interface IProduct {
            void Describe();
        }

        class Chair : IProduct {
            public void Describe() => Console.WriteLine("This is a chair aye");
        }
        class Sofa : IProduct {
            public void Describe() => Console.WriteLine("I'm a sofa yo");
        }
        class Table : IProduct {
            public void Describe() => Console.WriteLine("Just a table doing table things");
        }

        interface IProductFactory {
            IProduct CreateProduct();
        }

        class ChairFactory : IProductFactory {
            public IProduct CreateProduct() => new Chair();
        }
        class SofaFactory : IProductFactory {
            public IProduct CreateProduct() => new Sofa();
        }
        class TableFactory : IProductFactory {
            public IProduct CreateProduct() => new Table();
        }
    }
}