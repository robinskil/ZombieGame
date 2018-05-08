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
    public class BulletObject
    {
        public Vector2 position { get; private set; }
        public Vector2 startPosition { get; private set; }
        public Vector2 targetPos { get; private set; }
        public int bulletDamage { get; private set; }
        public int range { get; private set; }
        public bool bulletToBeDrawn { get; private set; } = true;
        private int AmountOfStepsTotal = 20;
        private float moveXStep { get; set; }
        private float moveYStep { get; set; }
        private RectangleF bulletRect { get; set; }
        public BulletObject(float x, float y, Vector2 mousePos, int range, int bulletDamage)
        {
            this.startPosition = new Vector2(x, y);
            this.position = new Vector2(startPosition.X, startPosition.Y);
            this.targetPos = mousePos;
            this.bulletDamage = bulletDamage;
            this.range = range;
            this.bulletRect = new RectangleF(startPosition.X, startPosition.Y, 2, 2);
            CalculatePath();
        }
        public BulletObject(Vector2 pos, Vector2 mousePos, int range, int bulletDamage)
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
            //this.moveXStep = 5;
            //this.moveYStep = 5;
            //Calculate pathing
            Console.WriteLine(this.startPosition + "\t" + this.targetPos);
            if (this.startPosition.X > this.targetPos.X && this.startPosition.Y > this.targetPos.Y)
            {
                float xDiff = this.startPosition.X - this.targetPos.X;
                float yDiff = this.startPosition.Y - this.targetPos.Y;
                float aSquared = xDiff * xDiff;
                float bSquared = yDiff * yDiff;
                float cSquared = aSquared + bSquared;
                float scale = this.range / (float)Math.Sqrt(cSquared);
                float xIncr = -xDiff * scale;
                float yIncr = -yDiff * scale;
                this.moveXStep = xIncr / this.AmountOfStepsTotal;
                this.moveYStep = yIncr / this.AmountOfStepsTotal;
                Console.WriteLine(moveXStep + "\t" + moveYStep);
            }
            else if (this.startPosition.X < this.targetPos.X && this.startPosition.Y > this.targetPos.Y)
            {
                float xDiff = this.targetPos.X - this.startPosition.X;
                float yDiff = this.startPosition.Y - this.targetPos.Y;
                float aSquared = xDiff * xDiff;
                float bSquared = yDiff * yDiff;
                float cSquared = aSquared + bSquared;
                float scale = this.range / (float)Math.Sqrt(cSquared);
                float xIncr = xDiff * scale;
                float yIncr = -yDiff * scale;
                this.moveXStep = xIncr / this.AmountOfStepsTotal;
                this.moveYStep = yIncr / this.AmountOfStepsTotal;
                Console.WriteLine(moveXStep + "\t" + moveYStep);

            }
            else if (this.startPosition.X < this.targetPos.X && this.startPosition.Y < this.targetPos.Y)
            {
                //range to both x/y
                float xDiff = this.targetPos.X - this.startPosition.X;
                float yDiff = this.targetPos.Y - this.startPosition.Y;
                float aSquared = xDiff * xDiff;
                float bSquared = yDiff * yDiff;
                float cSquared = aSquared + bSquared;
                float scale = this.range / (float)Math.Sqrt(cSquared);
                float xIncr = xDiff * scale;
                float yIncr = yDiff * scale;
                this.moveXStep = xIncr / this.AmountOfStepsTotal;
                this.moveYStep = yIncr / this.AmountOfStepsTotal;
                Console.WriteLine(moveXStep + "\t" + moveYStep);
            }
            else if (this.startPosition.X > this.targetPos.X && this.startPosition.Y < this.targetPos.Y)
            {
                float xDiff = this.startPosition.X - this.targetPos.X;
                float yDiff = this.targetPos.Y - this.startPosition.Y;
                float aSquared = xDiff * xDiff;
                float bSquared = yDiff * yDiff;
                float cSquared = aSquared + bSquared;
                float scale = this.range / (float)Math.Sqrt(cSquared);
                float xIncr = -xDiff * scale;
                float yIncr = yDiff * scale;
                this.moveXStep = xIncr / this.AmountOfStepsTotal;
                this.moveYStep = yIncr / this.AmountOfStepsTotal;
                Console.WriteLine(moveXStep + "\t" + moveYStep);
            }
            //TODO what if target pos x = start pos....

        }
        public void Move()
        {
            if (this.AmountOfStepsTotal > 0 && bulletToBeDrawn == true)
            {
                this.position = new Vector2(this.position.X + moveXStep, this.position.Y + moveYStep);
                this.bulletRect = new RectangleF(this.position.X, this.position.Y, this.bulletRect.Width, this.bulletRect.Height);
                this.AmountOfStepsTotal--;
            }
            else
            {
                bulletToBeDrawn = false;
            }

        }
        public void DrawBullet(SpriteBatch spriteBatch)
        {
            if (bulletToBeDrawn)
            {
                spriteBatch.FillRectangle(bulletRect, Color.Red);
            }
        }

        public bool Collision(RectangleF rectOther)
        {
            if (this.bulletRect.Intersects(rectOther))
            {
                this.bulletToBeDrawn = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}