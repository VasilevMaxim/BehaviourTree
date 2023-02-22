namespace CodeBase.Model
{
    public class Sequence : Composite
    {
        public override Status Update()
        {
            foreach (var child in Children)
            {
                if (child.Update() == Status.Successful)
                {
                    return Status.Successful;
                }
            }

            return Status.Fail;
        }
    }
}