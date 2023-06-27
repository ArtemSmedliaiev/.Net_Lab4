namespace Lab4_.Net.MainModel
{
    public abstract class Component
    {
        public string Name { get; set; }
        public List<Component> Children { get; set; } = new List<Component>();

        public Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component comp);
        public abstract void Remove(Component comp);
        public abstract int CountRateNumber();
        public abstract int CountSalary();
        public abstract void PrintStaffList();

    }
}
