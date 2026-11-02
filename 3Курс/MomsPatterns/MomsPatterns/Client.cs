using System;
//Вызывает клон, а конкертный объект сам клонирует что надо.
//Наверное будет полезно, чтобы копировать объекты разных типов не зная подробностей их создания
public class Client
{
    public Client()
    {
        //Запускаем демонстрацию копирования прототипов.
        Operation();
    }

    private void Operation()
    {
        //Создаём исходные объекты двух конкретных типов. m
        //Храним их в массиве общего типа Prototype
        Prototype[] prototypes = { new ConcretePrototype1(10), new ConcretePrototype2(20)};

        //Копируем каждый объект через общий метод Clone()
        foreach (Prototype original in prototypes)
        {
            Prototype copy = original.Clone();

            //Показываем, что копия сохраняет тип и идентификатор
            Console.WriteLine($"Оригинал: {original.GetType().Name}, Id = {original.Id}");

            Console.WriteLine($"Копия: {copy.GetType().Name}, Id = {copy.Id}");

            //Проверяем, являются ли оригинал и копия одним объектом
            Console.WriteLine($"Один объект: {ReferenceEquals(original, copy)}");
            Console.WriteLine();
        }
    }
}