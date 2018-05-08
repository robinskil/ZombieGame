using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace UltraAmazingZombieGame.Weapon.Bullet
{
    public class Bullet : IDisposable
    {
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public Vector2 position { get; private set; }
        public Vector2 startPosition { get; private set; }
        public Vector2 targetPos { get; private set; }
        public int bulletDamage { get; private set; }
        public int range { get; private set; }
        private float moveXStep { get; set; }
        private float moveYStep { get; set; }
        public Bullet(float x, float y, Vector2 mousePos, int range, int bulletDamage)
        {
            this.startPosition = new Vector2(x, y);
            this.position = new Vector2(startPosition.X, startPosition.Y);
            this.targetPos = mousePos;
            this.bulletDamage = bulletDamage;
            this.range = range;
            CalculatePath();
        }
        public Bullet(Vector2 pos, Vector2 mousePos, int range, int bulletDamage)
        {
            this.startPosition = pos;
            this.position = pos;
            this.targetPos = mousePos;
            this.bulletDamage = bulletDamage;
            this.range = range;
            CalculatePath();
        }

        private void CalculatePath()
        {
            //Calculate pathing
            if (this.startPosition.X > this.targetPos.X && this.startPosition.Y > this.targetPos.Y)
            {
                
            }
            else if (this.startPosition.X < this.targetPos.X && this.startPosition.Y > this.targetPos.Y)
            {

            }
            else if (this.startPosition.X < this.targetPos.X && this.startPosition.Y < this.targetPos.Y)
            {

            }
            else if (this.startPosition.X > this.targetPos.X && this.startPosition.Y < this.targetPos.Y)
            {

            }
            //TODO what if target pos x = start pos....

        }
        public void Move()
        {
            this.position = new Vector2(this.position.X + moveXStep, this.position.Y + moveYStep);
            Dispose();
        }
        public void DrawBullet(SpriteBatch spriteBatch)
        {
            spriteBatch.FillRectangle(new RectangleF(this.position.X, this.position.Y, 4, 2), Color.Red);
        }

        public void Dispose()
        {
            handle.Dispose();
        }
    }
}