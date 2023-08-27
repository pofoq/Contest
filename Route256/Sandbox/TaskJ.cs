﻿using Route256.Common;

namespace Route256.Sandbox
{
    internal class TaskJ : ITask
    {
        public void Run()
        {
            const string vowels = "aeiouy";

            static List<string> GetSufixes(string word, bool isAlternative = false)
            {
                var list = new List<string>();
                var isVowel = vowels.Contains(word[^1]);

                for (var j = word.Length - 1; j > 0; j--)
                {
                    list.Add(word[j..]);
                    if (isVowel && j - 1 > 0)
                    {
                        list.Add(word.Substring(j - 1, word.Length - (j - 1) - 1));
                    }
                }
                if (isVowel)
                {
                    for (var j = word.Length - 1; j > 0; j--)
                    {
                        list.Add(word[j..]);
                        if (isVowel && j - 1 > 0)
                        {
                            list.Add(word.Substring(j - 1, word.Length - (j - 1) - 1));
                        }
                    }
                }
                return list;
            }

            var dictLength = int.Parse(Console.ReadLine()!);

            var words = new Dictionary<string, List<string>>();
            for (var i = 0; i < dictLength; i++)
            {
                var word = Console.ReadLine()!;
                words.Add(word, GetSufixes(word));
            }

            var queryCount = int.Parse(Console.ReadLine()!);
            for (var i = 0; i < queryCount; i++)
            {
                var query = Console.ReadLine()!;
                var isVowel = vowels.Contains(query[^1]);
                var sufixes = GetSufixes(query);

                var t1 = query[^1];
                var t2 = query[^2];

                var tempList = words
                    .Where(d => d.Key != query && d.Value.Any(s => s.Equals(query[^1].ToString())))
                    .ToList();

                if (tempList.Count == 0 && isVowel)
                {
                    tempList = words
                        .Where(d => d.Key != query && d.Value.Any(s => s.Equals(query[^2].ToString())))
                        .ToList();
                }
                if (tempList.Count == 0)
                {
                    continue;
                }
                if (tempList.Count == 1)
                {
                    Console.WriteLine(tempList[0].Key);
                    continue;
                }
                else
                {
                    string result = "";
                    for (var j = 1; j < query.Length; j++)
                    {
                        result = tempList[0].Key;
                        tempList = tempList
                            .Where(d => d.Key != query && (d.Value.Any(s => s.Equals(query[j..])) || isVowel && d.Value.Any(s => s.Equals(query[^2].ToString()))))
                            .ToList();
                        if (tempList.Count == 0)
                        {
                            break;
                        }
                        if (tempList.Count == 1)
                        {
                            result = tempList[0].Key;
                            break;
                        }
                    }
                    Console.WriteLine(result);
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

Словарь содержит n
 различных слов. Словами будем называть последовательности из 1
—10
 строчных букв латинского алфавита.

Зарифмованность двух слов — это длина их наибольшего общего суффикса (суффиксом будем называть какое-то количество букв в конце слова). Например:

task и flask имеют зарифмованность 3
 (наибольший общий суффикс — ask);
decide и code имеют зарифмованность 2
 (наибольший общий суффикс — de);
id и void имеют зарифмованность 2
 (наибольший общий суффикс — id);
code и forces имеют зарифмованность 0
.
Ваша программа должна обработать q
 запросов следующего вида: дано слово ti
 (возможно, принадлежащее словарю), необходимо найти слово из словаря, которое не совпадает с ti
 и имеет максимальную зарифмованность с ti
 среди всех слов словаря, не совпадающих с ti
. Если подходящих слов несколько — выведите любое из них.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
Первая строка содержит одно целое число n
 (2≤n≤50000
) — размер словаря.

Далее следуют n
 строк, i
-я строка содержит одну строку si
 (1≤|si|≤10
) — i
-е слово из словаря. В словаре все слова различны.

Следующая строка содержит одно целое число q
 (1≤q≤50000
) — количество запросов.

Далее следуют q
 строк, i
-я строка содержит одну строку ti
 (1≤|ti|≤10
) — i
-й запрос.

Каждая строка si
 и каждая строка ti
 состоит только из строчных букв латинского алфавита.

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