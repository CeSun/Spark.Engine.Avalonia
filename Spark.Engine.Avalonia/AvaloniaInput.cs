using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Silk.NET.Input;

namespace Spark.Engine.Avalonia
{
    internal class AvaloniaInput : IInputContext
    {
       
        public AvaloniaInput(Control control)
        {
            _Keyboards.Add(new AvaloniaKeyboard(control));
            _Mice.Add(new AvaloniaMouse(control));
        }

        public nint Handle => throw new NotImplementedException();

        public IReadOnlyList<IGamepad> Gamepads => new List<IGamepad>();

        public IReadOnlyList<IJoystick> Joysticks => new List<IJoystick>();

        public List<AvaloniaKeyboard> _Keyboards = new List<AvaloniaKeyboard>();
        public IReadOnlyList<IKeyboard> Keyboards => _Keyboards;

        public List<AvaloniaMouse> _Mice = new List<AvaloniaMouse>();
        public IReadOnlyList<IMouse> Mice => _Mice;

        public IReadOnlyList<IInputDevice> OtherDevices => new List<IInputDevice>();

        public event Action<IInputDevice, bool>? ConnectionChanged;

        public void Dispose()
        {
        }
    }
}
