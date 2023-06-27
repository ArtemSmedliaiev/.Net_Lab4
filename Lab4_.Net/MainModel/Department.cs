namespace Lab4_.Net.MainModel
{
    public class Department : Component
    {
        private int Id { get; set; }

        public Department(string name, int id) : base(name)
        {
            Id = id;
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
            Console.WriteLine("Відділ " + Name);
            Console.WriteLine("--------------------------------");

            foreach (Component comp in Children)
            {
                comp.PrintStaffList();
            }

            Console.WriteLine("--------------------------------\n");
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
