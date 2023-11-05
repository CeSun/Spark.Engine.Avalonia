using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Rendering;
using Silk.NET.OpenGLES;
using Spark.Engine.Platform;
using System.Diagnostics;
using System.Drawing;

namespace Spark.Engine.Avalonia
{
    public enum RenderQuality
    {
        High,
        Low 
    }
    public class SparkEngine : OpenGlControlBase, ICustomHitTest
    {
        public static readonly StyledProperty<RenderQuality> RenderQualityProperty =
        AvaloniaProperty.Register<SparkEngine, RenderQuality>(nameof(RenderQuality), defaultValue: RenderQuality.Low);

        

        public event Action<Level>? BeginPlay;
        public event Action<Level>? EndPlay;
        public RenderQuality RenderQuality 
        { 
            get => GetValue(RenderQualityProperty); 
            set => SetValue(RenderQualityProperty, value); 
        }

        private Stopwatch stopwatch = new Stopwatch();

        Engine? Engine;

        public SparkEngine()
        {
            Focusable = true;

            
        }
        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            base.OnSizeChanged(e);
            

            if (Engine != null )
            {
                Engine.Resize((int)(Bounds.Width * VisualRoot.RenderScaling), (int)(Bounds.Height * VisualRoot.RenderScaling));
            }
        }

        protected override void OnOpenGlInit(GlInterface gl)
        {
            base.OnOpenGlInit(gl);

            RequestNextFrameRendering();
        }
        protected override void OnOpenGlRender(GlInterface gl, int fb)
        {
            var api = GL.GetApi(gl.GetProcAddress);
            var fbo = api.GetInteger(GLEnum.FramebufferBinding);

            if (Engine == null)
            {
                Engine = new Engine();
                Engine.InitEngine(new string[] { }, new Dictionary<string, object>
                {
                    { "OpenGL", GL.GetApi(gl.GetProcAddress) },
                    { "WindowSize", new System.Drawing.Point((int)(Bounds.Width * VisualRoot.RenderScaling), (int)(Bounds.Height * VisualRoot.RenderScaling)) },
                    { "InputContext", new AvaloniaInput(this)},
                    { "FileSystem", FileSystem.Instance},
                    { "View", null },
                    { "IsMobile", RenderQuality == RenderQuality.Low },
                    { "DefaultFBOID", fbo }
                });
                Engine.OnBeginPlay = BeginPlay;
                Engine.OnEndPlay = EndPlay;
                stopwatch.Start();
                Engine.Start();

               

            }
            else
            {
                var dt = stopwatch.ElapsedMilliseconds / 1000.0f;
                stopwatch.Restart();
                Engine.Update(dt);
                Engine.Render(dt);
            }
            api.ClearColor(Color.AliceBlue);
            api.Clear(ClearBufferMask.ColorBufferBit);
            RequestNextFrameRendering();


        }

        protected override void OnOpenGlDeinit(GlInterface gl)
        {
            if (Engine == null)
                return;
            Engine.Stop();
        }

        public bool HitTest(global::Avalonia.Point point)
        {
            return true;
        }
    }
}
