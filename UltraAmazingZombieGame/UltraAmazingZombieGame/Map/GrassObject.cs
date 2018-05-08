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
    public class GrassObject : MapObject
    {
        public GrassObject(float x , float y , float blockSize) : base (x,y,blockSize)
        {

        }

        public override bool Collision(RectangleF rectOther)
        {
            return false;
        }

        public override void DrawObject(SpriteBatch spriteBatch)
        {
            spriteBatch.FillRectangle(new RectangleF(this.position.X,this.position.Y,this.blockSize.Width,this.blockSize.Height),Color.Green);
        }
    }
}