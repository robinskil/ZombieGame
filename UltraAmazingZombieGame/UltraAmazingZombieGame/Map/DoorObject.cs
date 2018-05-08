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
    public class DoorObject : MapObject
    {
        private bool upDown;
        private int doorWidth;
        private RectangleF doorRect;
        public bool DoorOpen { get; private set; } = false;
        public DoorObject(float x, float y, float blockSize, bool upDown) : base(x, y, blockSize)
        {
            this.doorWidth = (int)blockSize/4;
            this.upDown = upDown;
            if (upDown == true)
            {

                this.doorRect = new RectangleF(x, y, doorWidth, blockSize);
            }
            else
            {
                this.doorRect = new RectangleF(x, y, blockSize, doorWidth);
            }

        }

        public override void DrawObject(SpriteBatch spriteBatch)
        {
            if (this.upDown)
            {
                if (!DoorOpen)
                {
                    spriteBatch.FillRectangle(new RectangleF(this.position.X, this.position.Y, this.blockSize.Width, this.blockSize.Height), Color.Green);
                    spriteBatch.FillRectangle(new RectangleF(this.position.X + (blockSize.Width / 2), this.position.Y, doorWidth, this.blockSize.Height), Color.Brown);
                }
                else
                {
                    //TODO: DRAW DOOR OPEN
                }

            }
            else
            {
                if (!DoorOpen)
                {
                    spriteBatch.FillRectangle(new RectangleF(this.position.X, this.position.Y, this.blockSize.Width, this.blockSize.Height), Color.Green);
                    spriteBatch.FillRectangle(new RectangleF(this.position.X, this.position.Y + (blockSize.Height / 2), this.blockSize.Width, doorWidth), Color.Brown);
                }
                else
                {
                    //TODO: Draw Door Open
                }
            }

        }

        public void OpenDoor()
        {
            DoorOpen = true;
        }

        public void CloseDoor(){
            DoorOpen = false;
        }

        public override bool Collision(RectangleF rectOther)
        {
            if (DoorOpen == true)
            {
                return false;
            }
            else if (DoorOpen == false && rectOther.Intersects(this.doorRect) == true)
            {
                return true;
            }
            else return false;
        }
    }
}