using Avalonia.Controls;
using Silk.NET.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Engine.Avalonia
{
    public class AvaloniaKeyboard : IKeyboard
    {
        Dictionary<Key, bool> KeyPressed = new Dictionary<Key, bool>();
        public AvaloniaKeyboard(Control control)
        {
            control.KeyDown += (s, e) =>
            {
                var key = AvaloniaKey2Silk(e.Key);
                KeyDown?.Invoke(this, key, Index);
                if (KeyPressed.ContainsKey(key))
                {
                    KeyPressed[key] = true;
                }
            };

            control.KeyUp += (s, e) =>
            {
                var key = AvaloniaKey2Silk(e.Key);
                KeyUp?.Invoke(this, key, Index);
                if (KeyPressed.ContainsKey(key))
                {
                    KeyPressed[key] = false;
                }
            };



            foreach (var key in SupportedKeys)
            {
                KeyPressed.Add(key, false);
            }
        }
        public IReadOnlyList<Key> SupportedKeys => new List<Key> { 
         
                    global::Silk.NET.Input.Key.Unknown,
                
                    global::Silk.NET.Input.Key.Backspace,
                
                    global::Silk.NET.Input.Key.Tab,
                
                    global::Silk.NET.Input.Key.Enter,
                
                    global::Silk.NET.Input.Key.Pause,
                
                    global::Silk.NET.Input.Key.Escape,
                
                    global::Silk.NET.Input.Key.Space,
                
                    global::Silk.NET.Input.Key.PageUp,
                
                    global::Silk.NET.Input.Key.PageDown,
                
                    global::Silk.NET.Input.Key.End,
                
                    global::Silk.NET.Input.Key.Home,
                
                    global::Silk.NET.Input.Key.Left,
                
                    global::Silk.NET.Input.Key.Up,
                
                    global::Silk.NET.Input.Key.Right,
                
                    global::Silk.NET.Input.Key.Down,
                
                    global::Silk.NET.Input.Key.Insert,
                
                    global::Silk.NET.Input.Key.Delete,
                
                    global::Silk.NET.Input.Key.A,
                
                    global::Silk.NET.Input.Key.B,
                
                    global::Silk.NET.Input.Key.C,
                
                    global::Silk.NET.Input.Key.D,
                
                    global::Silk.NET.Input.Key.E,
                
                    global::Silk.NET.Input.Key.F,
                
                    global::Silk.NET.Input.Key.G,
                
                    global::Silk.NET.Input.Key.H,
                
                    global::Silk.NET.Input.Key.I,
                
                    global::Silk.NET.Input.Key.J,
                
                    global::Silk.NET.Input.Key.K,
                
                    global::Silk.NET.Input.Key.L,
                
                    global::Silk.NET.Input.Key.M,
                
                    global::Silk.NET.Input.Key.N,
                
                    global::Silk.NET.Input.Key.O,
                
                    global::Silk.NET.Input.Key.P,
                
                    global::Silk.NET.Input.Key.Q,
                
                    global::Silk.NET.Input.Key.R,
                
                    global::Silk.NET.Input.Key.S,
                
                    global::Silk.NET.Input.Key.T,
                
                    global::Silk.NET.Input.Key.U,
                
                    global::Silk.NET.Input.Key.V,
                
                    global::Silk.NET.Input.Key.W,
                
                    global::Silk.NET.Input.Key.X,
                
                    global::Silk.NET.Input.Key.Y,
                
                    global::Silk.NET.Input.Key.Z,
                
                    global::Silk.NET.Input.Key.Number0,
                
                    global::Silk.NET.Input.Key.Number1,
                
                    global::Silk.NET.Input.Key.Number2,
                
                    global::Silk.NET.Input.Key.Number3,
                
                    global::Silk.NET.Input.Key.Number4,
                
                    global::Silk.NET.Input.Key.Number5,
                
                    global::Silk.NET.Input.Key.Number6,
                
                    global::Silk.NET.Input.Key.Number7,
                
                    global::Silk.NET.Input.Key.Number8,
                
                    global::Silk.NET.Input.Key.Number9,
                
                    global::Silk.NET.Input.Key.F1,
                
                    global::Silk.NET.Input.Key.F2,
                
                    global::Silk.NET.Input.Key.F3,
                
                    global::Silk.NET.Input.Key.F4,
                
                    global::Silk.NET.Input.Key.F5,
                
                    global::Silk.NET.Input.Key.F6,
                
                    global::Silk.NET.Input.Key.F7,
                
                    global::Silk.NET.Input.Key.F8,
                
                    global::Silk.NET.Input.Key.F9,
                
                    global::Silk.NET.Input.Key.F10,
                
                    global::Silk.NET.Input.Key.F11,
                
                    global::Silk.NET.Input.Key.F12,
                
                
                    global::Silk.NET.Input.Key.ShiftLeft, // Silk.NET does not differentiate between left and right shift
                
                
                    global::Silk.NET.Input.Key.ControlLeft, // Silk.NET does not differentiate between left and right control
                
                    global::Silk.NET.Input.Key.CapsLock,
                
                    global::Silk.NET.Input.Key.NumLock,

                
                    global::Silk.NET.Input.Key.Keypad0,
                
                    global::Silk.NET.Input.Key.Keypad1,
                
                    global::Silk.NET.Input.Key.Keypad2,
                
                    global::Silk.NET.Input.Key.Keypad3,
                
                    global::Silk.NET.Input.Key.Keypad4,
                
                    global::Silk.NET.Input.Key.Keypad5,
                
                    global::Silk.NET.Input.Key.Keypad6,
                
                    global::Silk.NET.Input.Key.Keypad7,
                
                    global::Silk.NET.Input.Key.Keypad8,
                
                    global::Silk.NET.Input.Key.Keypad9,
                
                    global::Silk.NET.Input.Key.KeypadAdd,
                
                    global::Silk.NET.Input.Key.KeypadSubtract,
                
                    global::Silk.NET.Input.Key.KeypadMultiply,
                
                    global::Silk.NET.Input.Key.KeypadDivide,
                
                    global::Silk.NET.Input.Key.KeypadDecimal,
        };

        public string ClipboardText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => "AvaloniaKeybroad";

        public int Index => 0;

        public bool IsConnected => true;

        public event Action<IKeyboard, Key, int>? KeyDown;
        public event Action<IKeyboard, Key, int>? KeyUp;
        public event Action<IKeyboard, char>? KeyChar;

        public void BeginInput()
        {
            throw new NotImplementedException();
        }

        public void EndInput()
        {
            throw new NotImplementedException();
        }

        public bool IsKeyPressed(Key key)
        {
            if (KeyPressed.ContainsKey(key) == false)
                return false;
            return KeyPressed[key];

        }

        public bool IsScancodePressed(int scancode)
        {
            throw new NotImplementedException();
        }


        static Key AvaloniaKey2Silk(global::Avalonia.Input.Key avaloniaKey)
        {
            switch (avaloniaKey)
            {
                case global::Avalonia.Input.Key.None:
                    return global::Silk.NET.Input.Key.Unknown;
                case global::Avalonia.Input.Key.Back:
                    return global::Silk.NET.Input.Key.Backspace;
                case global::Avalonia.Input.Key.Tab:
                    return global::Silk.NET.Input.Key.Tab;
                case global::Avalonia.Input.Key.Enter:
                    return global::Silk.NET.Input.Key.Enter;
                case global::Avalonia.Input.Key.Pause:
                    return global::Silk.NET.Input.Key.Pause;
                case global::Avalonia.Input.Key.Escape:
                    return global::Silk.NET.Input.Key.Escape;
                case global::Avalonia.Input.Key.Space:
                    return global::Silk.NET.Input.Key.Space;
                case global::Avalonia.Input.Key.PageUp:
                    return global::Silk.NET.Input.Key.PageUp;
                case global::Avalonia.Input.Key.PageDown:
                    return global::Silk.NET.Input.Key.PageDown;
                case global::Avalonia.Input.Key.End:
                    return global::Silk.NET.Input.Key.End;
                case global::Avalonia.Input.Key.Home:
                    return global::Silk.NET.Input.Key.Home;
                case global::Avalonia.Input.Key.Left:
                    return global::Silk.NET.Input.Key.Left;
                case global::Avalonia.Input.Key.Up:
                    return global::Silk.NET.Input.Key.Up;
                case global::Avalonia.Input.Key.Right:
                    return global::Silk.NET.Input.Key.Right;
                case global::Avalonia.Input.Key.Down:
                    return global::Silk.NET.Input.Key.Down;
                case global::Avalonia.Input.Key.Insert:
                    return global::Silk.NET.Input.Key.Insert;
                case global::Avalonia.Input.Key.Delete:
                    return global::Silk.NET.Input.Key.Delete;
                case global::Avalonia.Input.Key.A:
                    return global::Silk.NET.Input.Key.A;
                case global::Avalonia.Input.Key.B:
                    return global::Silk.NET.Input.Key.B;
                case global::Avalonia.Input.Key.C:
                    return global::Silk.NET.Input.Key.C;
                case global::Avalonia.Input.Key.D:
                    return global::Silk.NET.Input.Key.D;
                case global::Avalonia.Input.Key.E:
                    return global::Silk.NET.Input.Key.E;
                case global::Avalonia.Input.Key.F:
                    return global::Silk.NET.Input.Key.F;
                case global::Avalonia.Input.Key.G:
                    return global::Silk.NET.Input.Key.G;
                case global::Avalonia.Input.Key.H:
                    return global::Silk.NET.Input.Key.H;
                case global::Avalonia.Input.Key.I:
                    return global::Silk.NET.Input.Key.I;
                case global::Avalonia.Input.Key.J:
                    return global::Silk.NET.Input.Key.J;
                case global::Avalonia.Input.Key.K:
                    return global::Silk.NET.Input.Key.K;
                case global::Avalonia.Input.Key.L:
                    return global::Silk.NET.Input.Key.L;
                case global::Avalonia.Input.Key.M:
                    return global::Silk.NET.Input.Key.M;
                case global::Avalonia.Input.Key.N:
                    return global::Silk.NET.Input.Key.N;
                case global::Avalonia.Input.Key.O:
                    return global::Silk.NET.Input.Key.O;
                case global::Avalonia.Input.Key.P:
                    return global::Silk.NET.Input.Key.P;
                case global::Avalonia.Input.Key.Q:
                    return global::Silk.NET.Input.Key.Q;
                case global::Avalonia.Input.Key.R:
                    return global::Silk.NET.Input.Key.R;
                case global::Avalonia.Input.Key.S:
                    return global::Silk.NET.Input.Key.S;
                case global::Avalonia.Input.Key.T:
                    return global::Silk.NET.Input.Key.T;
                case global::Avalonia.Input.Key.U:
                    return global::Silk.NET.Input.Key.U;
                case global::Avalonia.Input.Key.V:
                    return global::Silk.NET.Input.Key.V;
                case global::Avalonia.Input.Key.W:
                    return global::Silk.NET.Input.Key.W;
                case global::Avalonia.Input.Key.X:
                    return global::Silk.NET.Input.Key.X;
                case global::Avalonia.Input.Key.Y:
                    return global::Silk.NET.Input.Key.Y;
                case global::Avalonia.Input.Key.Z:
                    return global::Silk.NET.Input.Key.Z;
                case global::Avalonia.Input.Key.D0:
                    return global::Silk.NET.Input.Key.Number0;
                case global::Avalonia.Input.Key.D1:
                    return global::Silk.NET.Input.Key.Number1;
                case global::Avalonia.Input.Key.D2:
                    return global::Silk.NET.Input.Key.Number2;
                case global::Avalonia.Input.Key.D3:
                    return global::Silk.NET.Input.Key.Number3;
                case global::Avalonia.Input.Key.D4:
                    return global::Silk.NET.Input.Key.Number4;
                case global::Avalonia.Input.Key.D5:
                    return global::Silk.NET.Input.Key.Number5;
                case global::Avalonia.Input.Key.D6:
                    return global::Silk.NET.Input.Key.Number6;
                case global::Avalonia.Input.Key.D7:
                    return global::Silk.NET.Input.Key.Number7;
                case global::Avalonia.Input.Key.D8:
                    return global::Silk.NET.Input.Key.Number8;
                case global::Avalonia.Input.Key.D9:
                    return global::Silk.NET.Input.Key.Number9;
                case global::Avalonia.Input.Key.F1:
                    return global::Silk.NET.Input.Key.F1;
                case global::Avalonia.Input.Key.F2:
                    return global::Silk.NET.Input.Key.F2;
                case global::Avalonia.Input.Key.F3:
                    return global::Silk.NET.Input.Key.F3;
                case global::Avalonia.Input.Key.F4:
                    return global::Silk.NET.Input.Key.F4;
                case global::Avalonia.Input.Key.F5:
                    return global::Silk.NET.Input.Key.F5;
                case global::Avalonia.Input.Key.F6:
                    return global::Silk.NET.Input.Key.F6;
                case global::Avalonia.Input.Key.F7:
                    return global::Silk.NET.Input.Key.F7;
                case global::Avalonia.Input.Key.F8:
                    return global::Silk.NET.Input.Key.F8;
                case global::Avalonia.Input.Key.F9:
                    return global::Silk.NET.Input.Key.F9;
                case global::Avalonia.Input.Key.F10:
                    return global::Silk.NET.Input.Key.F10;
                case global::Avalonia.Input.Key.F11:
                    return global::Silk.NET.Input.Key.F11;
                case global::Avalonia.Input.Key.F12:
                    return global::Silk.NET.Input.Key.F12;
                case global::Avalonia.Input.Key.LeftShift:
                case global::Avalonia.Input.Key.RightShift:
                    return global::Silk.NET.Input.Key.ShiftLeft; // Silk.NET does not differentiate between left and right shift
                case global::Avalonia.Input.Key.LeftCtrl:
                case global::Avalonia.Input.Key.RightCtrl:
                    return global::Silk.NET.Input.Key.ControlLeft; // Silk.NET does not differentiate between left and right control
                case global::Avalonia.Input.Key.CapsLock:
                    return global::Silk.NET.Input.Key.CapsLock;
                case global::Avalonia.Input.Key.NumLock:
                    return global::Silk.NET.Input.Key.NumLock;

                case global::Avalonia.Input.Key.NumPad0:
                    return global::Silk.NET.Input.Key.Keypad0;
                case global::Avalonia.Input.Key.NumPad1:
                    return global::Silk.NET.Input.Key.Keypad1;
                case global::Avalonia.Input.Key.NumPad2:
                    return global::Silk.NET.Input.Key.Keypad2;
                case global::Avalonia.Input.Key.NumPad3:
                    return global::Silk.NET.Input.Key.Keypad3;
                case global::Avalonia.Input.Key.NumPad4:
                    return global::Silk.NET.Input.Key.Keypad4;
                case global::Avalonia.Input.Key.NumPad5:
                    return global::Silk.NET.Input.Key.Keypad5;
                case global::Avalonia.Input.Key.NumPad6:
                    return global::Silk.NET.Input.Key.Keypad6;
                case global::Avalonia.Input.Key.NumPad7:
                    return global::Silk.NET.Input.Key.Keypad7;
                case global::Avalonia.Input.Key.NumPad8:
                    return global::Silk.NET.Input.Key.Keypad8;
                case global::Avalonia.Input.Key.NumPad9:
                    return global::Silk.NET.Input.Key.Keypad9;
                case global::Avalonia.Input.Key.Add:
                    return global::Silk.NET.Input.Key.KeypadAdd;
                case global::Avalonia.Input.Key.Subtract:
                    return global::Silk.NET.Input.Key.KeypadSubtract;
                case global::Avalonia.Input.Key.Multiply:
                    return global::Silk.NET.Input.Key.KeypadMultiply;
                case global::Avalonia.Input.Key.Divide:
                    return global::Silk.NET.Input.Key.KeypadDivide;
                case global::Avalonia.Input.Key.Decimal:
                    return global::Silk.NET.Input.Key.KeypadDecimal;
                default:
                    return global::Silk.NET.Input.Key.Unknown;
            }
        }
    }
}
