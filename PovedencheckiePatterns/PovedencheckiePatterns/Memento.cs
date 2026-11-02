using System;
using System.Collections.Generic;

class EditorMemento
{
    public string Text { get; }

    public EditorMemento(string text)
    {
        Text = text;
    }
}

class TextEditor
{
    public string Text { get; private set; } = "";

    public void SetText(string text)
    {
        Text = text;
    }

    public EditorMemento Save()
    {
        return new EditorMemento(Text);
    }

    public void Restore(EditorMemento memento)
    {
        Text = memento.Text;
    }
}

class History
{
    private readonly Stack<EditorMemento> _snapshots = new Stack<EditorMemento>();

    public void Push(EditorMemento memento)
    {
        _snapshots.Push(memento);
    }

    public EditorMemento Pop()
    {
        if (_snapshots.Count == 0)
        {
            throw new InvalidOperationException("Нет сохранённых состояний.");
        }

        return _snapshots.Pop();
    }
}

class Program3
{
    static void Main()
    {
        TextEditor editor = new TextEditor();
        History history = new History();

        editor.SetText("Первая версия текста.");
        history.Push(editor.Save());

        editor.SetText("Вторая версия текста.");
        Console.WriteLine($"После изменения: {editor.Text}");

        editor.Restore(history.Pop());
        Console.WriteLine($"После восстановления: {editor.Text}");
    }
}