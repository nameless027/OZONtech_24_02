//Условие задачи
//Маркетплейс получает комиссию p% с каждой продажи товаров. Если был продан товар, который стоил ai рублей,комиссия должна составить ai*100/p рублей. По техническому заданию комиссия должна округляться в меньшую сторону до второго знака после запятой, то есть до целого числа копеек. Но, из-за допущенной программистом ошибки, комиссия всегда округлялась в меньшую сторону до целого числа рублей, то есть копейки отбрасывались. 

//Найдите сумму, упущенную из-за ошибки, после продажи маркетплейсом n товаров со стоимостями ai рублей.


        

    using var input = new StreamReader(Console.OpenStandardInput());
    using var output = new StreamWriter(Console.OpenStandardOutput());
    // тесты в файле с числом, ответы в файле с символом
    
    string[] s = File.ReadAllLines(@"D:\PROJECTS\.NET\Projects\ozon 2\test\16.txt");
    int t = int.Parse(s[0]); // количество наборов входных данных
    // Обрабатываем каждый набор входных данных
    for (int i = 1; i <= s.Length - 1; i++)
    {
        string[] data = s[i].Split(' ');
        // количество проданных товаров
        int n = int.Parse(data[0]);
        // процент комиссии маркетплейса
        double p = (double.Parse(data[1])) / 100;
        // сумма копеек комисси
        double sumCents = 0; 
            for (int j = 0; j < n; j++)
            {
                double a = int.Parse(s[i + j + 1]); // стоимость проданного товара
                double commission = a * p; // комиссия от продажи
                sumCents += (commission - Math.Floor(commission));
            }
         Console.WriteLine("{0:0.00}", sumCents);
         i += n; // переходим к следующему блоку данных

    }


    /* Решение для ввода с клавиатуры:
     
    using var input = new StreamReader(Console.OpenStandardInput());
    using var output = new StreamWriter(Console.OpenStandardOutput());

    // количество массивов, количество наборов данных
    int numArrays = int.Parse(input.ReadLine()); 
    // массив для хранения результатов
    double[] results = new double[numArrays]; 

    for (int i = 0; i < numArrays; i++)
    {
        // ввод длины массива и процента
        string[] inp = input.ReadLine().Split();
    // длина массива, количество проданных товаров
    int arrayLength = int.Parse(inp[0]);
    //  процент комиссии маркетплейса
    int percent = int.Parse(inp[1]);
    // создаем массив количества проданных товаров
    double[] array = new double[arrayLength]; 

        for (int j = 0; j < arrayLength; j++)
        {
            // заполняем массив числами
            array[j] = double.Parse(Console.ReadLine()); 
        }
        // сумма копеек комисси
        double sumCent = 0;
        foreach (double num in array)
        {
            // умножаем на процент и делим на 100
            double result = num * percent / 100;
        // определяем разность в копейках и добавляем к суммекопеек
        sumCent += (result - Math.Floor(result)); 
        }
        // округляем сумму до двух знаков после запятой
        results[i] = Math.Round(sumCent, 2); ; 
    }

    foreach (double result in results)
    {
        // выводим результаты, если будет ноль, добавим два числа после зпт
        output.WriteLine(string.Format("{0:F2}", result)); 
    }
    */