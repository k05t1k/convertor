using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp4
{
    internal class Menu
    {
        public int m_iPos = 1;
        public bool m_bCheck = false;
        public Menu(int pos) 
        {
            m_iPos = pos;
        }
        public string m_strConvertPath;
        public string m_strSavePath;
        private static void Choice(Menu menu) 
        {
            string? text = menu.m_iPos == 1 ? "    text" : " text";
            string? json = menu.m_iPos == 2 ? "    json" : " json";
            string? xml = menu.m_iPos == 3 ? "    xml" : " xml";

            Console.WriteLine($"{text}\n{json}\n{xml}");
        }
        private static void Choice2(Menu menu)
        {
            string? json = menu.m_iPos == 1 ? "    json" : " json";
            string? xml = menu.m_iPos == 2 || menu.m_iPos == 3 ? "    xml" : " xml";

            Console.WriteLine($"{json}\n{xml}");
        }
        private static void Select(Menu menu, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (menu.m_iPos != 1)
                    {
                        menu.m_iPos--;
                        Console.Clear();
                    }
                    else
                        Console.Clear();
                    break;
                case ConsoleKey.DownArrow:
                    if (menu.m_iPos != 3)
                    {
                        menu.m_iPos++;
                        Console.Clear();
                    }
                    else
                        Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public void Init(Menu menu)
        {
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("choice:");

                Choice(menu);

                Console.SetCursorPosition(0, m_iPos);
                Console.WriteLine("->");
                key = Console.ReadKey();
                Console.SetCursorPosition(0, m_iPos);
                Console.WriteLine("  ");

                Select(menu, key);
            }
            while (key.Key != ConsoleKey.Enter);

            Console.Clear();

            if (m_iPos == 1)
            {
                m_bCheck = true;
                do
                {
                    Console.WriteLine("choice from:");

                    Choice2(menu);

                    if (m_iPos == 3)
                        m_iPos = 2;

                    Console.SetCursorPosition(0, m_iPos);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                    Console.SetCursorPosition(0, m_iPos);
                    Console.WriteLine("  ");

                    Select(menu, key);
                }
                while (key.Key != ConsoleKey.Enter);

                Console.Clear();
            }

            while (true)
            {
                Console.WriteLine("enter convert file path:");
                m_strConvertPath = Console.ReadLine();

                Console.WriteLine("enter save file path:");
                m_strSavePath = Console.ReadLine();

                break;
            }

            Console.Clear();
        }
    }
}
