using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    // Чужое решение
    internal class Task_J
    {
        public void Main(string[] args)
        {
            var dictionaryLength = int.Parse(Console.ReadLine()!);
            var dictionary = new Dictionary<string, List<string>>();
            for (var i = 0; i < dictionaryLength; i++)
            {
                var word = Console.ReadLine()!;
                for (var j = 0; j < word.Length; j++)
                {
                    var suffix = word.Substring(j, word.Length - j);
                    if (!dictionary.TryAdd(suffix, new List<string> { word }))
                        dictionary[suffix].Add(word);
                }
            }

            var requestCount = int.Parse(Console.ReadLine()!);
            // using var writer = new StreamWriter(@"D:\Desktop\output.txt");
            // Console.SetOut(writer);
            for (var i = 0; i < requestCount; i++)
            {
                var word = Console.ReadLine()!;
                for (var j = 0; j < word.Length; j++)
                {
                    if (dictionary.TryGetValue(word.Substring(j, word.Length - j), out var dictionaryWords) &&
                        dictionaryWords.Any(w => w != word))
                    {
                        Console.WriteLine(dictionaryWords.First(w => w != word));
                        break;
                    }

                    if (j == word.Length - 1)
                    {
                        Console.WriteLine(dictionary.First(pair => pair.Value.Contains(pair.Key) && pair.Key != word).Key);
                    }
                }
            }
        }
    }
}

/*
 J. Рифмы (30 баллов)
ограничение по времени на тест2 секунды
ограничение по памяти на тест512 мегабайт
вводстандартный ввод
выводстандартный вывод
Вы разрабатываете программу автоматической генерации стихотворений. Один из модулей этой программы должен подбирать рифмы к словам из некоторого словаря.

Словарь содержит n различных слов. Словами будем называть последовательности из 1—10 строчных букв латинского алфавита.

Зарифмованность двух слов — это длина их наибольшего общего суффикса (суффиксом будем называть какое-то количество букв в конце слова). Например:

task и flask имеют зарифмованность 3 (наибольший общий суффикс — ask);
decide и code имеют зарифмованность 2 (наибольший общий суффикс — de);
id и void имеют зарифмованность 2 (наибольший общий суффикс — id);
code и forces имеют зарифмованность 0.
Ваша программа должна обработать q запросов следующего вида: дано слово ti (возможно, принадлежащее словарю), необходимо найти слово из словаря, которое не совпадает с ti и имеет максимальную зарифмованность с ti среди всех слов словаря, не совпадающих с ti. Если подходящих слов несколько — выведите любое из них.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
Первая строка содержит одно целое число n (2≤n≤50000) — размер словаря.

Далее следуют n строк, i-я строка содержит одну строку si (1≤|si|≤10) — i-е слово из словаря. В словаре все слова различны.

Следующая строка содержит одно целое число q (1≤q≤50000) — количество запросов.

Далее следуют q строк, i-я строка содержит одну строку ti (1≤|ti|≤10) — i-й запрос.

Каждая строка si и каждая строка ti состоит только из строчных букв латинского алфавита.

Выходные данные
Для каждого запроса выведите одну строку — слово из словаря, которое не совпадает с заданным в запросе и имеет с ним максимальную зарифмованность (если таких несколько — выведите любое).

Пример
входные данныеСкопировать
3
task
decide
id
6
flask
code
void
forces
id
ask
выходные данныеСкопировать
task
decide
id
task
decide
task

 */