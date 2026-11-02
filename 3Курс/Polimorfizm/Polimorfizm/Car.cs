public class Car : Venicle
{
    protected override string Name => "Автомобиль";

    public Car(decimal worth, decimal engineVolume) : base(worth, engineVolume)
    {

    }

    public override decimal CalculateTax()
    {
        return base.CalculateTax();
    }
}