// Task 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет 
//построчно выводить массив, добавляя индексы каждого элемента.
Console.Clear();
Console.WriteLine("This program generates 3D array with non-repeating two-digit numbers.");
Console.WriteLine();
int dimensionX = EnterUserData("Enter lenght of the X dimension:");
int dimensionY = EnterUserData("Enter lenght of the Y dimension:");
int dimensionZ = EnterUserData("Enter lenght of the Z dimension:");
int[,,] randomArray = new int[dimensionX, dimensionY, dimensionZ];
Console.WriteLine();

if ((dimensionX * dimensionY * dimensionZ) > 90)//If size of our array is greater than the number of two-digit numbers then break.
{
    Console.WriteLine("It's impossible to fill the entered array with non-repeating two-digit numbers! Check size of the entered array.");
    return;
}
FillArray(randomArray, dimensionX, dimensionY, dimensionZ);//fill with non-repeating two-digit numbers.
ShuffleArray(randomArray);// get random array
Console.WriteLine();
Console.WriteLine("The entered 3D array is:");
Console.WriteLine();
PrintArray(randomArray);

int[,,] FillArray(int[,,] array, int dimensionX, int dimensionY, int dimensionZ)
{
    int offset = new Random().Next(10, 100);//get random offset (start number)
    int upperBound = 99;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int n = 0; n < array.GetLength(2); n++)
            {
                array[i, j, n] = offset;
                if (offset >= array[0, 0, 0] && offset <= upperBound)
                {
                    offset++;
                }
                else
                {
                    offset--;
                }
                if (offset > upperBound)//if we reach the upper bound then go to revers direction
                {
                    offset = array[0, 0, 0] - 1;
                }
            }

        }
    }
    return array;
}

void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int n = 0; n < array.GetLength(2); n++)
            {
                Console.Write($"{array[i, j, n]}[{i},{j},{n}] ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int EnterUserData(string nameUserData)
{
    Console.Write($"{nameUserData}");
    return Convert.ToInt32(Console.ReadLine());
}

int[,,] ShuffleArray(int[,,] array)
{
    int temp = 0, i1 = 0, j1 = 0, n1 = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        i1 = new Random().Next(0, array.GetLength(0));
        for (int j = 0; j < array.GetLength(1); j++)
        {
            j1 = new Random().Next(0, array.GetLength(1));
            for (int n = 0; n < array.GetLength(2); n++)
            {
                n1 = new Random().Next(0, array.GetLength(2));
                temp = array[i1, j1, n1];
                array[i1, j1, n1] = array[i, j, n];
                array[i, j, n] = temp;
            }
        }
    }
    return array;
}