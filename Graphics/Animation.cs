using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaeForest.Graphics
{
    class Animation
    {
        Vector2 m_position;
        Sprite[] sprites;
        int m_frames;
        int m_size;

        public Animation(SpriteSheet sheet, int size, int x, int y, int frames)
        {
            size = m_size;
            //Spritesheet code to find and load animation
            sprites = sheet.FindAnimation(x, y, frames);
        }

        public void Draw(SpriteBatch batch, Vector2 position, int frame)
        {
            //Draw and scale to see how it looks
            var size = new Rectangle((int)m_position.X, (int)m_position.Y, m_size, m_size);
            sprites[frame].Draw(position, batch);
        }
    }
}
