using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using UltraAmazingZombieGame.Weapon;

namespace UltraAmazingZombieGame.Entity
{
    public class Player : Entity
    {
        private WeaponObject[] weapons = new WeaponObject[1];
        public int Points { get; private set; }
        public override int health { get; protected set; }
        public Player(float x, float y, string username, float size = 16) : base(x, y, size)
        {
            //Starting health = 100;
            health = 100;
            //Starting amount = 5000;
            Points = 5000;
        }
        //Second constructor that uses a Vector2 parameter;
        public Player(Vector2 pos, string username, float size = 16) : base(pos, size)
        {
            //Starting health = 100;
            health = 100;
            //Starting amount = 5000;
            Points = 5000;
        }

        //draw the player itself here
        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.FillRectangle(new RectangleF(this.position.X, this.position.Y, size.Width, size.Height), Color.Blue);
            //Draw weapon if available
            if (weapons[0] != null)
            {
                weapons[0].updatePosition(this.position);
                weapons[0].drawWeapon(spritebatch);
                //draw hud for player with weapon ammo etc.
            }
        }

        public void LoseHealth(int amount)
        {
            this.health -= amount;
        }
        public void Respawn(Vector2 pos)
        {
            this.position = pos;
        }

        public void LosePoints(int amount)
        {
            this.Points -= amount;
        }
        //Draw player hud here
        public override void DrawHud(SpriteBatch spritebatch, SpriteFont font , GraphicsDevice device )
        {
            spritebatch.Begin();
            // Player hud consistently drawn here.
            string pointsAmount = $"Points : {this.Points}";
            //Vector2 posString = new Vector2((d.Viewport.Width / 2) - (font.MeasureString(pointsAmount).X / 2),
            //    (pointsAmount) - (font.MeasureString(costString).Y) * 2);
            Vector2 posString = StaticDefinitionMethods.CenterStringPos(pointsAmount, 1200F , 740F , font);
            Vector2 posStringHealth = StaticDefinitionMethods.CenterStringPos(pointsAmount, 1200F , 720F , font);
            spritebatch.DrawString(font,pointsAmount, posString , Color.Red);
            spritebatch.DrawString(font,$"Health : {this.health}", posStringHealth , Color.Red);
            spritebatch.FillRectangle(new RectangleF(1120,660,200,100),Color.FromNonPremultiplied(new Vector4(1F,1F,1F,0.2F)));
            if(weapons[0]!= null){
                Vector2 posStringAmmo = StaticDefinitionMethods.CenterStringPos(pointsAmount, 100F , 720F , font);
                spritebatch.DrawString(font,$"{weapons[0].bulletsInMagazine } / {weapons[0].totalBullets}", posStringAmmo , Color.White);
                
            }
            spritebatch.End();
        }

        public bool PickUpWeapon(WeaponObject weapon)
        {
            if (this.weapons[0]==null)
            {
                this.weapons[0] = weapon;
                return true;
            }
            else return false;
        }

        public override void MoveDown()
        {
            position = new Vector2(this.position.X, this.position.Y + 2);
        }

        public override void MoveLeft()
        {
            position = new Vector2(this.position.X - 2, this.position.Y);
        }

        public override void MoveRight()
        {
            position = new Vector2(this.position.X + 2, this.position.Y);
        }

        public override void MoveUp()
        {
            position = new Vector2(this.position.X, this.position.Y - 2);
        }
        
        public void shoot(Vector2 target){
            if(weapons[0] != null && weapons[0].bulletsInMagazine > 0){
                weapons[0].shoot(target);
            } else {
                weapons[0].reload();
            }
        }
    }
}
