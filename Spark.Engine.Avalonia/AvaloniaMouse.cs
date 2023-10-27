
using Avalonia.Controls;
using Silk.NET.Input;
using System.Numerics;

namespace Spark.Engine.Avalonia
{
    internal class AvaloniaMouse : IMouse
    {
        Control control;

        global::Avalonia.Input.PointerPoint? PointerPoint;

        public AvaloniaMouse(Control control) 
        { 
            this.control = control;

            this.control.PointerMoved += (s, e) =>
            {
                PointerPoint = e.GetCurrentPoint(s as Control);
                var p = e.GetPosition(this.control);
                Position = new Vector2((float)p.X, (float)p.Y);
                MouseMove?.Invoke(this, Position);

            };

            this.control.PointerPressed += (s, e) =>
            {
                
                var p = e.GetCurrentPoint(s as Control);
                MouseButton mouseButton = MouseButton.Unknown;
                if (p.Properties.IsLeftButtonPressed)
                {
                    mouseButton = MouseButton.Left;
                }

                if (p.Properties.IsRightButtonPressed)
                {
                    mouseButton = MouseButton.Right;
                }
                if (p.Properties.IsMiddleButtonPressed)
                {
                    mouseButton = MouseButton.Middle;
                }
                PointerPoint = p;
                MouseDown?.Invoke(this, mouseButton);
            };


            this.control.PointerReleased += (s, e) =>
            {
                var p = e.GetCurrentPoint(s as Control);
                MouseButton mouseButton = MouseButton.Unknown;
                if (p.Properties.IsLeftButtonPressed)
                {
                    mouseButton = MouseButton.Left;
                }

                if (p.Properties.IsRightButtonPressed)
                {
                    mouseButton = MouseButton.Right;
                }
                if (p.Properties.IsMiddleButtonPressed)
                {
                    mouseButton = MouseButton.Middle;
                }
                PointerPoint = p;
                MouseUp?.Invoke(this, mouseButton);
            };

           
        }
        public IReadOnlyList<MouseButton> SupportedButtons => new List<MouseButton> { 
            MouseButton.Left,
            MouseButton.Right,
            MouseButton.Middle,
        };

        public IReadOnlyList<ScrollWheel> ScrollWheels => throw new NotImplementedException();

        public Vector2 Position {
            get;
            set;

        }

        public ICursor Cursor => throw new NotImplementedException();

        public int DoubleClickTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DoubleClickRange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => "AvaloniaMouse";

        public int Index => 0;

        public bool IsConnected => true;

        public event Action<IMouse, MouseButton> MouseDown = (m, b) => { };
        public event Action<IMouse, MouseButton> MouseUp = (m, b) => { };
        public event Action<IMouse, MouseButton, Vector2> Click = (m, b, p) => { };
        public event Action<IMouse, MouseButton, Vector2> DoubleClick = (m, b, p) => { };
        public event Action<IMouse, Vector2> MouseMov = (m,  p) => { };
        public event Action<IMouse, ScrollWheel> Scroll = (m,s) => { };
        public event Action<IMouse, Vector2> MouseMove = (m, v) => { };

        public bool IsButtonPressed(MouseButton btn)
        {
            if (PointerPoint == null)
                return false;
            global::Avalonia.Input.PointerPoint p = (global::Avalonia.Input.PointerPoint)PointerPoint;
            if (btn == MouseButton.Left)
                return p.Properties.IsLeftButtonPressed;
            if (btn == MouseButton.Right)
                return p.Properties.IsRightButtonPressed;
            if (btn == MouseButton.Middle)
                return p.Properties.IsMiddleButtonPressed;
            return false;
        }
    }
}
