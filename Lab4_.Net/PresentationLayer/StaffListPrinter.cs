using Lab4_.Net.MainModel;

namespace Lab4_.Net.PresentationLayer
{
    public class StaffListPrinter
    {
        public void Print(Component component)
        {
            Console.Clear();
            Console.WriteLine("Штатний розпис\n");
            component.PrintStaffList();
            Console.WriteLine($"\tЗагальна кільість штатних одиниць: {component.CountRateNumber()}\tСумарний оклад: {component.CountSalary()}");
        }
    }
}
