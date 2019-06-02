using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaeForest.Graphics
{
    class Sprite
    {
        SpriteSheet m_sheet;
        public Rectangle m_sheetPos { get; private set; }

        public Sprite(SpriteSheet sheet, Rectangle sheetPos)
        {
            m_sheet = sheet;
            m_sheetPos = sheetPos;
        }

        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            m_sheet.Draw(this, position, spriteBatch);
        }
    }
}