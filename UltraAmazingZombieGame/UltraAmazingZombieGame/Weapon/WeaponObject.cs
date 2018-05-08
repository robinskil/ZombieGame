using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace UltraAmazingZombieGame.Weapon
{
    public abstract class WeaponObject
    {
        public abstract string name { get; protected set; }
        public abstract int cost { get; protected set; }
        public abstract int magazineSize { get; protected set; }
        public abstract int totalBullets { get; protected set; }
        public abstract int bulletsInMagazine { get; protected set; }
        public abstract int bulletDamage { get; protected set; } // damage of bullets
        public abstract int Range { get; protected set; } // weapon range in pixels
        public abstract double reloadTime{get;protected set;}
        public abstract bool readyToFire{get;protected set;}
        public abstract bool playerOwned{get;protected set;}
        public Vector2 position{get;protected set;}
        public WeaponObject(Vector2 pos)
        {
            this.position = pos;
        }
        public abstract void shoot(SpriteBatch spritebatch , Vector2 playerPos);
        //TEST SHOOT NO ARGUMENTS
        public abstract void shoot();
        public abstract void reload();
        public abstract void drawWeapon(SpriteBatch spritebatch);
        public abstract void weaponPickedUp();
        public abstract void updatePosition(Vector2 pos);

        
    }
}