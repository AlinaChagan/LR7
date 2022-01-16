using System;
using Laba7.Exceptions;
using System.Diagnostics;

namespace Laba7
{
    public abstract class Inventory
    {
        public Inventory()
        {
            Cost = 300;
        }

        public string Name { get; set; }
        public int Cost { get; set; }

        public virtual void TakeInventoryItem()
        {
            Console.WriteLine("Inventory Item");
        }

        public abstract void SayHelloWorld();
    }

    public class Bench : Inventory, IHelloWorld
    {
        public Bench()
        {
            Name = "Bench";
        }

        public Bench(string name, int cost)
        {
            if (cost > 1000000)
                throw new CostExeption("Cost is too big", "Bench", cost);
            if (name == "Cars")
                throw new InventoryException("Bench can't be named as Cars", "Bench");
            Name = name;
            Cost = cost;
        }

        void IHelloWorld.SayHelloWorld()
        {
            Console.WriteLine("Hello World(Interface)");
        }

        public override void TakeInventoryItem()
        {
            Console.WriteLine("Bench");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello World(abstract)");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name} cost - {Cost}";
        }
    }

    public class Cars : Inventory
    {
        public Cars()
        {
            Name = "Cars";
        }

        public Cars(string name, int cost)
        {
            if (cost > 1000000)
                throw new CostExeption("Cost is too big", "Cars", cost);
            Name = name;
            Cost = cost;
        }

        public override void TakeInventoryItem()
        {
            Console.WriteLine("Bench");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello World from Cars");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name} cost - {Cost}";
        }
    }

    public class Mats : Inventory
    {
        public Mats()
        {
            Name = "Expression ";
        }

        public Mats(string name, int cost)
        {
            if (cost > 1000000)
                throw new CostExeption("Cost is too big", "expression ", cost);
            Name = name;
            Cost = cost;
        }

        public override void TakeInventoryItem()
        {
            Console.WriteLine("The item is expression ");
        }

        public override void SayHelloWorld()
        {
            Console.WriteLine("Hello World from expression  ");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name} cost - {Cost}";
        }

        private struct UnnecessaryStruct
        {
            private int unnecessaryInt;

            public void SaySomethingUnnecessary()
            {
                Console.WriteLine("Bruh");
            }
        } 
    }

    public class BasketballBall : Ball
    {
        public BasketballBall()
        {
            Name = "Default";
            Type = BallType.Basketball;
        }

        public BasketballBall(string name, int cost) : base(name, cost)
        {
            Type = BallType.Basketball;
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name}, type - {Type} cost - {Cost}";
        }
    }

    public sealed class TennisBall : Ball, ITennis
    {
        public TennisBall()
        {
            Name = "Default";
            Type = BallType.Tennisball;
        }

        public TennisBall(string name, int cost) : base(name, cost)
        {
            Type = BallType.Tennisball;
        }

        public void WriteItForTennis()
        {
            Console.WriteLine("It's for tennis");
        }

        public override string ToString()
        {
            return $"It's a {GetType()} name - {Name}, type - {Type}, cost - {Cost}";
        }

        public override bool Equals(object? obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return new Random().Next(0, 100000000);
        }
    }
}




int x = 1;
int y = 0;

    try
        {
            int result = x / y;
        }
    catch (DivideByZeroException) when (y == 0 && x == 0)
        {
            Console.WriteLine("y не должен быть равен 0");
        }
    catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }