using Route256.Common;

namespace Route256.Sandbox
{
    internal class TaskH : ITask
    {
        public void Run()
        {
            var caseCount = int.Parse(Console.ReadLine()!);

            for (var i = 0; i < caseCount; i++)
            {
                var arr = Console.ReadLine()!.Split(' ').Select(i => int.Parse(i)).ToArray();
                var rows = arr[0]; // кол-во строк
                var length = arr[1]; // кол-во символов в каждой строке
                var map = new Dictionary<Tuple<int, int>, Hex>();
                for (var j = 1; j <= rows; j++)
                {
                    var str = Console.ReadLine()!;
                    for (var k = 0; k < length; k++)
                    {
                        if (str[k] == '.')
                        {
                            continue;
                        }
                        var id = new Tuple<int, int>(j, k + 1);
                        map.Add(id, new Hex(id, str[k], rows, length));
                    }
                }

                var colors = new HashSet<Char>();
                var cts = new CancellationTokenSource();
                var result = true;
                foreach (var hex in map.Values)
                {
                    if (cts.IsCancellationRequested) break;
                    if (hex.IsChecked)
                    {
                        continue;
                    }
                    if (!colors.Contains(hex.Color))
                    {
                        colors.Add(hex.Color);
                        Check(map, hex.Color, hex, cts);
                        continue;
                    }
                    cts.Cancel();
                    result = false;
                }

                Console.WriteLine(result ? "YES" : "NO");

                void Check(Dictionary<Tuple<int, int>, Hex> map, char color, Hex hex, CancellationTokenSource cts)
                {
                    if (hex.IsChecked || !hex.Color.Equals(color) || cts.IsCancellationRequested)
                    {
                        return;
                    }
                    hex.IsChecked = true;
                    foreach (var nextId in hex.Next)
                    {
                        Check(map, color, map[nextId], cts);
                    }
                }
            }
        }
    }

    public class Hex
    {
        public Tuple<int, int> Id { get; }
        public IReadOnlyCollection<Tuple<int, int>> Next { get; }
        public char Color { get; }
        public bool IsChecked { get; set; }
        public Hex(Tuple<int, int> id, char color, int rows, int length)
        {
            Id = id;
            Color = color;
            IsChecked = false;
            var list = new List<Tuple<int, int>>();
            if (id.Item2 + 2 <= length) list.Add(new Tuple<int, int>(id.Item1, id.Item2 + 2));
            if (id.Item1 < rows)
            {
                if (id.Item2 - 1 > 0) list.Add(new Tuple<int, int>(id.Item1 + 1, id.Item2 - 1));
                if (id.Item2 + 1 <= length) list.Add(new Tuple<int, int>(id.Item1 + 1, id.Item2 + 1));
            }
            if (id.Item2 - 2 > 0) list.Add(new Tuple<int, int>(id.Item1, id.Item2 - 2));
            if (id.Item1 > 1)
            {
                if (id.Item2 - 1 > 0) list.Add(new Tuple<int, int>(id.Item1 - 1, id.Item2 - 1));
                if (id.Item2 + 1 <= length) list.Add(new Tuple<int, int>(id.Item1 - 1, id.Item2 + 1));
            }
            Next = list;
        }
    }
}
/*
 H. Валидация карты (25 баллов)
ограничение по времени на тест1 секунда
ограничение по памяти на тест512 мегабайт
вводстандартный ввод
выводстандартный вывод
В этой задаче вам необходимо реализовать валидацию корректности карты для стратегической компьютерной игры.

Карта состоит из гексагонов (шестиугольников), каждый из которых принадлежит какому-то региону карты. В файлах игры карта представлена как n
 строк по m
 символов в каждой (строки и символы в них нумеруются с единицы). Каждый нечетный символ каждой четной строки и каждый четный символ каждой нечетной строки — точка (символ . с ASCII кодом 46
); все остальные символы соответствуют гексагонам и являются заглавными буквами латинского алфавита. Буква указывает на то, какому региону принадлежит гексагон.

Посмотрите на картинку ниже, чтобы понять, как описание карты в файлах игры соответствует карте из шестиугольников.

Соответствие описания карты в файле (слева) и самой карты (справа). Регионы R, G, V, Y и B окрашены в красный, зеленый, фиолетовый, желтый и синий цвет, соответственно.
Вы должны проверить, что каждый регион карты является одной связной областью. Иными словами, не должно быть двух гексагонов, принадлежащих одному и тому же региону, которые не соединены другими гексагонами этого же региона.

Карта слева является корректной. Карта справа не является корректной, так как гексагоны, обозначенные цифрами 1
 и 2
, принадлежат одному и тому же региону (обозначенному красным цветом), но не соединены другими гексагонами этого региона.
Неполные решения этой задачи (например, недостаточно эффективные) могут быть оценены частичным баллом.

Входные данные
В первой строке задано одно целое число t
 (1≤t≤100
) — количество наборов входных данных.

Первая строка набора входных данных содержит два целых числа n
 и m
 (2≤n,m≤20
) — количество строк и количество символов в каждой строке в описании карты.

Далее следуют n
 строк по m
 символов в каждой — описание карты. Каждый нечетный символ каждой четной строки и каждый четный символ каждой нечетной строки — точка (символ . с ASCII кодом 46
); все остальные символы соответствуют гексагонам и являются заглавными буквами латинского алфавита.

Выходные данные
На каждый набор входных данных выведите ответ в отдельной строке — YES, если каждый регион карты представляет связную область, или NO, если это не так.

Пример
входные данныеСкопировать
3
3 7
R.R.R.G
.Y.G.G.
B.Y.V.V
4 8
Y.R.B.B.
.R.R.B.V
B.R.B.R.
.B.B.R.R
2 7
G.B.R.G
.G.G.G.
выходные данныеСкопировать
YES
NO
YES
Примечание
Первые два набора входных данных из примера показаны на второй картинке в условии.
 */