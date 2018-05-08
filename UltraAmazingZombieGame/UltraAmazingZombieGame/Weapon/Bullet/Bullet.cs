using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace UltraAmazingZombieGame.Weapon.Bullet
{
    public class Bullet{
        public Vector2 position {get;private set;}
        public Vector2 startPosition {get;private set;}
        public Vector2 mousePos {get;private set;}
        public Bullet(float x , float y , Vector2 mousePos){
            this.startPosition = new Vector2(x,y);
            this.position = new Vector2(startPosition.X,startPosition.Y);
            this.mousePos = mousePos;
            CalculatePath();
        }
        public Bullet(Vector2 pos , Vector2 mousePos){
            this.startPosition = pos;
            this.position = pos;
            this.mousePos = mousePos;
            CalculatePath();
        }

        private void CalculatePath()
        {
            
        }
        public void Move(){
            
        }
        public void DrawBullet(SpriteBatch spriteBatch){
            spriteBatch.FillRectangle(new RectangleF(this.position.X,this.position.Y,4,2),Color.Red);
        }
    }
}