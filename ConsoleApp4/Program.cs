namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pos = 1;

            Menu menu = new Menu(pos);
            Convertor convertor = new Convertor();

            menu.Init(menu);
            convertor.Init(menu);
        }
    }
}