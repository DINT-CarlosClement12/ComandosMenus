using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComandosMenus.commands
{
    public static class FileCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(FileCommands), new InputGestureCollection()
        {
            new  KeyGesture(Key.S, ModifierKeys.Control)
        });
    }
}
