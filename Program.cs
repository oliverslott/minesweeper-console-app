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
            Console.Write($"[{GetNumberForTile()}] ");
        }
        Console.WriteLine();
    }
}

int GetNumberForTile()
{
    return 0;
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