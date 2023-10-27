using Spark.Engine.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Engine.Avalonia;

public class DesktopFileSystem : FileSystem
{
    public Stream GetStream(string path)
    {
        return new StreamReader(path).BaseStream;
    }

    public StreamReader GetStreamReader(string path)
    {
        return new StreamReader(path);
    }

    public string LoadText(string path)
    {
        using (var sr = new StreamReader(path))
        {
            return sr.ReadToEnd();
        }
    }
}
