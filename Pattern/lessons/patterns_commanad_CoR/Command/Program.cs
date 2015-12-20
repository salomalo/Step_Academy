using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Commands (ON/OFF)");
            string cmd = Console.ReadLine();

            Light lamp = new Light();

            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            Switch s = new Switch();

            if (cmd == "ON")
            {
                s.StoreAndExecute(switchUp);
            }
            else if (cmd == "OFF")
            {
                s.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
            }

            Console.ReadKey();
        }
    }

    //інтерфейс команди
    public interface ICommand
    {
        void Execute();
    }

    //клас виконавець Invoker 
    public class Switch
    {
        //список виконаних команд
        private readonly List<ICommand> _commands = new List<ICommand>();

        public void Undo()
        {
            _commands[_commands.Count - 1].Execute();
        }

        public void StoreAndExecute(ICommand command)
        {
            _commands.Add(command);
            command.Execute();
        }
    }

    //клас приймач Receiver (у нашому випадку світильник)
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is off");
        }
    }

    // Команда для включеня світла (ConcreteCommandA)
    public class FlipUpCommand : ICommand
    {
        private readonly Light _light;

        public FlipUpCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    // Команда для виключеня світла (ConcreteCommandB)
    public class FlipDownCommand : ICommand
    {
        private readonly Light _light;

        public FlipDownCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }
}