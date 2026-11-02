public abstract class Property
{
    protected decimal _worth;

    protected Property(decimal worth)
    {
        if (worth < 0)
        {
            throw new System.ArgumentOutOfRangeException(nameof(worth), "Стоимость не может быть отрицательной.");
        }

        this._worth = worth;
    }

    public decimal Worth => _worth;
    public abstract decimal CalculateTax();

    public decimal CalculateTax(decimal discountPercent)
    {
        if (discountPercent < 0 || discountPercent > 100)
            throw new ArgumentException("Льгота должна быть от 0 до 100%.");

        return CalculateTax() * (1 - discountPercent / 100m);
    }
}