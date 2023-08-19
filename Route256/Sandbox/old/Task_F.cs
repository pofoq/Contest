using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole.Codeforces.Sandbox
{
    internal class Task_F
    {
        public void Main(string[] args)
        {
            var testCaseCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < testCaseCount; i++)
            {
                var intervalCount = int.Parse(Console.ReadLine());

                var intervals = new List<Interval>();
                var isError = false;

                for (var row = 0; row < intervalCount; row++)
                {
                    var str = Console.ReadLine();

                    if (isError)
                        continue;
                    if (!new Interval(str, ref intervals).IsValid)
                        isError = true;
                }

                if (!isError)
                    isError = !ValidateIntervals(intervals);

                Console.WriteLine(!isError ? "YES" : "NO");
            }
        }

        static bool ValidateIntervals(List<Interval> list)
        {
            list = list.OrderByDescending(interval => interval).ToList();

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].End <= list[i + 1].Start)
                    return false;
                if (list[i].Start <= list[i + 1].End)
                    return false;
            }

            return true;
        }

        private struct Time
        {
            public readonly int Hh, Mm, Ss;
            public Time(int hh, int mm, int ss)
            {
                Hh = hh;
                Mm = mm;
                Ss = ss;
            }
            public bool IsValid =>
                Hh >= 0 && Hh < 24 &&
                Mm >= 0 && Mm < 60 &&
                Ss >= 0 && Ss < 60;
            public static bool operator >(Time time1, Time time2)
            {
                if (time1.Hh > time2.Hh)
                    return true;
                if (time1.Hh < time2.Hh)
                    return false;
                if (time1.Mm > time2.Mm)
                    return true;
                if (time1.Mm < time2.Mm)
                    return false;
                if (time1.Ss > time2.Ss)
                    return true;
                if (time1.Ss < time2.Ss)
                    return false;
                return false;
            }
            public static bool operator <(Time time1, Time time2)
            {
                if (time1.Hh == time2.Hh &&
                    time1.Mm == time2.Mm &&
                    time1.Ss == time2.Ss)
                    return false;
                return !(time1 > time2);
            }
            public static bool operator ==(Time time1, Time time2) =>
                time1.Hh == time2.Hh &&
                time1.Mm == time2.Mm &&
                time1.Ss == time2.Ss;
            public static bool operator !=(Time time1, Time time2) =>
                time1.Hh != time2.Hh ||
                time1.Mm != time2.Mm ||
                time1.Ss != time2.Ss;
            public static bool operator >=(Time time1, Time time2) =>
                time1 > time2 || time1 == time2;
            public static bool operator <=(Time time1, Time time2) =>
                time1 < time2 || time1 == time2;

            public override string ToString()
            {
                return $"{Hh}:{Mm}:{Ss}";
            }
        }

        private struct Interval : IComparable<Interval>
        {
            public readonly Time Start, End;
            public bool IsValid => Start.IsValid && End.IsValid && Start <= End;
            public Interval(string str, ref List<Interval> intervals)
            {
                var nums = str.Split('-').SelectMany(s => s.Split(':')).Select(s => int.Parse(s)).ToArray();
                Start = new Time(nums[0], nums[1], nums[2]);
                End = new Time(nums[3], nums[4], nums[5]);
                intervals.Add(this);
            }

            public int CompareTo(Interval other)
            {
                if (Start > other.Start)
                    return 1;
                return -1;
            }

            public override string ToString()
            {
                return $"{Start.Hh}:{Start.Mm}:{Start.Ss}-{End.Hh}:{End.Mm}:{End.Ss}";
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

часы, минуты и секунды заданы корректно (то есть часы находятся в промежутке от 0 до 23, а минуты и секунды — в промежутке от 0 до 59);
левая граница отрезка находится не позже его правой границы (но границы могут быть равны);
никакая пара отрезков не пересекается (даже в граничных моментах времени).
Вам необходимо вывести YES, если заданный набор отрезков времени проходит валидацию, и NO в противном случае.

Вам необходимо ответить на t независимых наборов тестовых данных.

Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
Первая строка входных данных содержит одно целое число t (1≤t≤10) — количество наборов тестовых данных. Затем следуют t наборов.

Первая строка набора содержит одно целое число n (1≤n≤2⋅104) — количество отрезков времени. В следующих n строках следуют описания отрезков.

Описание отрезка времени задано в формате HH:MM:SS-HH:MM:SS, где HH, MM и SS — последовательности из двух цифр. Заметьте, что никаких пробелов в описании формата нет. Также ни в одном описании нет пробелов в начале и конце строки.

Выходные данные
Для каждого набора тестовых данных выведите ответ — YES, если заданный набор отрезков времени проходит валидацию, и NO в противном случае. Ответы выводите в порядке следования наборов во входных данных.

Пример

входные данные
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

выходные данные
YES
YES
NO
NO
YES
NO
 */