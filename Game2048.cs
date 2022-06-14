using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Study04
{
    public class Game2048
    {
        int mapSize;
        int dataCount;
        int[,] map;
        public Game2048()
        {
            Init();
            ShowMap();
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                Thread.Sleep(100);
                Console.WriteLine();
                if (input.Key == ConsoleKey.RightArrow)
                {
                    MoveRight();
                    ShowMap();
                }
                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    MoveLeft();
                    ShowMap();
                }
                else if (input.Key == ConsoleKey.UpArrow)
                {
                    MoveUp();
                    ShowMap();
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    MoveDown();
                    ShowMap();
                }
                else if (input.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }


        }

        private void Init()
        {
            Random random = new Random();
            mapSize = 4;
            dataCount = 0;
            map = new int[mapSize, mapSize];

            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    map[y, x] = 0;
                }
            }

            while (true)
            {
                int randomX = random.Next(0, mapSize);
                int randomY = random.Next(0, mapSize);
                if (map[randomX, randomY] == 0)
                {
                    map[randomX, randomY] = random.Next(1, 3) * 2;
                    dataCount++;
                }
                if (dataCount >= 2)
                {
                    break;
                }
            }

        }

        private void ShowMap()
        {
            Console.WriteLine("ESC key 종료");
            Console.WriteLine("================MAP===================");
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    string str = map[y, x].ToString();
                    str = String.Format($"{str,3}");
                    // $"{value,10}"
                    Console.Write("{0}", str);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("================MAP===================");
        }

        private void newData()
        {
            Random random = new Random();
            if (dataCount == mapSize * mapSize)
            {
                return;
            }
            while (true)
            {
                int randomX = random.Next(0, mapSize);
                int randomY = random.Next(0, mapSize);

                if (map[randomY, randomX] == 0)
                {
                    map[randomY, randomX] = random.Next(1, 3) * 2;
                    break;
                }
            }


        }

        private void MoveLeft()
        {
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = mapSize - 1; x > 0; x--)
                {
                    if (map[y, x - 1] == map[y, x])
                    {
                        map[y, x - 1] *= 2;
                        map[y, x] = 0;
                    }
                    else if (map[y, x - 1] == 0)
                    {
                        map[y, x - 1] = map[y, x];
                        map[y, x] = 0;
                    }
                }
            }
            newData();
        }

        private void MoveRight()
        {
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize - 1; x++)
                {
                    if (map[y, x + 1] == map[y, x])
                    {
                        map[y, x + 1] *= 2;
                        map[y, x] = 0;
                    }
                    else if (map[y, x + 1] == 0)
                    {
                        map[y, x + 1] = map[y, x];
                        map[y, x] = 0;
                    }
                }
            }
            newData();
        }
        private void MoveDown()
        {
            for (int x = 0; x < mapSize; x++)
            {
                for (int y = 0; y < mapSize - 1; y++)
                {
                    if (map[y + 1, x] == map[y, x])
                    {
                        map[y + 1, x] *= 2;
                        map[y, x] = 0;
                    }
                    else if (map[y + 1, x] == 0)
                    {
                        map[y + 1, x] = map[y, x];
                        map[y, x] = 0;
                    }
                }
            }
            newData();
        }

        private void MoveUp()
        {
            for (int x = 0; x < mapSize; x++)
            {
                for (int y = mapSize - 1; y > 0; y--)
                {
                    if (map[y - 1, x] == map[y, x])
                    {
                        map[y - 1, x] *= 2;
                        map[y, x] = 0;
                    }
                    else if (map[y - 1, x] == 0)
                    {
                        map[y - 1, x] = map[y, x];
                        map[y, x] = 0;
                    }
                }
            }
            newData();
        }
    }
}
