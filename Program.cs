﻿//Made by Oliver

const byte tileSize = 8;
const byte amountOfBombs = 8;
byte[,] tiles = new byte[tileSize, tileSize];
bool[,] openTiles = new bool[tileSize, tileSize];
byte selectedX = 0;
byte selectedY = 0;

SpawnBombs();
Console.WriteLine("Controls: Arrow keys to move cursor and spacebar to open tile");
while (true)
{
    DrawBoard();
    Controls();
}

void Controls()
{
    //Console.Write("Click tile at(\"x,y\"): ");
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.LeftArrow:
            if(selectedY == 0)
            {
                selectedY = tileSize - 1;
            }
            else
            {
                selectedY--;
            }
            break;
        case ConsoleKey.RightArrow:
            if(selectedY == tileSize - 1)
            {
                selectedY = 0;
            }
            else
            {
                selectedY++;
            }
            break;
        case ConsoleKey.UpArrow:
            if(selectedX == 0)
            {
                selectedX = tileSize - 1;
            }
            else
            {
                selectedX--;
            }
            break;
        case ConsoleKey.DownArrow:
            if(selectedX == tileSize - 1)
            {
                selectedX = 0;
            }
            else
            {
                selectedX++;
            }
            break;
        case ConsoleKey.Spacebar:
            OpenTile(selectedX, selectedY);
            break;
    }
    //string[] input = Console.ReadLine().Split(',');
    //int x = int.Parse(input[1]);
    //int y = int.Parse(input[0]);
    //OpenTile(x,y);
}

void DrawBoard()
{
    Console.WriteLine();
    for (int x = 0; x < tiles.GetLength(0); x++)
    {
        for (int y = 0; y < tiles.GetLength(1); y++)
        {
            //Cursor
            if(selectedX == x && selectedY == y)
            {
                Console.Write("[");
            }
            else
            {
                Console.Write(" ");
            }
            if (openTiles[x, y])
            {
                if (tiles[x, y] == 1)
                {
                    Console.Write($"X");
                }
                else
                {
                    int num = GetNumberForTile(x, y);
                    if (num == 0)
                    {
                        Console.Write($"□");
                    }
                    else
                    {
                        Console.Write($"{num}");
                    }
                }
            }
            else
            {
                Console.Write($"■");
            }

            //Cursor
            if(selectedX == x && selectedY == y)
            {
                Console.Write("]");
            }
            else
            {
                Console.Write(" ");
            }
        }
        Console.WriteLine();
    }
}

void OpenTile(int x, int y)
{
    if (tiles[x, y] == 1)
    {
        Console.WriteLine("You hit a bomb. You lose!");
        //return;
    }
    openTiles[x, y] = true;
    if (GetNumberForTile(x, y) > 0)
    {
        return;
    }
    //Below
    if (y + 1 < tileSize && tiles[x, y + 1] != 1 && !openTiles[x, y + 1])
    {
        OpenTile(x, y + 1);
    }
    // //Below-right
    // if(x+1<tileSize && y+1<tileSize && tiles[x+1,y+1] != 1 && !openTiles[x+1,y+1])
    // {
    //     OpenTile(x+1,y+1);
    // }
    //Right
    if (x + 1 < tileSize && tiles[x + 1, y] != 1 && !openTiles[x + 1, y])
    {
        OpenTile(x + 1, y);
    }
    // //Top-right
    // if(y-1 >= 0 && x+1<tileSize && tiles[x+1,y-1] != 1 && !openTiles[x+1,y-1])
    // {
    //     OpenTile(x+1,y-1);
    // }
    //Top
    if (y - 1 >= 0 && tiles[x, y - 1] != 1 && !openTiles[x, y - 1])
    {
        OpenTile(x, y - 1);
    }
    // //Top-left
    // if(y-1 >= 0 && x-1 >= 0 && tiles[x-1,y-1] != 1 && !openTiles[x-1,y-1])
    // {
    //     OpenTile(x-1,y-1);
    // }
    //Left 
    if (x - 1 >= 0 && tiles[x - 1, y] != 1 && !openTiles[x - 1, y])
    {
        OpenTile(x - 1, y);
    }
    // //Below-left
    // if(x-1 >= 0 && y+1<tileSize && tiles[x-1,y+1] != 1 && !openTiles[x-1,y+1])
    // {
    //     OpenTile(x-1,y+1);
    // }
}

int GetNumberForTile(int x, int y)
{
    //Console.WriteLine($"{x},{y}");
    int bombsAroundTile = 0;

    //Below
    if (y + 1 < tileSize && tiles[x, y + 1] == 1)
    {
        bombsAroundTile++;
    }
    //Below-right
    if (x + 1 < tileSize && y + 1 < tileSize && tiles[x + 1, y + 1] == 1)
    {
        bombsAroundTile++;
    }
    //Right
    if (x + 1 < tileSize && tiles[x + 1, y] == 1)
    {
        bombsAroundTile++;
    }
    //Top-right
    if (y - 1 >= 0 && x + 1 < tileSize && tiles[x + 1, y - 1] == 1)
    {
        bombsAroundTile++;
    }
    //Top
    if (y - 1 >= 0 && tiles[x, y - 1] == 1)
    {
        bombsAroundTile++;
    }
    //Top-left
    if (y - 1 >= 0 && x - 1 >= 0 && tiles[x - 1, y - 1] == 1)
    {
        bombsAroundTile++;
    }
    //Left 
    if (x - 1 >= 0 && tiles[x - 1, y] == 1)
    {
        bombsAroundTile++;
    }
    //Below-left
    if (x - 1 >= 0 && y + 1 < tileSize && tiles[x - 1, y + 1] == 1)
    {
        bombsAroundTile++;
    }
    return bombsAroundTile;
}

void SpawnBombs()
{
    Random rand = new Random();
    for (int i = 0; i < amountOfBombs; i++)
    {
        int randX = rand.Next(0, tileSize);
        int randY = rand.Next(0, tileSize);
        tiles[randX, randY] = 1;
    }
    //int randX = r
}