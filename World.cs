using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Experiments
{
    class World
    {
        private Vector2 size;
        private Dictionary<String, Sprite> sprites;
        String[,] map;
        SpriteBatch spriteBatch;

        public World(Dictionary<String, Sprite> sprites, Vector2 size, SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
            this.sprites = sprites;
            this.size = size;
            map = new string[(int)size.Y, (int)size.X];
            //TODO: make it automatic
            randomise();
        }

        public void randomise()
        {
            Random random = new Random();
            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    map[y, x] = random.Next(0, 9).ToString();
                }
            }
        }

        public void Draw()
        {
            //Iterating through a map and drawing each sprite
            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    Sprite render;
                    sprites.TryGetValue(map[y, x], out render);
                    render.Draw(new Vector2(x * 32, y * 32), spriteBatch);
                }
            }
        }

        public void update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                randomise();
            }
        }
    }
}