interface ISensor {
    double GetTemperatureCelsius();
}

class FahrenheitSensor {
    public double GetTemperatureFahrenheit() {
        Random rnd = new Random();
        return rnd.Next(1, 451); // 451 градус по Фаренгейту, Рэй Брэдбери
    }
}

class TemperatureAdapter : ISensor {
    private readonly FahrenheitSensor _fahrenheitSensor;

    public TemperatureAdapter(FahrenheitSensor sensor) {
        _fahrenheitSensor = sensor;
    }

    public double GetTemperatureCelsius() {
        return Math.Round((_fahrenheitSensor.GetTemperatureFahrenheit() - 32) * 5 / 9, 2);
    }
}

class Program {
    static void Main(string[] args) {
        FahrenheitSensor sensor = new FahrenheitSensor();
        ISensor adapter = new TemperatureAdapter(sensor);
        Console.WriteLine("Температура в Цельсиях: " + adapter.GetTemperatureCelsius());
    }
}