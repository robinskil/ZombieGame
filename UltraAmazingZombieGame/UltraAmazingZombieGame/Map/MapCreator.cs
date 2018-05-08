using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
namespace UltraAmazingZombieGame.Map
{
    public class MapCreator
    {
        private int blockSize = 16;
        private Random random = new Random();
        public MapObject[,] MapGrid { get; private set; }
        
        public MapCreator(int amountTiles = 20)
        {
            this.MapGrid = new MapObject[amountTiles, amountTiles];
            LoadMap();
            SpawnRandomWeapons();
        }

        private void SpawnRandomWeapons()
        {
            int amountSpots = 0;
            foreach (MapObject item in MapGrid)
            {
                if (item.GetType() == typeof(WallObject))
                {
                    amountSpots++;
                }
            }
            int spawnTilePos = random.Next(amountSpots - 1);
            amountSpots = 0;
            foreach (MapObject item in MapGrid)
            {
                if (item.GetType() == typeof(WallObject))
                {
                    amountSpots++;
                }
                if (amountSpots == spawnTilePos)
                {
                    
                }
            }
        }

        private void LoadMap()
        {
            int tiles = (int)Math.Sqrt(MapGrid.Length);
            string[,] mapString = new string[tiles, tiles];
            StreamReader reader = new StreamReader(File.OpenRead(@"C:\Users\Robin\Desktop\Map.csv"));
            for (int x = 0; x < tiles; x++)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                for (int y = 0; y < tiles; y++)
                {
                    mapString[x, y] = values[y];
                }
            }
            // while (!reader.EndOfStream)
            // {
            //     string line = reader.ReadLine();
            //     if (!String.IsNullOrWhiteSpace(line))
            //     {
            //         string[] values = line.Split(',');
            //         foreach (string item in values)
            //         {
            //             mapString[x, values.Length] = item;
            //         }
            //     }
            // }
            //READ OUT MAP HERE
            for (int c = 0; c < 20; c++)
            {
                for (int y = 0; y < 20; y++)
                {
                    Console.Write(mapString[c, y]);
                }
                Console.WriteLine();
            }
            GenerateMap(mapString);
        }

        private void GenerateMap(string[,] mapString)
        {

            int tiles = (int)Math.Sqrt(MapGrid.Length);
            for (int indexY = 0; indexY < tiles; indexY++)
            {
                for (int indexX = 0; indexX < tiles; indexX++)
                {
                    if (indexY == 0 || indexX == 0 || indexY == tiles - 1 || indexX == tiles - 1)
                    {
                        //Wall around edges of the map
                        MapGrid[indexY, indexX] = new WallObject(indexX * blockSize, indexY * blockSize, blockSize);
                    }
                    else
                    {
                        if (mapString[indexY, indexX] == "0")
                        {
                            //Grass
                            MapGrid[indexY, indexX] = new GrassObject(indexX * blockSize, indexY * blockSize, blockSize);
                        }
                        else if (mapString[indexY, indexX] == "1")
                        {
                            //Wall
                            MapGrid[indexY, indexX] = new WallObject(indexX * blockSize, indexY * blockSize, blockSize);
                        }
                        else if (mapString[indexY, indexX] == "2")
                        {
                            //Door UP - DOWN
                            MapGrid[indexY, indexX] = new DoorObject(indexX * blockSize, indexY * blockSize, blockSize, true);
                        }
                        else if (mapString[indexY, indexX] == "3")
                        {
                            //Door Left Right
                            MapGrid[indexY, indexX] = new DoorObject(indexX * blockSize, indexY * blockSize, blockSize, false);
                        }
                        else if (mapString[indexY, indexX] == "4")
                        {
                            //Wall with glock weapon to buy
                            MapGrid[indexY, indexX] = new WallWeaponObject(indexX * blockSize, indexY * blockSize, blockSize);
                        }
                    }
                }
            }
        }
        public void DrawMap(SpriteBatch spritebatch)
        {
            foreach (MapObject item in MapGrid)
            {
                item.DrawObject(spritebatch);
            }
        }

        public Vector2 GenerateSpawnPosition()
        {
            int amountSpots = 0;
            foreach (MapObject item in MapGrid)
            {
                if (item.GetType() == typeof(GrassObject))
                {
                    amountSpots++;
                }
            }
            int spawnTilePos = random.Next(amountSpots - 1);
            amountSpots = 0;
            foreach (MapObject item in MapGrid)
            {
                if (item.GetType() == typeof(GrassObject))
                {
                    amountSpots++;
                }
                if (amountSpots == spawnTilePos)
                {
                    return item.position;
                }
            }
            throw new GameUpdateRequiredException();
        }
    }
}
