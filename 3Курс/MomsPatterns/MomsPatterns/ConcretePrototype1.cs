//Релизует копирование объектов своего типа.
//Например, есть шаблон персонажа который заранее настроен и из создаём экземпляры

public class ConcretePrototype1 : Prototype
{
    public ConcretePrototype1(int id) : base(id)
    {
        // Передаём идентификатор родительскому конструктору.
        // Родительский класс сохраняет его в свойстве Id
    }

    public override Prototype Clone()
    {
        //Создаём отдельный объект этого же типа и копирум в него индефикатор исходного обхекта
        return new ConcretePrototype1(Id);
    }
}