public class Appartment : Immovable
{
    protected virtual string Name => "Квартира";

    public Appartment(decimal worth, decimal area) : base(worth, area)
    {

    }

    public override decimal CalculateTax()
    {
        return base.CalculateTax();
    }
}