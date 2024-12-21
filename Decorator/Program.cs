public abstract class AutoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostBase { get; set; }

    public abstract double GetCost();

    public override string ToString()
    {
        return String.Format("Автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n",
            Name, Description, GetCost());
    }
}

public class Renault : AutoBase
{
    public Renault(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }

    public override double GetCost()
    {
        return CostBase * 1.18;
    }
}

public class Ford : AutoBase
{
    public Ford(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }

    public override double GetCost()
    {
        return CostBase * 1.15;
    }
}

public abstract class DecoratorOptions : AutoBase
{
    public AutoBase AutoProperty { protected get; set; }
    public string Title { get; set; }

    public DecoratorOptions(AutoBase au, string tit)
    {
        AutoProperty = au;
        Title = tit;
    }
}

public class MediaNAV : DecoratorOptions
{
    public MediaNAV(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Современный";
        Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost() + 15.99;
    }
}

public class SystemSecurity : DecoratorOptions
{
    public SystemSecurity(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Повышенной безопасности";
        Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP - система динамической стабилизации автомобиля";
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost() + 20.99;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
        Print(reno);

        AutoBase myreno = new MediaNAV(reno, "Навигация");
        Print(myreno);

        AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"), "Безопасность");
        Print(newmyReno);

        Ford ford = new Ford("Форд", "Ford Focus Titanium", 550.0);
        Print(ford);

        AutoBase myFord = new MediaNAV(ford, "Навигация");
        Print(myFord);

        AutoBase newmyFord = new SystemSecurity(new MediaNAV(ford, "Навигация"), "Безопасность");
        Print(newmyFord);
    }

    private static void Print(AutoBase av)
    {
        Console.WriteLine(av.ToString());
    }
}
