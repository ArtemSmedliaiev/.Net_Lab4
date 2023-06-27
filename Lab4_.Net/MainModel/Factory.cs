namespace Lab4_.Net.MainModel
{
    public class Factory : Component
    {
        public Factory(string name) : base(name)
        {
            Children = new();
        }

        public override void Add(Component comp)
        {
            Children.Add(comp);
        }

        public override void Remove(Component comp)
        {
            Children.Remove(comp);
        }

        public override void PrintStaffList()
        {
            Console.WriteLine("Підприємство " + Name);
            Console.WriteLine("----------------------------------------------------------------");

            foreach (Component comp in Children)
            {
                comp.PrintStaffList();
            }

            Console.WriteLine("----------------------------------------------------------------\n");
        }

        public override int CountRateNumber()
        {
            return Children.Sum(parts => parts.CountRateNumber());
        }

        public override int CountSalary()
        {
            return Children.Sum(parts => parts.CountSalary());
        }
    }
}
