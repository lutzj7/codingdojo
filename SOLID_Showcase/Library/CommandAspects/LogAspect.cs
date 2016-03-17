using System.Diagnostics;
using Library.Base;

namespace Library.CommandAspects
{
    public class LogAspect : CommandDecorator
    {
        public LogAspect(ICommand parent) : base(parent)
        {
        }

        public override void Execute()
        {
            Debug.WriteLine("exuting " + _parent.GetType().FullName);
            base.Execute();
            Debug.WriteLine("finished " + _parent.GetType().FullName);
        }
    }
}