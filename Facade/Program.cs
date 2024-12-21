class Drive {
    public void TurnOn() {
        Console.WriteLine("Привод включен.");
    }
    public void TurnOff() {
        Console.WriteLine("Привод выключен.");
    }
}

class Power {
    public void SetPower(int level) {
        Console.WriteLine($"Мощность установлена на уровень {level}.");
    }
}

class Notification {
    public void Notify(string message) {
        Console.WriteLine($"Уведомление: {message}");
    }
}
class MicrowaveFacade {
    private Drive _drive;
    private Power _power;
    private Notification _notification;

    public MicrowaveFacade(Drive drive, Power power, Notification notification) {
        _drive = drive;
        _power = power;
        _notification = notification;
    }

    public void StartDefrost() {
        _notification.Notify("Начало разморозки.");
        _drive.TurnOn();
        _power.SetPower(500);
        _drive.TurnOff();
        _notification.Notify("Разморозка завершена.");
    }

    public void StartCooking(int cookingTime, int powerLevel) {
        _notification.Notify($"Начало приготовления на мощности {powerLevel} в течение {cookingTime} минут.");
        _drive.TurnOn();
        _power.SetPower(powerLevel);
        System.Threading.Thread.Sleep(cookingTime * 1000);
        _drive.TurnOff();
        _notification.Notify("Приготовление завершено.");
    }
}

class Program {
    static void Main(string[] args) {
        var drive = new Drive();
        var power = new Power();
        var notification = new Notification();
        var microwave = new MicrowaveFacade(drive, power, notification);

        microwave.StartDefrost();
        microwave.StartCooking(5, 700);
    }
}