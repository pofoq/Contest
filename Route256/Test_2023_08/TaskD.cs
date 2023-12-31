﻿using Route256.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Test_2023_08
{
    internal class TaskD : ITask
    {
        public void Run()
        {
            var t = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < t; i++)
            {
                var arr = Console.ReadLine()!.Split(' ');

                var k = int.Parse(arr[0]); //количество рельефов
                var n = int.Parse(arr[1]); //высота
                var m = int.Parse(arr[2]); //ширина

                char[][] res = new char[n][];

                for (var l = 0; l < n; l++)
                {
                    res[l] = Console.ReadLine()!.ToArray();
                }

                for (int j = 1; j < k; j++)
                {
                    Console.ReadLine();
                    for (var l = 0; l < n; l++)
                    {
                        var str = Console.ReadLine()!;
                        for (var w = 0; w < m; w++)
                        {
                            if (res[l][w] == '.' && str[w] != '.')
                            {
                                res[l][w] = str[w];
                            }
                        }
                    }
                }
                foreach (var row in res)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine();
            }
        }
    }
}
/*
 D. ASCII-горы (15 баллов)
ограничение по времени на тест1 секунда
ограничение по памяти на тест256 мегабайт
вводстандартный ввод
выводстандартный вывод
Назовём рельефом гор 2D-изображение из n
 строк и m
 столбцов, состоящее только из символов 'X', '.' (точка), '/' (прямой слеш) и '\' (обратный слеш). Изображение составлено по следующим формальным правилам:

либо непосредственно слева снизу от символа '/' находится такой же символ, либо непосредственно слева от символа '/' находится символ '\', либо символ '/' находится на нижней строке;
либо непосредственно справа сверху от символа '/' находится такой же символ, либо непосредственно справа от символа '/' находится символ '\';
либо непосредственно слева сверху от символа '\' находится такой же символ, либо непосредственно слева от символа '\' находится символ '/';
либо непосредственно справа снизу от символа '\' находится такой же символ, либо непосредственно справа от символа '\' находится символ '/', либо символ '\' находится на нижней строке;
каждый столбец содержит не более одного из символов '/' и '\';
в каждом столбце все символы ниже '/' и '\' равны 'X';
все остальные символы равны '.'.
Все символы, кроме '.', являются частью горы.

В каждом рельефе гор есть хотя бы один символ, не равный '.'.

Дано k
 рельефов по их близости к наблюдателю: от ближних к дальним. Выведите рельеф, видный наблюдателю. Если в некотором рельефе символ в x
-й строке и y
-м столбце является частью горы, то во всех более дальних от наблюдателя рельефах гор символы на этой позиции не видны наблюдателю.

Входные данные
Каждый тест состоит из нескольких наборов входных данных. Первая строка содержит целое число t
 (1≤t≤20
) — количество наборов входных данных. Далее следует описание наборов входных данных.

Первая строка каждого набора содержит три целых числа k
, n
 и m
 (1≤k,n≤20
, 2≤m≤20
) — количество рельефов, высоту и ширину ASCII-арта.

Далее следуют описания k
 рельефов гор.

Описание рельефа гор состоит из n
 строк, по m
 символов в каждой — сам ASCII-арт.

Описания рельефов разделены пустой строкой.

Выходные данные
Для каждого набора входных данных выведите в n
 строках рельеф гор, видный наблюдателю. После ответа на каждый набор входных данных выведите пустую строку.

Пример
входные данныеСкопировать
3
2 6 18
..................
..................
.../\.............
../XX\/\../\......
./XXXXXX\/XX\.....
/XXXXXXXXXXXX\....

........../\......
........./XX\.....
......../XXXX\....
.../\../XXXXXX\...
../XX\/XXXXXXXX\..
./XXXXXXXXXXXXXX\.
1 2 2
..
/\
3 4 5
.....
.....
.....
./\..

.....
.....
./\..
/XX\.

.....
.....
../\.
./XX\
выходные данныеСкопировать
........../\......
........./XX\.....
.../\.../XXXX\....
../XX\/\XX/\XX\...
./XXXXXX\/XX\XX\..
/XXXXXXXXXXXX\XX\.

..
/\

.....
.....
./\\.
//\\\

Примечание
Иллюстрация к первому примеру из первого теста:
 */