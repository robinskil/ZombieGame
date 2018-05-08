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
    public class Glock17 : WeaponObject
    {
        //public Stack<Action> stacked;
        //public virtual Action a {get;protected set;} = () => Console.WriteLine("");
        public override string name { get; protected set; } = "Glock 17";
        public override int cost { get; protected set; } = 5000;
        public override int totalBullets { get; protected set; } = 180;
        public override int magazineSize { get; protected set; } = 12;
        public override int bulletsInMagazine { get; protected set; } = 12;
        public override int bulletDamage { get; protected set; } = 25;
        public override int Range { get; protected set; } = 300;
        public override double reloadTime { get; protected set; } = 1.25;
        public override bool readyToFire { get; protected set; } = false;
        public override bool playerOwned { get; protected set; } = false;
        public Glock17(Vector2 pos) : base(pos)
        {
            //this.stacked = new Stack<Action>();
            //Action x = () => Console.WriteLine("LOL");   
            //this.stacked.Push(x);
            //this.stacked.Take(1).ToArray()[0]();
        }
        public override void reload()
        {
            //TODO TIMER EVENTS
            totalBullets -= magazineSize;
            bulletsInMagazine = magazineSize;
        }

        public override void shoot(SpriteBatch spritebatch, Vector2 playerPos)
        {
            //create new bullet and deplete the magazine
            throw new NotImplementedException();
        }

        public override void weaponPickedUp()
        {
            readyToFire = true;
            playerOwned = true;
        }

        public override void drawWeapon(SpriteBatch spritebatch)
        {
            spritebatch.FillRectangle(new RectangleF(position.X, position.Y, 8, 8), Color.Gold);
        }

        public override void shoot()
        {
            this.bulletsInMagazine -= 1;
        }

        public override void updatePosition(Vector2 pos)
        {
            this.position = pos;
        }
        
    }
}