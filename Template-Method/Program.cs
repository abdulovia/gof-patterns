abstract class MenHaircut
{
    public int TopLength { get; set; }
    public int SideLength { get; set; }
    public int FrontLength { get; set; }

    public MenHaircut(int top, int side, int front)
    {
        TopLength = top;
        SideLength = side;
        FrontLength = front;
    }

    public void TemplateMethod()
    {
        WashingHead();
        Cutting();
        UsingHairDryer();
        WashingHead();
    }

    private void WashingHead()
    {
        Console.WriteLine("Голова помыта");
    }
    private void UsingHairDryer()
    {
        Console.WriteLine("Волосы убраны");
    }
    public abstract void Cutting();
}

class BoldHaircut : MenHaircut
{
    public BoldHaircut(int t, int s, int f) : base(t, s, f) { }
    public override void Cutting()
    {
        TopLength = 0;
        SideLength = 0;
        FrontLength = 0;
        Console.WriteLine("Волосы пострижены");
    }
}

class ClassicHaircut : MenHaircut
{
    public ClassicHaircut(int t, int s, int f) : base(t, s, f) { }
    public override void Cutting()
    {
        TopLength = 2;
        SideLength = 2;
        FrontLength = 2;
        Console.WriteLine("Волосы пострижены");
    }
}

class ModelHaircut : MenHaircut
{
    public ModelHaircut(int t, int s, int f) : base(t, s, f) { }
    public override void Cutting()
    {
        TopLength = 7;
        SideLength = 2;
        FrontLength = 1;
        Console.WriteLine("Волосы пострижены");
    }
}

class Program
{
    static void Main ()
    {
        MenHaircut val = new BoldHaircut(3, 2, 1);
        val.TemplateMethod();
    }
}
