using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using UltraAmazingZombieGame.Weapon;

namespace UltraAmazingZombieGame.Map
{
    public class WallWeaponObject : WallObject
    {
        private bool containWeapon = false;
        private WeaponObject weapon;
        private RectangleF buyRect;
        public WallWeaponObject(float x, float y, float blockSize) : base(x, y, blockSize)
        {
            this.buyRect = new RectangleF(x - blockSize, y - blockSize, blockSize * 2, blockSize * 2);
            this.weapon = new Glock17(new Vector2(this.position.X + this.blockSize.Width / 2 - 4, this.position.Y + this.blockSize.Height / 2 - 4));
            this.containWeapon = true;
        }

        public override void DrawObject(SpriteBatch spriteBatch)
        {
            spriteBatch.FillRectangle(new RectangleF(this.position.X, this.position.Y, this.blockSize.Width, this.blockSize.Height), Color.Gray);
            if (containWeapon == true)
            {
                //Console.WriteLine("Draw weapon");   
                weapon.drawWeapon(spriteBatch);
            }
        }

        public bool buyCollision(RectangleF rectOther, SpriteBatch spriteBatch, SpriteFont font, float screenWidth, float screenHeight)
        {
            var hitRect = new RectangleF(this.wallRect.X - this.wallRect.Width, this.wallRect.Y - this.wallRect.Width, this.wallRect.Width * 3, this.wallRect.Height * 3);
            //Console.WriteLine(rectOther.ToString() + "\n" + hitRect.ToString());
            if (hitRect.Intersects(rectOther) == true)
            {
                //Console.WriteLine("Test");
                //Draw string for buy hud
                spriteBatch.Begin();
                string message = $"Press F to buy {this.weapon.name} ";
                string costString = $"Cost : {this.weapon.cost} points";
                spriteBatch.DrawString(font, message, new Vector2((screenWidth / 2) - (font.MeasureString(message).X / 2),
                (screenHeight) - (font.MeasureString(message).Y) * 3), Color.White);
                spriteBatch.DrawString(font, costString, new Vector2((screenWidth / 2) - (font.MeasureString(costString).X / 2),
                (screenHeight) - (font.MeasureString(costString).Y) * 2), Color.White);
                spriteBatch.End();
                return true;
            }
            else return false;
        }
        public WeaponObject weaponBought()
        {
            //Copying weapon
            var pickedUpWeapon = new Glock17(new Vector2(weapon.position.X, weapon.position.Y));
            pickedUpWeapon.weaponPickedUp();
            return pickedUpWeapon;
        }

        // Return a deep clone of an object of type T.
    }
}