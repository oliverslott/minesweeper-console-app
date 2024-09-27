//Made by Oliver

const int tileSize = 8;
const int amountOfBombs = 4;
int[,] tiles = new int[tileSize, tileSize];

SpawnBombs();

while(true)
{
    DrawBoard();
    Console.Write("Click tile at(x,y): ");
    Console.ReadLine();
}

void DrawBoard()
{
    for(int x = 0; x < tiles.GetLength(0)+1; x++)
    { 
        for(int y = 0; y < tiles.GetLength(1)+1; y++)
        {
            if(y == 0 && x == 0)
            {
                Console.Write("  ");
                continue;
            }
            if(y == 0)
            {
                Console.Write($"{x-1} ");
                continue;
            }
            if(x == 0)
            {
                Console.Write($" {y-1}  ");
                continue;
            }
            //Console.Write($"{tiles[x-1,y-1]} ");
            if(tiles[x-1,y-1] == 1)
            {
                Console.Write($"[X] ");
            }
            else
            {
                Console.Write($"[{GetNumberForTile(x-1,y-1)}] ");
            }
        }
        Console.WriteLine();
    }
}

int GetNumberForTile(int x, int y)
{
    //Console.WriteLine($"{x},{y}");
    int bombsAroundTile = 0;

    //Below
    if(y+1<tileSize && tiles[x,y+1] == 1)
    {
        bombsAroundTile++;
    }
    //Below-right
    if(x+1<tileSize && y+1<tileSize && tiles[x+1,y+1] == 1)
    {
        bombsAroundTile++;
    }
    //Right
    if(x+1<tileSize && tiles[x+1,y] == 1)
    {
        bombsAroundTile++;
    }
    //Top-right
    if(y-1 >= 0 && x+1<tileSize && tiles[x+1,y-1] == 1)
    {
        bombsAroundTile++;
    }
    //Top
    if(y-1 >= 0 && tiles[x,y-1] == 1)
    {
        bombsAroundTile++;
    }
    //Top-left
    if(y-1 >= 0 && x-1 >= 0 && tiles[x-1,y-1] == 1)
    {
        bombsAroundTile++;
    }
    //Left 
    if(x-1 >= 0 && tiles[x-1,y] == 1)
    {
        bombsAroundTile++;
    }
    //Below-left
    if(x-1 >= 0 && y+1<tileSize && tiles[x-1,y+1] == 1)
    {
        bombsAroundTile++;
    }
    return bombsAroundTile;
}

void SpawnBombs()
{
    Random rand = new Random();
    for(int i = 0; i < amountOfBombs; i++)
    {
        int randX = rand.Next(0, tileSize);
        int randY = rand.Next(0, tileSize);
        tiles[randX, randY] = 1;
    }
    //int randX = r
}

// enum Tiles
// {
//     NotClicked,
//     Clicked,
// }