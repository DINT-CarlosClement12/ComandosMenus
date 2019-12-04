using System.Windows.Input;

namespace ComandosMenus.commands
{
    public static class EditCommands
    {
        public static readonly RoutedUICommand Clear = new RoutedUICommand("Clear", "Clear", typeof(FileCommands), new InputGestureCollection()
        {
            new  KeyGesture(Key.V, ModifierKeys.Alt)
        });
    }
}
