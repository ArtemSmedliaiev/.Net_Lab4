using Lab4_.Net.ExtraClasses;
using Lab4_.Net.MainModel;
using Lab4_.Net.PresentationLayer;

public class Program
{
    static void Pause()
    {
        Console.WriteLine("\nДля продовження натисніть будь-яку клавішу");
        Console.ReadKey();
        Console.Clear();
    }

    static void Remover(Component comp)
    {
        Menu menu = new Menu();
        foreach (Component c in comp.Children)
        {
            menu.Items.Add(new MenuItem(c.Name, () => comp.Remove(c)));
        }
        menu.Items.Add(new MenuItem($"{menu.ItemsCount}. Завершити видалення", () => menu.IsExitWanted = true));
        MenuItemSelector selector = new(1, menu.ItemsCount);

        while (!menu.IsExitWanted)
        {
            Console.Clear();
            menu.PrintMenu($"Що з {comp.Name} ви хочете видалити:");
            menu.ExecuteSelectedItem(selector.SelectItem());
            Pause();
        }
    }

    static void MenuRunner(Component comp, ComponentMaker maker, StaffListPrinter printer)
    {
        Factory f = new Factory("Factory");
        Department d = new Department("Department", -1);
        Menu menu = new Menu();
        Action action = () => comp.Children.Add(d = maker.GetDepartment());
        action += () => MenuRunner(d, maker, printer);
        menu.Items = new()
        {
            new MenuItem("1. Повернутися",
                () => menu.IsExitWanted = true),

            new MenuItem("2. Створити підрозділ", action),

            new MenuItem("3. Створити посаду",
                () => comp.Children.Add(maker.GetPosition())),

            new MenuItem("4. Видалити підрозділ або посаду",
                () => Remover(comp)),

            new MenuItem("5. Надрукувати штатний розпис",
                () => printer.Print(comp))
        };


        while (!menu.IsExitWanted)
        {
            foreach (Component c in comp.Children)
            {
                if (c.GetType() == f.GetType() || c.GetType() == d.GetType())
                {
                    MenuItem item = new MenuItem(menu.ItemsCount + 1 + ". " + c.Name, () => MenuRunner(c, maker, printer));
                    string? title = menu.Items.Select(m => m._title).FirstOrDefault(m => m.Split(". ")[1] == c.Name);
                    if (!(c.Name == title?.Split(". ")[1]))
                        menu.Items.Add(item);
                }
                else
                {
                    MenuItem item = new MenuItem(menu.ItemsCount + 1 + ". " + c.Name, () => c.PrintStaffList());
                    string? title = menu.Items.Select(m => m._title).FirstOrDefault(m => m.Split(". ")[1] == c.Name);
                    if (!(c.Name == title?.Split(". ")[1]))
                        menu.Items.Add(item);
                }
            }

            MenuItemSelector selector = new MenuItemSelector(1, menu.ItemsCount);

            Console.Clear();
            menu.PrintMenu(comp.Name);
            menu.ExecuteSelectedItem(selector.SelectItem());
            Pause();
        }
    }



    public static void Main()
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;

        ProperValueEnter valueEnter = new ProperValueEnter();
        ComponentMaker maker = new ComponentMaker(valueEnter);
        StaffListPrinter printer = new StaffListPrinter();

        Menu menu = new Menu();


        Component component;

        menu.Items = new()
        {
            new MenuItem("1. Створити підприємтсво",
                () => MenuRunner(maker.GetFactory(), maker, printer)),

            new MenuItem("2. Створити підрозділ",
                () => MenuRunner(maker.GetDepartment(), maker, printer)),

            new MenuItem("3. Завершити роботу",
                () => menu.IsExitWanted = true)
        };
        MenuItemSelector selector = new MenuItemSelector(1, menu.ItemsCount);

        while (!menu.IsExitWanted)
        {
            Console.Clear();
            menu.PrintMenu(">>>Створення штатного розкладу<<<");
            menu.ExecuteSelectedItem(selector.SelectItem());
            Pause();
        }
    }
}
