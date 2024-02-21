/*
Условие задачи
Склад маркетплейса имеет форму прямоугольника и разделен на клетки площадью 1×1. Общая площадь склада n×m
,где n — количество строк,m — количество столбцов, пронумерованных от 1 до n и от 1 до m соответственно. Известно, что все клетки склада с чётными индексами строки и столбца заняты стойками, остальные свободны для перемещения. Также известно что склад состоит из нечётного количества строк и столбцов.

На двух различных свободных для перемещения клетках расположены роботы моделей A и B. Роботы могут перемещаться в соседнюю по вертикали или горизонтали свободную клетку. Вам необходимо построить два непересекающихся маршрута, которые приведут одного из роботов в верхнюю левую клетку склада (1;1), а другого — в нижнюю правую (n; m). Обратите внимание, минимизировать длину маршрутов роботов не требуется. Какой из роботов окажется в верхней левой клетке, а какой в правой нижней — не важно. Путь робота должен быть простым, то есть робот не может посещать клетку, в которую он уже перемещался.

Выходные данные
Для каждого набора входных данных выведите n строк по m символов в каждой. Путь робота A обозначьте символами
a, а путь робота B — символами b.

Пояснения к первому примеру:
A и B — это роботы, a и b — это их путь, стрелками показано как они двигаются.
Точки — это пустые клетки. Решетки — это стойки (занятые клетки).
Входные данные:
2
5 5
.....
.#A#.
...B.
.#.#.
.....
7 9
.........
.#.#.#.#.
..AB.....
.#.#.#.#.
.........
.#.#.#.#.
.........
Выхоные данные:
aaa..
.#A#.
...Bb
.#.#b
....b
aaa......
.#a#.#.#.
..ABb....
.#.#b#.#.
....b....
.#.#b#.#.
....bbbbb
*/


namespace ozon_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Количество запросов
            int numberOfQueries = int.Parse(Console.ReadLine());
            //Массив с решениями
            char[][,] result = new char[numberOfQueries][,];

            //Создание карты 
            for (int i = 0; i < numberOfQueries; i++)
            {
                //Размер массива
                string[] size = Console.ReadLine().Split(' ');
                int n = int.Parse(size[0]);
                int m = int.Parse(size[1]);

                char[,] array = new char[n, m];

                // Ввод карты
                for (int j = 0; j < n; j++)
                {
                    string inp = Console.ReadLine();

                    for (int k = 0; k < m; k++)
                    {
                        array[j, k] = inp[k];
                    }
                }
                // Ищем выход на карте
                char[,] resultArray = FindFin(array, n, m);
                //Сохраняем в массив решений
                result[i] = resultArray;
            }

            // Выводим результат, массив решений
            foreach (char[,] res in result)
            {
                // обработка каждого отдельного запроса
                for (int r = 0; r < res.GetLength(0); r++)
                {
                    for (int c = 0; c < res.GetLength(1); c++)
                    {
                        Console.Write(res[r, c]);
                    }
                    Console.WriteLine();
                }

            }

            // Поиск выхода на карте
            static char[,] FindFin(char[,] array, int n, int m)
            {
                // Новая карта с путями
                char[,] resultArray = new char[n, m];

                int aX = -1, aY = -1;
                int bX = -1, bY = -1;

                // Находим позиции символов A и B
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (array[i, j] == 'A')
                        {
                            aX = i;
                            aY = j;
                        }
                        else if (array[i, j] == 'B')
                        {
                            bX = i;
                            bY = j;
                        }
                    }
                }

                // Копируем исходный массив в результирующий, заполняем новую карту
                Array.Copy(array, resultArray, n * m);

                // Проложение пути символа A
                int currentX = aX;
                int currentY = aY;

                while (currentX > 0 || currentY > 0)
                {
                    if (currentX > 0 && array[currentX - 1, currentY] == '.')
                    {
                        resultArray[currentX - 1, currentY] = 'a';
                        currentX--;
                    }
                    else if (currentY > 0 && array[currentX, currentY - 1] == '.')
                    {
                        resultArray[currentX, currentY - 1] = 'a';
                        currentY--;
                    }
                    else
                    {
                        break;
                    }
                }

                // Проложение пути символа B
                currentX = bX;
                currentY = bY;

                while (currentX < n - 1 || currentY < m - 1)
                {
                    if (currentX < n - 1 && array[currentX + 1, currentY] == '.')
                    {
                        resultArray[currentX + 1, currentY] = 'b';
                        currentX++;
                    }
                    else if (currentY < m - 1 && array[currentX, currentY + 1] == '.')
                    {
                        resultArray[currentX, currentY + 1] = 'b';
                        currentY++;
                    }
                    else
                    {
                        break;
                    }
                }

                return resultArray;
            }
        }
    }
}
