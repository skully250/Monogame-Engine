using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Experiments
{
    class SpriteSheet
    {
        //Spritesheet variables
        private int m_size;
        private string m_path;


        //Spritesheet textures
        private Texture2D texture;
        private string[] sheetNames;
        public Vector2 spriteGridSize;

        public Dictionary<string, Sprite> spriteGrid { get; set; }

        private SpriteSheet(Vector2 sheetSize, int size, string path, ContentManager content)
        {
            spriteGridSize = sheetSize;
            spriteGrid = new Dictionary<string, Sprite>();
            texture = content.Load<Texture2D>(path);
            m_size = size;
            m_path = path;
        }

        public SpriteSheet(Vector2 sheetSize, int size, string path, ContentManager content, bool named) : this(sheetSize, size, path, content)
        {
            init(named);
        }

        public SpriteSheet(Vector2 sheetSize, int size, string path, ContentManager content, string[] names) : this(sheetSize, size, path, content, true)
        {
            sheetNames = names;
        }

        public SpriteSheet(Vector2 sheetSize, Vector2 offsets, int size, string path, ContentManager content) : this(sheetSize, size, path, content)
        {
            init(false, offsets);
        }

        public SpriteSheet(Vector2 sheetSize, Vector2 offsets, int size, string path, ContentManager content, string[] names) : this(sheetSize, size, path, content)
        {
            sheetNames = names;
            init(true, offsets);
        }

        private void init(bool split, Vector2? offset = null)
        {
            if (offset == null)
                SplitSheet(split);
            else
                SplitSheet(split, offset);
        }

        private void SplitSheet(bool named)
        {
            int count = 0;
            for (int y = 0; y < spriteGridSize.Y; y++)
            {
                for (int x = 0; x < spriteGridSize.X; x++)
                {
                    var position = new Rectangle(x * m_size, y * m_size, m_size, m_size);
                    if (!named)
                    {
                        spriteGrid.Add(count.ToString(), new Sprite(this, position));
                    }
                    else
                    {
                        spriteGrid.Add(sheetNames[count], new Sprite(this, position));
                    }
                    count++;
                }
            }
        }

        private void SplitSheet(bool named, Vector2? offset)
        {
            if (offset == null)
                return;
            //OFfset rendering code
            int count = 0;
            for (int y = 0 + (int)offset.Value.Y; y < spriteGridSize.Y; y++)
            {
                for (int x = 0 + (int)offset.Value.X; x < spriteGridSize.X; x++)
                {
                    var position = new Rectangle(x * m_size, y * m_size, m_size, m_size);
                    if (named)
                        spriteGrid.Add(sheetNames[count], new Sprite(this, position));
                    else
                        spriteGrid.Add(count.ToString(), new Sprite(this, position));
                    count++;
                }
            }
        }

       public void Draw(int count, Vector2 position, SpriteBatch spriteBatch)
        {
            Sprite sprite;
            spriteGrid.TryGetValue(count.ToString(), out sprite);
            sprite.Draw(position, spriteBatch);
        }

        public void Draw(int count, Vector2 position, Rectangle size, SpriteBatch spriteBatch)
        {
            Sprite sprite;
            spriteGrid.TryGetValue(count.ToString(), out sprite);
            spriteBatch.Draw(texture, size, sprite.m_sheetPos, Color.White);
        }

        public void Draw(string name, Vector2 position, SpriteBatch spriteBatch)
        {
            Sprite sprite;
            spriteGrid.TryGetValue(name, out sprite);
            sprite.Draw(position, spriteBatch);
        }

        public void Draw(Sprite sprite, Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sprite.m_sheetPos, Color.White);
        }
    }
}
