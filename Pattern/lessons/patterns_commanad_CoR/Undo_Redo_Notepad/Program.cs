using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undo_Redo_Notepad
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter Commands (ON/OFF)");
            //  string cmd = Console.ReadLine();


                ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey(true);
                //if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                
                string txt = Console.ReadLine();
                Text text = new Text(txt);
                ICommand undo = new UndoCommand(text);
                ICommand redo = new RedoCommand(text);

                Switch s = new Switch();

                Console.TreatControlCAsInput = true;

                if (cki.KeyChar == 'u')
                {
                    s.StoreAndExecute(undo);
                }
                else if (cki.KeyChar == 'r')
                {
                    s.StoreAndExecute(redo);
                }
                else
                {
                    //Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
                }
            } while (cki.Key != ConsoleKey.Escape);
            Console.ReadKey();
        }



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



        public interface ICommand
        {
            void Execute();
        }

        public class UndoCommand : ICommand
        {
            private readonly Text text;
            public UndoCommand(Text _text)
            {
                text = _text;
            }

            public void Execute()
            {
                text.RemoveLast();
            }
        }

        public class RedoCommand : ICommand
        {
            private readonly Text text;
            public RedoCommand(Text _text)
            {
                text = _text;
            }

            public void Execute()
            {
                text.ReturnLastRemoved();
            }
        }

        public class Text
        {
            private string txt;

            public Text(string _txt)
            {
                txt = _txt;
            }

            public void RemoveLast()
            {
                // видалити останнє слово

            }
            public void ReturnLastRemoved()
            {
                // повернути останнє видалене слово
            }
        }


    }
}