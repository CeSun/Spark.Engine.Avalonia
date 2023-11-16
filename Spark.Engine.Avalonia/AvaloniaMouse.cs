
using Avalonia.Controls;
using Silk.NET.Input;
using System.Numerics;

namespace Spark.Engine.Avalonia
{
    internal class AvaloniaMouse : IMouse
    {
        SparkEngine control;

        global::Avalonia.Input.PointerPoint? PointerPoint;

        bool IsPressed = false;

        public AvaloniaMouse(SparkEngine control) 
        { 
            this.control = control;

            this.control.PointerMoved += (s, e) =>
            {
                if (IsPressed == false)
                    return;
                PointerPoint = e.GetCurrentPoint(s as Control);
                var p = e.GetPosition(this.control);
                Position = new Vector2((float)p.X * control.Scale, (float)p.Y * control.Scale);
                MouseMove?.Invoke(this, Position);

            };

            this.control.PointerPressed += (s, e) =>
            {
                if (IsPressed == true)
                    return;
                IsPressed = true;
                var _PointerPoint = e.GetCurrentPoint(s as Control);
                var p = e.GetPosition(this.control);
                Position = new Vector2((float)p.X * control.Scale, (float)p.Y * control.Scale);
                MouseButton mouseButton = MouseButton.Unknown;
                if (_PointerPoint.Properties.IsLeftButtonPressed)
                {
                    mouseButton = MouseButton.Left;
                }

                if (_PointerPoint.Properties.IsRightButtonPressed)
                {
                    mouseButton = MouseButton.Right;
                }
                if (_PointerPoint.Properties.IsMiddleButtonPressed)
                {
                    mouseButton = MouseButton.Middle;
                }
                PointerPoint = _PointerPoint;
                MouseDown?.Invoke(this, mouseButton);
            };


            this.control.PointerReleased += (s, e) =>
            {
                if (IsPressed == false)
                    return;
                IsPressed = false;
                var _PointerPoint = e.GetCurrentPoint(s as Control);
                var p = e.GetPosition(this.control);
                Position = new Vector2((float)p.X * control.Scale, (float)p.Y * control.Scale);
                MouseButton mouseButton = MouseButton.Unknown;
                if (_PointerPoint.Properties.IsLeftButtonPressed)
                {
                    mouseButton = MouseButton.Left;
                }

                if (_PointerPoint.Properties.IsRightButtonPressed)
                {
                    mouseButton = MouseButton.Right;
                }
                if (_PointerPoint.Properties.IsMiddleButtonPressed)
                {
                    mouseButton = MouseButton.Middle;
                }
                PointerPoint = _PointerPoint;
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
