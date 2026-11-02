public class Boat : Venicle
{
    protected override string Name => "Лодка";

    public Boat(decimal worth, decimal engineVolume) : base(worth, engineVolume)
    {

    }

    public override decimal CalculateTax()
    {
        return base.CalculateTax();
    }
}