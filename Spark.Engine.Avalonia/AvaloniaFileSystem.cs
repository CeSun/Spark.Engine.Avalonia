using Avalonia.Platform;
using Spark.Engine.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Engine.Avalonia;

public class AvaloniaFileSystem : FileSystem
{

    public static void InitAvaloniaFileSystem(string Assembly)
    {
        FileSystem.Init(new AvaloniaFileSystem(Assembly));
    }
    private string Assembly;
    private AvaloniaFileSystem(string Assembly)
    {
        this.Assembly = Assembly;
    }
    public Stream GetStream(string path)
    {
        return AssetLoader.Open(new Uri($"avares://{Assembly}/Assets/{path}"));
    }

    public StreamReader GetStreamReader(string path)
    {
        return new StreamReader(AssetLoader.Open(new Uri($"avares://{Assembly}/Assets/{path}")));
    }

    public string LoadText(string path)
    {
        using (var sr = new StreamReader(AssetLoader.Open(new Uri($"avares://{Assembly}/Assets/{path}"))))
        {
            return sr.ReadToEnd();
        }
    }
}
