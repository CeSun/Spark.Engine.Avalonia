using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using Spark.Engine.Platform;
using System.IO;

namespace Sample.Android
{
    [Activity(
        Label = "Sample.Android",
        Theme = "@style/MyTheme.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : AvaloniaMainActivity<App>
    {
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            FileSystem.Init(new AndroidFileSystem(Assets));
            return base.CustomizeAppBuilder(builder)
                .WithInterFont()
                .UseReactiveUI();
        }
    }
    public class AndroidFileSystem : FileSystem
    {
        public AndroidFileSystem(AssetManager AssetManager)
        {
            this.AssetManager = AssetManager;
        }
        AssetManager AssetManager;
        public StreamReader GetStreamReader(string path)
        {
            var filesize = 1024 * 1024 * 2;
            using var stream = new BinaryReader(AssetManager.Open(path));
            byte[] buffer = stream.ReadBytes(filesize);
            return new StreamReader(new MemoryStream(buffer));
        }

        public string LoadText(string path)
        {
            using (var sr = new StreamReader(AssetManager.Open(path)))
            {
                return sr.ReadToEnd();
            }
        }

        public Stream GetStream(string path)
        {
            return AssetManager.Open(path);
        }
    }


}
