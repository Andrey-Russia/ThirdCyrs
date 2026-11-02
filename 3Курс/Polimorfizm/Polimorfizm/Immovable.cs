public class Immovable : Property
{
    protected decimal _area;

    protected virtual string Name => "Недвижимость";

    public Immovable(decimal worth, decimal area) : base(worth)
    {
        if (area <= 0)
        {
            throw new System.ArgumentOutOfRangeException(nameof(area), "Площадь должна быть положительной.");
        }
        this._area = area;
    }

    public override decimal CalculateTax()
    {
        if (_area <= 100m)
        {
            return _worth / 500m;
        }

        if (_area <= 300m)
        {
            return _worth / 350m;
        }

        return _worth / 250m;
    }

    public decimal PricePerSquareMeter()
    {
        return _worth / _area;
    }

    public override string ToString()
    {
        return $"{Name}: Стоимость - {_worth:0.##}, " + $"налог - {CalculateTax():0.##}, " + $"площадь - {_area:0.##} кв.м";
    }
}