using SharpGLTF.Schema2;
using Silk.NET.Input;
using Spark.Engine;
using Spark.Engine.Actors;
using Spark.Engine.Assets;
using Spark.Engine.Components;
using Spark.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SparkDemo
{
    public class Character : Actor
    {
        public StaticMeshComponent Mesh { get; set; }

        public CameraComponent Camera { get; set; }
        public Character(Level level, string Name = "") : base(level, Name)
        {
            Mesh = new StaticMeshComponent(this);
            Mesh.StaticMesh = StaticMesh.LoadFromGLB("/StaticMesh/Soldier.glb");
            Mesh.IsStatic = true;
            RootComponent = Mesh;


            Camera = new CameraComponent(this);
            Camera.ParentComponent = Mesh;
            Camera.NearPlaneDistance = 1;
            Camera.FarPlaneDistance = 100;

            Camera.RelativeLocation = Vector3.Zero - 2 * Camera.ForwardVector + 3 * Camera.UpVector;
            Camera.RelativeRotation = Quaternion.CreateFromYawPitchRoll(0, -30F.DegreeToRadians(), 0);
        }

        protected override void OnUpdate(double DeltaTime)
        {
            base.OnUpdate(DeltaTime);

            if (CurrentWorld.Engine.MainKeyBoard.IsKeyPressed(Key.W))
            {
                Console.WriteLine("W 按下了！");
            }
        }
    }
}
