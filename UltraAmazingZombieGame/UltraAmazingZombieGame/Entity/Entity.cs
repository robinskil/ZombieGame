using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace UltraAmazingZombieGame.Entity
{
    public abstract class Entity
    {
        public abstract int health{get;protected set;}
        public virtual Vector2 position {get;set;}

        public virtual Size2 size {get;set;}
        public Entity(float x , float y , float size = 16){
            this.position = new Vector2(x,y);
            this.size = new Size2(size,size);
        }
        public Entity(Vector2 pos , float size = 16){
            this.position = pos;
            this.size = new Size2(size,size);
        }
        public abstract void MoveRight();
        public abstract void MoveLeft();
        public abstract void MoveUp();
        public abstract void MoveDown();
        public abstract void Draw(SpriteBatch spritebatch);
        public abstract void DrawHud(SpriteBatch spritebatch , SpriteFont font , GraphicsDevice device);

    }
}
