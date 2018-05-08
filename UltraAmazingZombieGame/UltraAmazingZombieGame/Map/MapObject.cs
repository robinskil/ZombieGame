using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace UltraAmazingZombieGame.Map
{
    public abstract class MapObject
    {
        public Vector2 position{get;set;}
        public Size2 blockSize { get; }
        public MapObject(float x , float y , float blockSize)
        {
            this.position = new Vector2(x, y);
            this.blockSize = new Size2(blockSize, blockSize);
        }   
        public abstract void DrawObject(SpriteBatch spriteBatch);
        public abstract bool Collision(RectangleF rectOther);
    }

}