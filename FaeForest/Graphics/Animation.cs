using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FaeForest.Graphics
{
    class Animation
    {
        Sprite[] sprites;
        int m_size;

        public Animation(SpriteSheet sheet, int size, int x, int y, int frames)
        {
            m_size = sheet.m_sizeX;
            //Spritesheet code to find and load animation
            sprites = sheet.FindAnimation(x, y, frames);
        }

        public void Draw(SpriteBatch batch, Vector2 position, int frame)
        {
            //Draw and scale to see how it looks
            sprites[frame].Draw(position, batch);
        }

        public void ScaledDraw(SpriteBatch batch, Vector2 position, float scale, int frame)
        {
            sprites[frame].ScaledDraw(position, batch, scale);
        }
    }
}
