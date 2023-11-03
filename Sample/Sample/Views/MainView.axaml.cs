using Avalonia.Controls;
using Spark.Engine;
using Spark.Engine.Actors;
using Spark.Engine.Assets;
using Spark.Engine.Avalonia;
using Spark.Engine.Components;
using Spark.Engine.Platform;
using Spark.Util;
using SparkDemo;
using System.Drawing;
using System.Numerics;

namespace Sample.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            EngineControl.BeginPlay += SparkDemo.SparkDemo.BeginPlay;
        }



    }
}


