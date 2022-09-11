namespace automat
{
    internal class Program
    {
        Dispenser dispenser;
        bool dispening = true;
        static void Main(string[] args)//starts the program
        {
            Program program = new Program();
            program.dispenser = Dispenser.Instance;//this is here because i didnt have time to fix an error it was throwing for some reason
            while (program.dispening)
            {
                program.ChooseMenu();
            }
        }

        void ChooseMenu()//makes a gui where you can choose to buy something or open the dispenser
        {
            Console.Clear();
            bool chooseMenu = true;
            int top = 0;
            string[] menu = { "Buy Something", "Unlock Dispenser" };
            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
            Console.SetCursorPosition(menu[0].Length, 0);
            while (chooseMenu)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (top < menu.Length - 1)
                            top++;
                        AdminCursorMover(menu, top);
                        break;
                    case ConsoleKey.UpArrow:
                        if (top > 0)
                            top--;
                        AdminCursorMover(menu, top);
                        break;
                    case ConsoleKey.Enter:
                        if(top == 0)
                        {
                            chooseMenu = false;
                            Console.Clear();
                            dispenser.CoinBuffer =+ InsertCoin();
                            dispenser.BuySomething(Chooser());
                        }
                        else if(top == 1)
                        {
                            chooseMenu=false;
                            Console.Clear();
                            AdminMenu();
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        int InsertCoin()
        {
            Console.WriteLine("how many coin do you want to insert");
            return int.Parse(Console.ReadLine());
        }

        void PrintMenu()
        {
            Console.Clear();
            int left = 0;
            for (int i = 0; i < dispenser.Products.GetLength(0); i++)
            {
                for (int j = 0; j < dispenser.Products.GetLength(1); j++)
                {
                    Console.CursorLeft = left;
                    if (dispenser.Products[i, j].Stack.Count == 0)
                    {
                        Console.WriteLine("empty");
                    }
                    else
                    {
                        Console.WriteLine(dispenser.Products[i, j].Stack.Peek().Name);
                    }
                }
                Console.SetCursorPosition(10, 0);
                left = 10;
            }
            if (dispenser.Products[0, 0].stack.Count == 0)
                Console.CursorLeft = 5;
            else
                Console.CursorLeft = dispenser.Products[0, 0].stack.Peek().Name.Length;
        }

        int[] Chooser()
        {
            PrintMenu();
            bool choosing = true;
            int left = 0;
            int top = 0;
            int row = 0;
            while (choosing)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (top < dispenser.Products.GetLength(1)-1)
                            top++;
                        CursorMover(left,top,row);
                        break;
                    case ConsoleKey.UpArrow:
                        if (top > 0)
                            top--;
                        CursorMover(left, top, row);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (left < 0)
                            left--;
                        row = 0;
                        CursorMover(left, top, row);
                        break;
                    case ConsoleKey.RightArrow:
                        if (left > dispenser.Products.GetLength(1) - 1)
                            left++;
                        row = 10;
                        CursorMover(left, top, row);
                        break;
                    case ConsoleKey.Enter:
                        choosing = false;
                        break;
                    default:
                        break;
                }
            }
            int[] pos = { left, top };
            return pos;
        }

        ProductData GetProduct()
        {
            int[] pos = Chooser();
            if (dispenser.Products[pos[0],pos[1]].stack.Count != 0&&dispenser.CoinBuffer >= dispenser.Products[pos[0], pos[1]].stack.Peek().Price)
            {
                return dispenser.Products[pos[0], pos[1]].stack.Pop();
            }
            return null;
        }

        void CursorMover(int left,int top,int row)
        {
            if(top < 5&&top >= 0)
            {
                if (dispenser.Products[left, top].stack.Count == 0)
                    Console.SetCursorPosition(5 + row, top);
                else
                    Console.SetCursorPosition(dispenser.Products[left, top].stack.Peek().Name.Length + row, top);
            }
            else if(top >= 5)
            {
                Console.SetCursorPosition(5 + row, top);
            }
        }

        void AdminMenu()
        {
            string[] menu = { "Refill", "Change Product", "Empty money bin" };
            Console.Clear();
            PrintAdminMenu(menu);
            Console.SetCursorPosition(menu[0].Length, 0);
            bool InAdminMenu = true;
            int top = 0;
            while (InAdminMenu)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (top < menu.Length-1)
                            top++;
                        AdminCursorMover(menu, top);
                        break;
                    case ConsoleKey.UpArrow:
                        if (top > 0)
                            top--;
                        AdminCursorMover(menu, top);
                        break;
                    case ConsoleKey.Enter:
                        if(top == 0)
                        {
                            InAdminMenu = false;
                            dispenser.AdminRefill(Chooser());
                        }
                        else if(top == 1)
                        {
                            InAdminMenu=false;
                            dispenser.ChangeProduct(Chooser());
                        }
                        else if(top == 2)
                        {
                            dispening = false;
                            Console.WriteLine("There are "+dispenser.CoinBin+" coins in the bin");
                        }
                        break;
                    case ConsoleKey.Backspace:
                        InAdminMenu = false;
                        break;
                    default:
                        break;
                }
            }
        }
        void AdminCursorMover(string[] menu,int top)
        {
            Console.SetCursorPosition(menu[top].Length, top);
        }

        void AdminChooser()
        {

        }

        void PrintAdminMenu(string[] menu)
        {
            foreach (string item in menu)
            {
                Console.WriteLine(item);
            }
        }

        public string GetAnswer()
        {
            return Console.ReadLine();
        }

        public void PrintString(string str)
        {
            Console.WriteLine(str);
        }
    }
}
