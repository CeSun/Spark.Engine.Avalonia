using Avalonia.Controls;
using Spark.Engine.Avalonia;
using Spark.Engine.Platform;

namespace Sample.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            FileSystem.Init(new DesktopFileSystem());
            EngineControl.RenderQuality = RenderQuality.Low;
        }
    }
}