using System;

string[] players = new string[2];
for (int i = 0; i < players.Length; i++)
{
   Console.Write($"Enter name for player {i + 1}: ");
   players[i] = Console.ReadLine();
}

int[][] gamer1 = [
   [0, 10, 26, 0, 45, 51, 0, 0, 80],
   [4, 0, 21, 34, 0, 0, 69, 72, 0],
   [0, 18, 0, 32, 40, 57, 0, 0, 89]
];

int[][] gamer2 = [
   [1, 0, 23, 0, 44, 0, 60, 71, 0],
   [0, 11, 0, 36, 0, 59, 63, 0, 85],
   [9, 0, 0, 31, 47, 0, 0, 74, 83]
];

int[][][] allGamer = [
    gamer1, 
    gamer2
];

List<int> gameLog = new List<int>();


var rnd = new Random();
int index = rnd.Next(1, 91);

while (true)
{
Back:

    var findLog = gameLog.FirstOrDefault(x => x == index);
    bool finish = false;

    if (findLog != 0)
    {
        index = rnd.Next(1, 91);
        goto Back;
    }


    gameLog.Add(index);

    for (int i = 0; i < allGamer.Length; i++)
    {
        FindAndReplace(index, allGamer[i]);
        bool check = CheckWinner(allGamer[i]);
        if (check)
        {
            Console.WriteLine(players[i] + " is win!");
            finish = true;
            break;
        }
    }

    if (gameLog.Count() == 90 || finish == true)
    {
        break;
    }
}


void FindAndReplace(int num, int[][] myArr)
{
    for (int i = 0; i < myArr.Length; i++)
    {
        for (int j = 0; j < myArr[i].Length; j++)
        {
            if (myArr[i][j] == num)
            {
                myArr[i][j] = 0;
            }
        }
    }
}


bool CheckWinner(int[][] myArr)
{
    int cnt = 0;
    for (int i = 0; i < myArr.Length; i++)
    {
        for (int j = 0; j < myArr[i].Length; j++)
        {
            if (myArr[i][j] == 0)
            {
                cnt++;
            }
        }
    }
    return cnt == 27 ? true : false;
}
