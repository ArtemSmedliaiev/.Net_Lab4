using Lab4_.Net.MainModel;

namespace Lab4_.Net.ExtraClasses
{
    public class ComponentMaker
    {
        ProperValueEnter ValueEnter = new ProperValueEnter();

        public ComponentMaker(ProperValueEnter val)
        {
            ValueEnter = val;
        }

        public Factory GetFactory() => new Factory(ValueEnter.StringValueEnter("Введіть назву підприємтсва:"));

        public Department GetDepartment() => new Department(ValueEnter.StringValueEnter("Введіть назву підрозділу:"),
                                                           ValueEnter.IntValueEnter("Введіть Id підрозділу:"));

        public Position GetPosition() => new Position(ValueEnter.StringValueEnter("Введіть назву посади:"),
                                                      ValueEnter.IntValueEnter("Введіть кількість ставок у підрозділі:"),
                                                      ValueEnter.IntValueEnter("Введіть оклад:"));
    }
}
