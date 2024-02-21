/*Условие задачи. Вы разрабатываете систему управления задачами. Система выполняет несколько действий:

M — запускает задачу.

R — перезапускает задачу.

C — отменяет задачу. 

D — завершает задачу.

Процесс обработки для одной задачи можно представить как строку из символов M,R,C и D .

Условия процесса обработки:

В первую очередь, задача должна быть запущена запущена .

Запущенную задачу M можно отменить C , перезапустить R или завершить D .

Перезапущенная R задача отменяется C системой.

Отмененная C задача запускается M системой.

Завершенная D задача может быть запущена M заново.

В итоге процесса обработки задачи она должна быть завершена завершена .

По данному процессу обработки одной задачи системой определите, был ли он проведен корректно, с учётом писанных выше правил. Входные данные Каждый тест состоит из нескольких наборов входных данных.
*/


namespace ozon_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            int n = int.Parse(Console.ReadLine()); // количество строк
            string[] lines = new string[n]; // массив для сохранения строк

            // считываем строки
            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }

            // проверяем каждую строку
            foreach (string line in lines)
            {
                if (CheckString(line))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
        // метод для проверки строки на соответствие условиям
        static bool CheckString(string line)
        {
            if (line.Length < 2 || line[0] != 'M' || line[line.Length - 1] != 'D')
            {
                return false;
            }

            for (int i = 1; i < line.Length - 1; i++)
            {
                if (line[i] == 'R')
                {
                    if (line[i - 1] != 'M' && line[i + 1] != 'C')
                    {
                        return false;
                    }
                }
                else if (line[i] == 'C')
                {
                    if ((line[i - 1] != 'M' || line[i - 1] != 'R') && line[i + 1] != 'M')
                    {
                        return false;
                    }
                }
                else if (line[i] == 'D')
                {
                    if (line[i - 1] != 'M' && line[i + 1] != 'M')
                    {
                        return false;
                    }
                }
                else if (line[i] == 'M')
                {

                    if (line[i - 1] == 'M' )
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
