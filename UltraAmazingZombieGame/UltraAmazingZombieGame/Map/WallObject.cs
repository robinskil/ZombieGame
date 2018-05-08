using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using UltraAmazingZombieGame.Weapon;

namespace UltraAmazingZombieGame.Map
{
    public class WallObject : MapObject
    {
        protected static Random r = new Random();
        protected RectangleF wallRect;
        public WallObject(float x , float y , float blockSize) : base (x,y,blockSize)
        {
            this.wallRect = new RectangleF(x,y,blockSize,blockSize);    
        }

        public override void DrawObject(SpriteBatch spriteBatch)
        {
            spriteBatch.FillRectangle(new RectangleF(this.position.X,this.position.Y,this.blockSize.Width,this.blockSize.Height),Color.Gray);
        }

        public override bool Collision(RectangleF rectOther){
            if(this.wallRect.Intersects(rectOther) == true){
                return true;
            }
            else return false;
        }

    }
}