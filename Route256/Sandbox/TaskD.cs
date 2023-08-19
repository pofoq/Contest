﻿using Route256.Common;

namespace Route256.Sandbox
{
    internal class TaskD : ITask
    {
        public void Run()
        {
            var caseCount = int.Parse(Console.ReadLine()!);

            for (var i = 0; i < caseCount; i++)
            {
                Console.ReadLine();
                var tblParams = Console.ReadLine()!.Split(' ');
                var rowCount = int.Parse(tblParams[0]);
                var columnCount = int.Parse(tblParams[1]);

                var table = new int[rowCount][];

                for (var rowNum = 0; rowNum < rowCount; rowNum++)
                {
                    var rowValues = Console.ReadLine()!.Split(' ').Select(v => int.Parse(v)).ToArray();
                    table[rowNum] = rowValues;
                    //for (var colNum = 0; colNum < columnCount; colNum++)
                    //{
                    //    table[colNum][rowNum] = rowValues[colNum];
                    //}
                }

                var clickCount = int.Parse(Console.ReadLine()!);
                
                var clickedColumns = Console.ReadLine()!.Split(' ').Select(c => int.Parse(c)).ToArray();

                for (var clickNum = 0; clickNum < clickCount; clickNum++)
                {
                    var clickedCol = clickedColumns[clickNum] - 1;
                    var currentRow = 0;
                    int[] tempRow;
                    int currentVal, nextVal;

                    for (var itteration = 0; itteration < rowCount - 1; itteration++)
                    {
                        currentRow = 0;
                        for (var itteration2 = currentRow; itteration2 < rowCount - 1; itteration2++)
                        {
                            currentVal = table[currentRow][clickedCol];
                            nextVal = table[currentRow + 1][clickedCol];
                            if (currentVal > nextVal)
                            {
                                tempRow = table[currentRow];
                                table[currentRow] = table[currentRow + 1];
                                table[currentRow + 1] = tempRow;
                            }
                            currentRow++;
                        }
                    }
                }
                for (var rowNum = 0; rowNum < rowCount; rowNum++)
                {
                    Console.WriteLine(string.Join(' ', table[rowNum]));
                }
                Console.WriteLine();
            }
        }
    }
}
/*
 D. Электронная таблица (10 баллов)
ограничение по времени на тест1 секунда
ограничение по памяти на тест256 мегабайт
вводстандартный ввод
выводстандартный вывод
Вам необходимо написать часть функциональности обработки сортировок в электронных таблицах.

Задана прямоугольная таблица n×m
 (n
 строк по m
 столбцов) из целых чисел.

Если кликнуть по заголовку i
-го столбца, то строки таблицы пересортируются таким образом, что в этом столбце значения будут идти по неубыванию (то есть возрастанию или равенству). При этом, если у двух строк одинаковое значение в этом столбце, то относительный порядок строк не изменится.

Рассмотрим пример.


В этом примере сначала клик был совершен по второму столбцу, затем по первому и, наконец, по третьему.

Заметим, что если кликнуть подряд два раза в один столбец, то после второго клика таблица не изменится (в момент второго клика она уже отсортирована по этому столбцу).

Обработайте последовательность кликов и выведите состояние таблицы после всех кликов.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке записано целое число t
 (1≤t≤100
) — количество наборов входных данных в файле. Далее следуют описания наборов, перед каждым из них записана пустая строка.

В первой строке набора записаны два целых числа n
 и m
 (1≤n,m≤30
) — количество строк и столбцов в таблице.

Далее следуют n
 строк по m
 целых чисел в каждой — начальное состояние таблицы. Все элементы таблицы от 1
 до 100
.

Затем входные данные содержат строку с один целым числом k
 (1≤k≤30
) — количество кликов.

Следующая строка содержит k
 целых чисел c1,c2,…,ck
 (1≤ci≤m
) — номера столбцов, по которым были осуществлены клики. Клики даны в порядке их совершения.

Выходные данные
Для каждого набора входных данных выведите n
 строк по m
 чисел в каждой — итоговое состояние таблицы. После каждого набора выходных данных выводите дополнительный перевод строки.

Пример
входные данныеСкопировать
3

4 3
3 4 1
2 2 5
2 4 2
2 2 1
3
2 1 3

3 1
100
9
10
2
1 1

3 3
2 11 72
99 11 13
2 8 13
5
2 3 2 1 2
выходные данныеСкопировать
2 2 1
3 4 1
2 4 2
2 2 5

9
10
100

2 8 13
2 11 72
99 11 13

*/