using FaeForest.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FaeForest.Entity
{
    class Entity : IEntity
    {
        private Sprite m_sprite;
        private Vector2 m_position;
        private EntityStateEngine states;

        public Entity(Vector2 position, Sprite sprite)
        {
            m_sprite = sprite;
            m_position = position;
            states = new EntityStateEngine();
        }

        public void render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            m_sprite.Draw(m_position, spriteBatch);
        }

        public void update(GameTime gameTime)
        {
            
        }
    }
}