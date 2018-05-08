using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using UltraAmazingZombieGame.Entity;
using UltraAmazingZombieGame.Map;
namespace UltraAmazingZombieGame
{
    public static class StaticDefinitionMethods
    {

        public static Vector2 CenterStringPos(string s, float posX, float posY, SpriteFont font)
        {
            return new Vector2((posX) - (font.MeasureString(s).X / 2), (posY) - (font.MeasureString(s).Y * 2)); ;
        }
    }
}