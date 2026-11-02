using System;

public class Taxpayer
{
    private readonly Property[] properties;
    private int propertyCount;

    public string FullName { get; }

    public int PropertyCount
    {
        get { return propertyCount; }
    }

    public Taxpayer(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("ФИО не может быть пустым.");

        FullName = fullName;
        properties = new Property[10];
        propertyCount = 0;
    }

    public void AddProperty(Property property)
    {
        if (propertyCount >= properties.Length)
            throw new InvalidOperationException("Нельзя добавить больше 10 объектов.");

        properties[propertyCount] = property;
        propertyCount++;
    }

    public Property GetProperty(int index)
    {
        if (index < 0 || index >= propertyCount)
            throw new IndexOutOfRangeException();

        return properties[index];
    }

    public decimal CalculateTotalTax()
    {
        decimal totalTax = 0;

        for (int i = 0; i < propertyCount; i++)
            totalTax += properties[i].CalculateTax();

        return totalTax;
    }

    public decimal CalculateTotalTax(decimal discountPercent)
    {
        decimal totalTax = 0;

        for (int i = 0; i < propertyCount; i++)
            totalTax += properties[i].CalculateTax(discountPercent);

        return totalTax;
    }
}