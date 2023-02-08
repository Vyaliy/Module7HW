namespace Module7HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Если нужно что-то - пишите
            Console.ReadKey();
        }
    }
    //Использование абстрактных классов
    abstract class Delivery
    {
        //Использование свойств.
        public DateTime deliveryTime;
        public AdressOfBuilding adress;
        public Delivery (DateTime deliveryTime)
        {
            this.deliveryTime = deliveryTime;
        }
    }
    class AdressOfBuilding
    {
        protected string city;
        protected string street;
        protected string house;
        public AdressOfBuilding(string city, string street, string house)
        {
            this.city = city;
            this.street = street;
            this.house = house;
        }
        public void DisplayAdress()
        {
            Console.WriteLine("Город: ", city, "\nУлица: ", street, "\nДом: ", house);
        }
    }
    class HomeAdress : AdressOfBuilding
    {
        protected string flat; //Строка потому что может быть квартира 7А или 7Б к примеру
        public HomeAdress(string city, string street, string house, string flat) : base(city, street, house)
        {
            this.flat = flat;
        }
    }

    //Использование наследовния
    class HomeDelivery : Delivery
    {
        public string phoneNumber;

        public HomeDelivery(string city, string street, string house, string flat, DateTime deliveryTime) : base(deliveryTime)
        {
            this.adress = new HomeAdress(city, street, house, flat);
        }
    }

    class PickPointDelivery : Delivery
    {
        /* ... Я не придумал что сюда поместить...*/
        public PickPointDelivery(string city, string street, string house, DateTime deliveryTime) : base(deliveryTime)
        {
            this.adress = new AdressOfBuilding(city, street, house);
        }
    }

    class ShopDelivery : Delivery
    {
        /* ... Я не придумал что сюда поместить...*/
        public ShopDelivery(string city, string street, string house, DateTime deliveryTime) : base(deliveryTime)
        {
            this.adress = new AdressOfBuilding(city, street, house);
        }
    }
    //Использование обобщений.
    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery delivery;

        public int phoneNumber;

        public string description;

        public List<Product> products;

        public void DisplayAddress()
        {
            delivery.adress.DisplayAdress();
        }

        public Order(TDelivery delivery, int phoneNumber, string description, List<Product> products)
        {
            delivery = delivery;
            phoneNumber = phoneNumber;
            description = description;
            products = products;
        }


        // ... Другие поля
    }
    class Product
    {
        protected string name;
        protected string description;
        protected uint price;
        protected uint quantityInStock;
        protected DateTime dateTimeOfProduction;

        public virtual void DisplayInfo()
        {
            Console.WriteLine(name, "\n", description, "\n", price, "\n", quantityInStock);
        }
        //Использование конструкторов классов с параметрами
        public Product(string name, string description, uint price, uint quantityInStock, DateTime dateTimeOfProduction)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.quantityInStock = quantityInStock;
            this.dateTimeOfProduction = dateTimeOfProduction;
        }
    }
    class ExpirationProduct : Product
    {
        protected DateTime expirationDate;
        protected bool isExpired;

        public ExpirationProduct(DateTime expirationDate, string name, string description, uint price, uint quantityInStock, DateTime dateTimeOfProduction) : base(name, description, price, quantityInStock, dateTimeOfProduction)
        {
            this.expirationDate = expirationDate;
        }

        //Использование переопределения свойств или методов
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine(expirationDate);
            isExpired = DateTimeHelper.NowIsMoreThenDateTime(expirationDate);
            if (isExpired)
            {
                Console.WriteLine($"Просрочено! Срок годности до: {expirationDate}. На данный момент: {DateTime.Now}");
            }
        }
    }
    //Использование статических элементов или классов
    static class DateTimeHelper
    {
        public static bool NowIsMoreThenDateTime(DateTime dt) => DateTime.Now > dt;
    }
}