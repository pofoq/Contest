using Route256.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Route256.Test_2023_08
{
    internal class TaskF : ITask
    {
        public void Run()
        {
            var caseCount = int.Parse(Console.ReadLine()!);

            for (var i = 0; i < caseCount; i++)
            {
                var periodCount = int.Parse(Console.ReadLine()!);
                var periods = new List<Period>();
                var isValid = true;
                for (int j = 0; j < periodCount; j++)
                {
                    var tempArr = Console.ReadLine()!.Split('-').ToArray();
                    if (isValid
                        && TimeSpan.TryParse($"0:{tempArr[0]}", out var start) 
                        && TimeSpan.TryParse($"0:{tempArr[1]}", out var end)
                        && start.Hours < 24
                        && end.Hours < 24
                        && start <= end)
                    {
                        periods.Add(new Period(start, end));
                    }
                    else if (isValid)
                    {
                        isValid = false;
                    }
                }

                if (isValid && periodCount > 1)
                {
                    //periods.Sort((x, y) => TimeSpan.Compare(x.Start, y.Start));
                    periods.Sort();
                    var current = periods[periodCount - 1];
                    Period next;

                    for (var j = 0; j < periods.Count; j++)
                    {
                        next = periods[j];
                        if (!current.CheckNextPeriod(next))
                        {
                            isValid = false;
                            break;
                        }
                        current = next;
                    }
                }

                Console.WriteLine(isValid ? "YES" : "NO");
            }
        }
        struct Period : IComparable<Period>
        {
            public TimeSpan Start { get; set; }
            public TimeSpan End { get; set; }
            public Period(TimeSpan start, TimeSpan end)
            {
                Start = start;//.Equals(TimeSpan.FromSeconds(0)) ? TimeSpan.FromDays(1) : start;
                End = end;//.Equals(TimeSpan.FromSeconds(0)) ? TimeSpan.FromDays(1) : end;
            }

            public readonly bool CheckNextPeriod(Period next)
            {
                return Start > next.End && End > next.End
                    || Start < next.Start && End < next.Start;
            }

            public readonly int CompareTo(Period other)
            {
                return TimeSpan.Compare(Start, other.Start);
            }
        }
    }
}
/*
 F. Отрезки времени (20 баллов)
ограничение по времени на тест2 секунды
ограничение по памяти на тест512 мегабайт
вводстандартный ввод
выводстандартный вывод
Вам задан набор отрезков времени. Каждый отрезок задан в формате HH:MM:SS-HH:MM:SS, то есть сначала заданы часы, минуты и секунды левой границы отрезка, а затем часы, минуты и секунды правой границы.

Вам необходимо выполнить валидацию заданного набора отрезков времени. Иными словами, вам нужно проверить следующие условия:

часы, минуты и секунды заданы корректно (то есть часы находятся в промежутке от 0
 до 23
, а минуты и секунды — в промежутке от 0
 до 59
);
левая граница отрезка находится не позже его правой границы (но границы могут быть равны);
никакая пара отрезков не пересекается (даже в граничных моментах времени).
Вам необходимо вывести YES, если заданный набор отрезков времени проходит валидацию, и NO в противном случае.

Вам необходимо ответить на t
 независимых наборов тестовых данных.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
Первая строка входных данных содержит одно целое число t
 (1≤t≤10
) — количество наборов тестовых данных. Затем следуют t
 наборов.

Первая строка набора содержит одно целое число n
 (1≤n≤2⋅104
) — количество отрезков времени. В следующих n
 строках следуют описания отрезков.

Описание отрезка времени задано в формате HH:MM:SS-HH:MM:SS, где HH, MM и SS — последовательности из двух цифр. Заметьте, что никаких пробелов в описании формата нет. Также ни в одном описании нет пробелов в начале и конце строки.

Выходные данные
Для каждого набора тестовых данных выведите ответ — YES, если заданный набор отрезков времени проходит валидацию, и NO в противном случае. Ответы выводите в порядке следования наборов во входных данных.

Пример
входные данныеСкопировать
6
1
02:46:00-03:14:59
2
23:59:59-23:59:59
00:00:00-23:59:58
2
23:59:58-23:59:59
00:00:00-23:59:58
2
23:59:59-23:59:58
00:00:00-23:59:57
6
17:53:39-20:20:02
10:39:17-11:00:52
08:42:47-09:02:14
09:44:26-10:21:41
00:46:17-02:07:19
22:42:50-23:17:46
1
24:00:00-23:59:59
выходные данныеСкопировать
YES
YES
NO
NO
YES
NO

 */