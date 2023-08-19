﻿using System;
using System.Linq;

namespace TestConsole.Codeforces.Sandbox
{
    public class Task_A
    {
        internal void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < testCaseCount; i++)
            {
                var res = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
                Console.WriteLine(res.Sum());
            }
        }
    }
}
/*
 A. Сумматор (5 баллов)
ограничение по времени на тест3 секунды
ограничение по памяти на тест256 мегабайт
вводстандартный ввод
выводстандартный вывод
Эта задача познакомит вас с тестирующей системой Codeforces. Правильные решения задач должны проходить все заранее заготовленные тесты жюри и укладываться в ограничения по времени/памяти на каждом тесте. Ниже перечислены технические требования к решениям:

решение располагается в одном файле исходного кода;
решение читает входные данные со стандартного ввода (экрана);
решение пишет выходные данные на стандартный вывод (экран);
решение не взаимодействует как-либо с другими ресурсами компьтера (сеть, жесткий диск, процессы и прочее);
решение использует только стандартную библиотеку языка;
решение располагается в пакете по-умолчанию (или его аналоге для вашего языка), имеют стандартную точку входа для консольных программ;
гарантируется, что во всех тестах выполняются все ограничения, что содержатся в условии задачи — как-либо проверять входные данные на корректность не надо, все тесты строго соответствуют описанному в задаче формату;
выводи ответ в точности в том формате, как написано в условии задачи (не надо выводить «поясняющих» комментариев типа введите число или ответ равен);
решения можно отправлять сколько угодно раз (пожалуйста, только без абьюза системы).
Для вашего удобства тесты, на которых будут тестироваться ваши решения, являются открытыми. В каждой задаче можно скачать архив тестов (смотрите сайдбар справа, раздел «Материалы соревнования»).

Перейдём к задаче.

Напишите программу, которая выводит сумму двух целых чисел.

Так как это ознакомительная задача, то вы можете посмотреть и отправить авторские примеры решений (смотрите ссылку в сайдбаре в разделе «Материалы соревнования»). Конечно, в других задачах примеры решений не предоставляются.

Входные данные
В первой строке входных данных содержится целое число t (1≤t≤104) — количество наборов входных данных в тесте.

Далее следуют описания t наборов входных данных, один набор в строке.

В первой (и единственной) строке набора записаны два целых числа a и b (−1000≤a,b≤1000).

Выходные данные
Для каждого набора входных данных выведите сумму двух заданных чисел, то есть a+b.

Пример
входные данныеСкопировать
5
256 42
1000 1000
-1000 1000
-1000 1000
20 22
выходные данныеСкопировать
298
2000
0
0
42
 */