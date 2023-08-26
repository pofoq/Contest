using Route256.Common;

namespace Route256.Sandbox
{
    internal class TaskJ : ITask
    {
        public void Run()
        {
            var dictLength = int.Parse(Console.ReadLine()!);

            var words = new Dictionary<string, string>();
            for (var i = 0; i < dictLength; i++)
            {
                var str = Console.ReadLine()!;
                var arr = str.ToArray();
                Array.Reverse(arr);
                words.Add(str, new string(arr));
            }

            var queryCount = int.Parse(Console.ReadLine()!);
            for (var i = 0; i < queryCount; i++)
            {
                var query = Console.ReadLine()!;
                var arr = query.ToArray();
                Array.Reverse(arr);
                var str = new string(arr);

                var tempArr = words.Where(x => x.Key != query && x.Value[0].Equals(arr[0])).ToDictionary(x => x.Key, x => x.Value);
                string? result = null;
                if (tempArr.Count == 0)
                {
                    tempArr = words.Where(x => x.Value[1].Equals(arr[0]) && x.Key != query).ToDictionary(x => x.Key, x => x.Value);
                }
                if (tempArr.Count == 0)
                {
                    result = words.First().Key;
                }
                else if (tempArr.Count == 1)
                {
                    result = tempArr.First().Key;
                }
                else
                {
                    var j = 1;
                    while (tempArr?.Count > 1 && j < query.Length)
                    {
                        result = tempArr.First().Key;
                        tempArr = words.Where(x => x.Value[j].Equals(arr[j])).ToDictionary(x => x.Key, x => x.Value);
                        j++;
                    }
                }

                if (!string.IsNullOrEmpty(result))
                {
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