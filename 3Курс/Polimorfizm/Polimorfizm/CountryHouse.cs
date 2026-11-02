public class CountryHouse : Immovable
{
    protected override string Name => "Дача";

    public CountryHouse(decimal worth, decimal area) : base(worth, area)
    {

    }

    public override decimal CalculateTax()
    {
        return base.CalculateTax();
    }
}