namespace ozon_6
{

//    Условие задачи
//В школе Игоря действует 5-балльная система оценки.Чем больше число, тем лучше считается оценка:‘5’ означает наилучшую оценку, а ‘1’ самую плохую.
//Успеваемость Игоря записана в дневнике в виде таблицы из n строк и m столбцов, где в каждой клетке записана цифра от ‘1’ до ‘5’.
//Игорь очень переживает, что за плохие оценки его будут ругать родители. Он придумал, как он может избавиться от плохих оценок в дневнике: убрать одну строку и один столбец из дневника так, чтобы самая плохая оставшаяся оценка в таблице была как можно лучше.
    internal class Program
    {

        static void Main(string[] args)
        {
            //количество проверок
            int size = int.Parse(Console.ReadLine());
            //Массив с проверками
            string[] res = new string[size];

            //записываем массив с оценками
            for (int z = 0; z < size; z++)
            {
                //размер массива проверки
                string[] sizeArr = Console.ReadLine().Split(' ');
                int n = int.Parse(sizeArr[0]);
                int m = int.Parse(sizeArr[1]);

                //заполняем массив
                int[,] array = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    string inp = Console.ReadLine();
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = inp[j];

                    }
                }

                //Заполняем массив ответами
                res[z] = FindMinIndex(array);
            }

            //Выводим ответы
            foreach (string index in res)
            {
                Console.WriteLine(index);
            }                    
        }

        //минимальное значение
        static string FindMinIndex(int[,] array)
        {
            int n = array.GetLength(0);
            int m = array.GetLength(1);
            int min = array[0, 0];
            int minRow= -1;
            int minCol= -1;
            
            // поиск минимума
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minRow = i+1;
                        minCol = j+1;

                    }
                }
            }
            string index = string.Format(minRow  + " " + minCol);
            return index;
        }



    }
    
}

