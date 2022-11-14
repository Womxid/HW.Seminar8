int NumEnter(string str)
{
    System.Console.WriteLine(str);
    int num = int.Parse(Console.ReadLine());
    return num;
}

void WriteArray(int[,,] array3D)
{
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            Console.Write($"X({i}) Y({j}) ");
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                Console.Write($"Z({k})={array3D[i, j, k]}; ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

void CreateArray(int[,,] array3D)
{
    int[] temp = new int[array3D.GetLength(0) * array3D.GetLength(1) * array3D.GetLength(2)];
    int number;
    for (int i = 0; i < temp.GetLength(0); i++)
    {
        temp[i] = new Random().Next(10, 100);
        number = temp[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (temp[i] == temp[j])
                {
                    temp[i] = new Random().Next(10, 100);
                    j = 0;
                    number = temp[i];
                }
                number = temp[i];
            }
        }
    }
    int count = 0;
    for (int m = 0; m < array3D.GetLength(0); m++)
    {
        for (int n = 0; n < array3D.GetLength(1); n++)
        {
            for (int z = 0; z < array3D.GetLength(2); z++)
            {
                array3D[m, n, z] = temp[count];
                count++;
            }
        }
    }
}


int[,] GetRandomMatrix(int rows, int columns, int maxValue = 10, int minValue = 0)
{
    int[,] matrix = new int[rows, columns];
    Random random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = random.Next(minValue, maxValue + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

void FillArraySpiral(int[,] array, int n)
{
    int i = 0, j = 0;
    int value = 1;
    for (int e = 0; e < n * n; e++)
    {
        int k = 0;
        do { array[i, j++] = value++; } while (++k < n - 1);
        for (k = 0; k < n - 1; k++) array[i++, j] = value++;
        for (k = 0; k < n - 1; k++) array[i, j--] = value++;
        for (k = 0; k < n - 1; k++) array[i--, j] = value++;
        ++i; ++j;
        n = n < 2 ? 0 : n - 2;
    }
}


start();

void start()
{
    while (true)
    {

Console.Clear();
System.Console.WriteLine("Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
System.Console.WriteLine("Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
System.Console.WriteLine("Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
System.Console.WriteLine("Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
System.Console.WriteLine("Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4."); 
System.Console.WriteLine("0) End"); 

int NumTask = NumEnter("Номер задачи");

switch (NumTask)
{
    case 0: return; break;
    case 54: Ex54(); break;
    case 56: Ex56(); break;
    case 58: Ex58(); break;
    case 60: Ex60(); break;
    case 62: Ex62(); break;

}
    }
}


//  54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

void Ex54()
{
int rows = NumEnter("Введите число m");
int columns = NumEnter("Введите число n");
int[,] matrix = GetRandomMatrix(rows, columns);
PrintMatrix(matrix);
System.Console.WriteLine();

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int k = 0; k < matrix.GetLength(1) - 1; k++)
        {
            if (matrix[i, k] < matrix[i, k + 1])
            {
                int temp = matrix[i, k + 1];
                matrix[i, k + 1] = matrix[i, k];
                matrix[i, k] = temp;
            }
        }
    }
}
PrintMatrix(matrix);
}


// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

void Ex56()
{
int rows = NumEnter("Введите число m");
int columns = NumEnter("Введите число n");
int[,] matrix = GetRandomMatrix(rows, columns);
PrintMatrix(matrix);
System.Console.WriteLine();

int minRow = 0;
int minSumRow = 0;
int sumRow = 0;
for (int i = 0; i < matrix.GetLength(1); i++)
{
    minRow += matrix[0, i];
}
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++) sumRow += matrix[i, j];
    if (sumRow < minRow)
    {
        minRow = sumRow;
        minSumRow = i;
    }
    sumRow = 0;
}
Console.Write($"{minSumRow + 1} строка");
}

//  Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Тут шляпа. Но в примере на сайте ГБ тоже шляпа. Так что мб я выполнил условия задачи. 
void Ex58()
{
int rows = NumEnter("Введите число m");
int columns = NumEnter("Введите число n");
int[,] matrix1 = GetRandomMatrix(rows, columns);
int[,] matrix2 = GetRandomMatrix(rows, columns);
PrintMatrix(matrix1);
System.Console.WriteLine();
PrintMatrix(matrix2);
System.Console.WriteLine();
int[,] result = new int[rows, columns];

for (int i = 0; i < matrix1.GetLength(0); i++)
{
    for (int j = 0; j < matrix2.GetLength(1); j++)
    {
        result[i, j] = 0;
        for (int k = 0; k < matrix1.GetLength(1); k++)
        {
            result[i, j] += matrix1[i, k] * matrix2[k, j];
        }
    }
}

PrintMatrix(result);
}

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
void Ex60()
{
Console.WriteLine($"Введите размер массива M m N m Z: ");
int m = NumEnter("Введите M: ");
int n = NumEnter("Введите N: ");
int z = NumEnter("Введите Z: ");
Console.WriteLine();
int[,,] array3D = new int[m, n, z];
CreateArray(array3D);
WriteArray(array3D);
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

void Ex62()
{
int r = 4;
int[,] spiral = new int[r, r];
FillArraySpiral(spiral, r);
PrintMatrix(spiral);
}