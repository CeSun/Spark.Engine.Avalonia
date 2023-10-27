using Avalonia;
using Avalonia.Controls;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Silk.NET.OpenGLES;
using Spark.Engine.Platform;
using System.Diagnostics;

namespace Spark.Engine.Avalonia
{
    public enum RenderQuality
    {
        High,
        Low 
    }
    public class SparkEngine : OpenGlControlBase
    {

        private Stopwatch stopwatch = new Stopwatch();

        public RenderQuality RenderQuality { get; set; } = RenderQuality.Low;

        Engine? Engine;

        public SparkEngine()
        {
        }
        
        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            base.OnSizeChanged(e);
            

            if (Engine != null )
            {
                Engine.Resize((int)(Bounds.Width * VisualRoot.RenderScaling), (int)(Bounds.Height * VisualRoot.RenderScaling));
            }
        }


        protected override void OnOpenGlRender(GlInterface gl, int fb)
        {
            if (Engine == null)
            {
                var api = GL.GetApi(gl.GetProcAddress);
                var fbo = api.GetInteger(GLEnum.FramebufferBinding);
                Engine = new Engine();
                Engine.InitEngine(new string[] { }, new Dictionary<string, object>
                {
                    { "OpenGL", GL.GetApi(gl.GetProcAddress) },
                    { "WindowSize", new System.Drawing.Point((int)(Bounds.Width * VisualRoot.RenderScaling), (int)(Bounds.Height * VisualRoot.RenderScaling)) },
                    { "InputContext",null},
                    { "FileSystem", FileSystem.Instance},
                    { "View", null },
                    { "IsMobile", RenderQuality == RenderQuality.Low },
                    { "DefaultFBOID", fbo }
                });
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
            RequestNextFrameRendering();


        }

        protected override void OnOpenGlDeinit(GlInterface gl)
        {
            if (Engine == null)
                return;
            Engine.Stop();
        }
    }
}
