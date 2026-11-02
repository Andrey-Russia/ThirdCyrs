public class Venicle : Property
{
    protected decimal _engineVolume;
    protected virtual string Name => "Транспорт";

    public Venicle(decimal worth, decimal engineVolume) : base(worth)
    {
        if (engineVolume <= 0)
        {
            throw new System.ArgumentOutOfRangeException(nameof(engineVolume), "Объём двигателя должен быть положительным.");
        }

        this._engineVolume = engineVolume;
    }

    public override decimal CalculateTax()
    {
        return _worth * _engineVolume / 3000m;
    }

    public override string ToString()
    {
        return $"{Name}: Стоимость - {_worth:0.##}, " + $"налог - {CalculateTax():0.##}, " + $"объём двигателя - {_engineVolume:0.##} л";
    }
}