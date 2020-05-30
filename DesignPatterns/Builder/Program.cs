using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Pattern for constructing complex objects
/// </summary>
namespace Builder
{
    class Program
    {
        /// <summary>
        /// The Client
        /// </summary>        
        static void Main(string[] args)
        {
            var superBuilder = new SuperCarBuilder();
            var notSoSuperBuilder = new NotSoSuperCarBuilder();

            var factory = new CarFactory();
            var builders = new List<CarBuilder> { superBuilder, notSoSuperBuilder };

            foreach (var b in builders)
            {
                var car = factory.Build(b);
                Console.WriteLine($"The car requested by is {b.GetType().Name}:\n--------------------------------------------- " +
                    $"\nHP: {car.HP}\nIpmressive Feature: {car.MostImpressiveFeature}" +
                    $"\nTopSpeed: {car.TopSpeedMPH} mph\n");
            }
        }
    }

    /// <summary>
    /// The 'Product' Class
    /// </summary>
    public class Car
    {
        public int TopSpeedMPH { get; set; }
        public int HP { get; set; }
        public string MostImpressiveFeature { get; set; }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    public abstract class CarBuilder
    {
        protected readonly Car _car = new Car();

        public abstract void SetHP();
        public abstract void SetSpeed();
        public abstract void SetImpressiveFeature();

        public virtual Car GetCar()
        {
            return _car;
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    public class CarFactory
    {
        public Car Build(CarBuilder builder)
        {
            builder.SetHP();
            builder.SetImpressiveFeature();
            builder.SetSpeed();
            return builder.GetCar();
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    public class NotSoSuperCarBuilder : CarBuilder
    {
        public override void SetHP()
        {
            _car.HP = 120;
        }
        public override void SetSpeed()
        {
            _car.TopSpeedMPH = 70;
        }
        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Has Air cond.";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    public class SuperCarBuilder : CarBuilder
    {
        public override void SetHP()
        {
            _car.HP = 1200;
        }
        public override void SetSpeed()
        {
            _car.TopSpeedMPH = 570;
        }
        public override void SetImpressiveFeature()
        {
            _car.MostImpressiveFeature = "Can Fly.";
        }
    }
    
}
