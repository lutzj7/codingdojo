using Library.Base;

namespace Library.CommandAspects
{
    public class CommandDecorator : ICommand
    {
        protected readonly ICommand _parent;

        public CommandDecorator(ICommand parent)
        {
            _parent = parent;
        }

        public virtual void Execute()
        {
            _parent.Execute();
        }
    }
}