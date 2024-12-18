namespace ProductsFactory {
    internal class Program {
        static void Main(string[] args) {
            ProductFactory.Register(1, "Chair", () => new Chair());
            ProductFactory.Register(2, "Sofa", () => new Sofa());
            ProductFactory.Register(3, "Table", () => new Table());

            Console.WriteLine("Choose one of the below:");
            ProductFactory.DisplayProducts();

            if (!int.TryParse(Console.ReadLine(), out int productChoice)) {
                throw new InvalidOperationException();
            }

            var product = ProductFactory.GetProduct(productChoice);

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

        static class ProductFactory {
            private static Dictionary<int, (string Name, Func<IProduct> Factory)> _products = new();

            public static void Register(int key, string name, Func<IProduct> factory) {
                if (_products.ContainsKey(key)) {
                    throw new Exception();
                }
                _products[key] = (name, factory);
            }

            public static void DisplayProducts() { 
                foreach (var product in _products) {
                    Console.WriteLine($"{product.Key} - {product.Value.Name}");
                }
            }

            public static IProduct GetProduct(int key) {
                if (_products.TryGetValue(key, out var tuple)) {
                    return tuple.Factory();
                }
                throw new Exception();
            }
        }
    }
}