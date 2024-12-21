public interface INavigationStrategy {
    string Title { get; }
    void Execute();
}

public class NavigationContext {
    private INavigationStrategy _strategy;

    public NavigationContext(INavigationStrategy strategy) {
        _strategy = strategy;
    }

    public void SetStrategy(INavigationStrategy strategy) {
        _strategy = strategy;
    }

    public void ExecuteStrategy() {
        Console.WriteLine(_strategy.Title);
        _strategy.Execute();
    }
}

public class CarNavigation : INavigationStrategy {
    public string Title => "Карта автодорог";

    public void Execute() {
        Console.WriteLine("Прокладывание дорожного пути...");
    }
}

public class WalkingNavigation : INavigationStrategy {
    public string Title => "Пеший маршрут";

    public void Execute() {
        Console.WriteLine("Прокладывание пешего маршрута...");
    }
}

public class BikeNavigation : INavigationStrategy {
    public string Title => "Маршрут по велодорожкам";

    public void Execute() {
        Console.WriteLine("Планируем велодорожный маршрут...");
    }
}

class Program {
    static void Main(string[] args) {
        NavigationContext context = new NavigationContext(new CarNavigation());

        context.ExecuteStrategy();

        context.SetStrategy(new WalkingNavigation());
        context.ExecuteStrategy();

        context.SetStrategy(new BikeNavigation());
        context.ExecuteStrategy();
    }
}
