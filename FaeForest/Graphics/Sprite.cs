using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public void ScaledDraw(Vector2 position, SpriteBatch spriteBatch, float scale)
        {
            m_sheet.ScaledDraw(this, position, spriteBatch, scale);
        }
    }
}