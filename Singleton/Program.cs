﻿abstract class CarFactory
{
    public abstract AbstractCar CreateCar();
    public abstract AbstractEngine CreateEngine();
}

abstract class AbstractCar
{
    public string Name { get; set; }
    public string BodyType { get; set; }
    public abstract int MaxSpeed(AbstractEngine engine);
}

abstract class AbstractEngine
{
    public int max_speed { get; set; }
}

class FordFactory : CarFactory
{
    static Lazy<FordFactory> fordFactory = new Lazy<FordFactory>(() => new FordFactory());

    public static FordFactory Ford_Factory
    {
        get
        {
            return fordFactory.Value;
        }
    }

    public override AbstractCar CreateCar()
    {
        return new FordCar("Форд");
    }
    public override AbstractEngine CreateEngine()
    {
        return new FordEngine();
    }
}

class FordCar : AbstractCar
{
    public FordCar(string name)
    {
        Name = name;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name;

    }
}

class FordEngine : AbstractEngine
{
    public FordEngine()
    {
        Random rnd = new Random();
        max_speed = rnd.Next(100, 180);
    }
}

class AudiFactory : CarFactory
{
    static Lazy<AudiFactory> audiFactory = new Lazy<AudiFactory>(() => new AudiFactory());

    public static AudiFactory Audi_Factory
    {
        get
        {
            return audiFactory.Value;
        }
    }
    public override AbstractCar CreateCar()
    {
        return new AudiCar("Ауди", "Внедорожник");
    }
    public override AbstractEngine CreateEngine()
    {
        return new AudiEngine();
    }
}

class AudiCar : AbstractCar
{
    public AudiCar(string name, string type_body)
    {
        Name = name;
        BodyType = type_body;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name + ", тип кузова: " + BodyType;

    }
}

class AudiEngine : AbstractEngine
{
    public AudiEngine()
    {
        Random rnd = new Random();
        max_speed = rnd.Next(100, 270);
    }
}

class Client
{
    private AbstractCar abstractCar;
    private AbstractEngine abstractEngine;

    public Client(CarFactory car_factory)
    {
        abstractCar = car_factory.CreateCar();
        abstractEngine = car_factory.CreateEngine();
    }
    
    public int RunMaxSpeed()
    {
        return abstractCar.MaxSpeed(abstractEngine);
    }

    public override string ToString()
    {
        return abstractCar.ToString();
    }
}

class Program
{
    static void Main()
    {
        CarFactory ford_car = new FordFactory();
        Client c1 = new Client(ford_car);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
            c1.ToString(), c1.RunMaxSpeed());

        CarFactory ford_car2 = new FordFactory();
        Client c2 = new Client(ford_car2);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
            c2.ToString(), c2.RunMaxSpeed());

        CarFactory audi_car = new AudiFactory();
        Client c3 = new Client(audi_car);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
            c3.ToString(), c3.RunMaxSpeed());

        CarFactory audi_car2 = new AudiFactory();
        Client c4 = new Client(audi_car2);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
            c4.ToString(), c4.RunMaxSpeed());
    }
}
