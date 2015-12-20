using System;
using System.Collections.Generic;

namespace CompositePattern
{
    class MainApp
    {
        static void Main()
        {
            //створюємо рутовий елемент
            Composite window = new Composite("MainWindow");
            window.Add(new WindowElement("Button A"));
            window.Add(new WindowElement("Button B"));

            Composite childWindow = new Composite("ChildWindow");
            childWindow.Add(new WindowElement("Label A"));

            var someLeaf = new WindowElement("Label B");

            var grid = new GridElement("Grid A");

            grid.Add(new WindowElement("StakPanel"));

            someLeaf.Add(grid);

            childWindow.Add(someLeaf);

            window.Add(childWindow);
            window.Add(new WindowElement("Button C"));

            // Add and remove a WindowElement
            WindowElement windowElement = new WindowElement("Label D");
            window.Add(windowElement);
            window.Remove(windowElement);

            // рекурсивно обходимо дерево
            window.Display(1);

            
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Абстрактний клас Компонент
    /// </summary>
    abstract class Window
    {
        protected string Name;

        // Constructor
        protected Window(string name)
        {
            Name = name;
        }

        //управління компонентом
        public abstract void Add(Window window);
        public abstract void Remove(Window window);
        public abstract void Display(int depth);
    }
    /// <summary>
    /// Клас компонувальник
    /// </summary>
    class Composite : Window
    {
        //дочірні компоненти
        public readonly List<Window> _children = new List<Window>();

        // Constructor
        public Composite(string name) : base(name)
        {

        }

        public override void Add(Window window)
        {
            _children.Add(window);
        }

        public override void Remove(Window window)
        {
            _children.Remove(window);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);

            //рекурсивно обходимо елементи
            foreach (Window component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class QFrameComposite : Composite
    {
        public QFrameComposite(string name)
            : base(name)
        {
        }
    }

    class  QGrid : QFrameComposite
    {
        public QGrid(string name) : base(name)
        {
        }
    }

    class GridElement : Composite
    {
        public GridElement(string name) : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);
            Console.WriteLine("THIS IS GRID!!!!");
            //рекурсивно обходимо елементи
            foreach (Window component in _children)
            {
                component.Display(depth + 4);
            }
        }
    }

    /// <summary>
    /// Окремий елемент композиції
    /// </summary>
    class WindowElement : Composite
    {
        
        public WindowElement(string name) : base(name)
        {
        }

        //public override void Add(Window window)
        //{
        //    Console.WriteLine("Cannot add to a window element");
        //}

        public override void Remove(Window window)
        {
            Console.WriteLine("Cannot remove from a window element");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + Name);

            //рекурсивно обходимо елементи
            foreach (Window component in _children)
            {
                component.Display(depth + 4);
            }
        }
    }
}