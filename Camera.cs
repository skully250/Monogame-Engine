using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace FaeForest
{
    class Camera
    {
        public static Vector2 position, origin;
        public static float zoom, rotation, cameraSpeed;
        private static bool UpdateMatrix;

        public static float maxZoom { get; set; }
        public static float minZoom { get; set; }

        public static Rectangle viewport { get; set; }
        public static Rectangle worldRect { get; set; }

        public static Matrix transform = Matrix.Identity;

        public static void initialise(Rectangle mainViewport)
        {
            viewport = mainViewport;
            maxZoom = .6f;
            minZoom = 2f;
            cameraSpeed = 6f;
            rotation = 0.0f;
            position = new Vector2(0, 0);
            ZoomBy(1f);
            origin = new Vector2(0, 0);
            worldRect = World.WorldRect;
        }

        public static void ZoomBy(float amount)
        {
            zoom += amount;
            zoom = MathHelper.Clamp(zoom, maxZoom, minZoom);
            UpdateMatrix = true;
        }

        public static void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position += new Vector2(-cameraSpeed, 0);
                UpdateMatrix = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position += new Vector2(cameraSpeed, 0);
                UpdateMatrix = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position += new Vector2(0, cameraSpeed);
                UpdateMatrix = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position += new Vector2(0, -cameraSpeed);
                UpdateMatrix = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                ZoomBy(0.03f);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                ZoomBy(-0.03f);

            if (position.X < viewport.Left / zoom)
                position.X = viewport.Left / zoom;
            if (position.Y < viewport.Top / zoom)
                position.Y = viewport.Top / zoom;
            if (position.X > World.WorldRect.Width - viewport.Right / zoom)
                position.X = World.WorldRect.Width - viewport.Right / zoom;
            if (position.Y > World.WorldRect.Height - viewport.Bottom / zoom)
                position.Y = World.WorldRect.Height - viewport.Bottom / zoom;
        }

        public static Matrix TransformMatrix()
        {
            if (UpdateMatrix)
            {
                transform = Matrix.CreateTranslation(new Vector3(-position, 0)) 
                    * Matrix.CreateRotationZ(rotation) 
                    * Matrix.CreateScale(new Vector3(zoom, zoom, 0)) 
                    * Matrix.CreateTranslation(new Vector3(origin, 0));
                UpdateMatrix = false;
            }
            //Console.WriteLine(World.WorldRect);
            return transform;
        }
    }
}
