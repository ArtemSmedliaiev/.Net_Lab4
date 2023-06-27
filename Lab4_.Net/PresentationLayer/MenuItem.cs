namespace Lab4_.Net.PresentationLayer
{
    public class MenuItem
    {
        public readonly string _title;
        public readonly Action _selectedAction;

        public MenuItem(string title, Action selectedAction)
        {
            _title = title;
            _selectedAction = selectedAction;
        }

        internal void ExecuteSelectedAction()
        {
            _selectedAction.Invoke();
        }

        public override string ToString()
        {
            return _title;
        }
    }
}
