namespace CodeBase.View
{
    public interface ISelectable : UIElement
    {
        void Select();
        void Deselect();
    }
}