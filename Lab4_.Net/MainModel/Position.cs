namespace Lab4_.Net.MainModel
{
    public class Position : Component
    {
        private int RateNumber { get; set; }
        private int Salary { get; set; }

        public Position(string name, int betNumber, int salary) : base(name)
        {
            RateNumber = betNumber;
            Salary = salary;
        }

        public override void Add(Component comp)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component comp)
        {
            throw new NotImplementedException();
        }

        public override void PrintStaffList()
        {
            Console.WriteLine($"{Name}\t\tКількість ставок у підрозділі: {RateNumber}\t\tОклад: {Salary}");
        }

        public override int CountRateNumber()
        {
            return RateNumber;
        }

        public override int CountSalary()
        {
            return Salary;
        }
    }
}
