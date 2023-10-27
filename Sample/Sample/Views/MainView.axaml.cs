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

            EngineControl.BeginPlay += level =>
            {
                var lightActor = new Actor(level, "");
                var lightc = new DirectionLightComponent(lightActor);
                lightc.LightStrength = 1;
                lightc.RelativeRotation = Quaternion.CreateFromYawPitchRoll(0, -90, 0);
                lightActor.RootComponent = lightc;
                lightc.Color = Color.White;

                var SkyBoxActor = new Actor(level, "SkyBox Actor");
                var skybox = new SkyboxComponent(SkyBoxActor);
                SkyBoxActor.RootComponent = skybox;
                TextureCube.LoadAsync("/Skybox/pm").Then(res => {
                    skybox.SkyboxCube = res;
                });

                var character = new Character(level);

            };
        }



    }
}


