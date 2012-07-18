LINQ to Objects vs raw code performance
================

A set of tests comparing LINQ to Objects performance vs raw code 
(the same operations performed by for and foreach loops, as well as 
loops with unsafe pointers).

Output for 20 items:
<pre>
Iteration count: 20

Array.Where():
  For loop:           0,207ns, baseline
  Foreach loop:       0,100ns, x 0,48
  Unsafe loop:        0,219ns, x 1,06
  LINQ:               0,650ns, x 3,14 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:           0,238ns, baseline
  Foreach loop:       0,100ns, x 0,42
  Unsafe loop:        0,200ns, x 0,84
  LINQ:               0,735ns, x 3,09 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:           0,685ns, baseline
  Foreach loop:       0,789ns, x 1,15
  Unsafe loop:        0,612ns, x 0,89
  LINQ:               1,628ns, x 2,38 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:           0,823ns, baseline
  Foreach loop:       1,039ns, x 1,26
  LINQ:               1,936ns, x 2,35 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:       1,385ns, baseline
  LINQ:               1,451ns, x 1,05 (WhereSelectArrayIterator`2)

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       0,954ns, baseline
  LINQ:               1,412ns, x 1,48 (WhereSelectArrayIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:       5,027ns, baseline
  LINQ:               6,971ns, x 1,39 (WhereSelectArrayIterator`2)

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       1,070ns, baseline
  LINQ:               1,928ns, x 1,80 (WhereSelectArrayIterator`2)

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     0,134ns, baseline
  LINQ:               2,078ns, x15,51 (WhereArrayIterator`1)

Array.SelectMany(Array).ToList():
  Nested foreach:     0,958ns, baseline
  LINQ:               2,760ns, x 2,88 (<SelectManyIterator>d__14`2)
</pre>

Output for 100 items:
<pre>
Iteration count: 100

Array.Where():
  For loop:           1,089ns, baseline
  Foreach loop:       0,904ns, x 0,83
  Unsafe loop:        1,100ns, x 1,01
  LINQ:               2,864ns, x 2,63

Array.Where().Select():
  For loop:           0,908ns, baseline
  Foreach loop:       1,135ns, x 1,25
  Unsafe loop:        0,935ns, x 1,03
  LINQ:               3,603ns, x 3,97

Array.Where().Select().ToList():
  For loop:           2,382ns, baseline
  Foreach loop:       3,071ns, x 1,29
  Unsafe loop:        2,617ns, x 1,10
  LINQ:               5,308ns, x 2,23

List.Where().Select().ToList():
  For loop:           2,825ns, baseline
  Foreach loop:       3,938ns, x 1,39
  LINQ:               6,648ns, x 2,35

Sequence.Where().Select().ToList():
  Foreach loop:       4,634ns, baseline
  LINQ:               5,066ns, x 1,09

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       5,743ns, baseline
  LINQ:               8,307ns, x 1,45

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:      30,781ns, baseline
  LINQ:              31,170ns, x 1,01

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       3,603ns, baseline
  LINQ:               6,105ns, x 1,69

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     0,400ns, baseline
  LINQ:               2,336ns, x 5,84

Array.SelectMany(Array).ToList():
  Nested foreach:     2,502ns, baseline
  LINQ:               7,799ns, x 3,12
</pre>

Output for 10K items:
<pre>
Iteration count: 10000

Array.Where():
  For loop:          97,300ns, baseline
  Foreach loop:       0,118ms, x 1,21
  Unsafe loop:       93,500ns, x 0,96
  LINQ:               0,279ms, x 2,87

Array.Where().Select():
  For loop:           0,109ms, baseline
  Foreach loop:       0,116ms, x 1,07
  Unsafe loop:        0,105ms, x 0,96
  LINQ:               0,268ms, x 2,46

Array.Where().Select().ToList():
  For loop:           0,213ms, baseline
  Foreach loop:       0,209ms, x 0,98
  Unsafe loop:        0,154ms, x 0,72
  LINQ:               0,367ms, x 1,72

List.Where().Select().ToList():
  For loop:           0,239ms, baseline
  Foreach loop:       0,263ms, x 1,10
  LINQ:               0,435ms, x 1,82

Sequence.Where().Select().ToList():
  Foreach loop:       0,296ms, baseline
  LINQ:               0,368ms, x 1,24

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       0,655ms, baseline
  LINQ:               0,994ms, x 1,52

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:       2,778ms, baseline
  LINQ:               3,067ms, x 1,10

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       0,265ms, baseline
  LINQ:               0,496ms, x 1,87

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:    16,245ns, baseline
  LINQ:              25,676ns, x 1,58

Array.SelectMany(Array).ToList():
  Nested foreach:     0,138ms, baseline
  LINQ:               0,456ms, x 3,30
</pre>

Output for 1M items:
<pre>
Iteration count: 1000000

Array.Where():
  For loop:           9,861ms, baseline
  Foreach loop:      12,043ms, x 1,22
  Unsafe loop:       11,704ms, x 1,19
  LINQ:              28,656ms, x 2,91

Array.Where().Select():
  For loop:          11,181ms, baseline
  Foreach loop:      11,595ms, x 1,04
  Unsafe loop:       10,728ms, x 0,96
  LINQ:              32,942ms, x 2,95

Array.Where().Select().ToList():
  For loop:          22,774ms, baseline
  Foreach loop:      22,029ms, x 0,97
  Unsafe loop:       19,571ms, x 0,86
  LINQ:              44,498ms, x 1,95

List.Where().Select().ToList():
  For loop:          24,739ms, baseline
  Foreach loop:      33,170ms, x 1,34
  LINQ:              49,065ms, x 1,98

Sequence.Where().Select().ToList():
  Foreach loop:      36,786ms, baseline
  LINQ:              44,644ms, x 1,21

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:      72,754ms, baseline
  LINQ:              87,917ms, x 1,21

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:     217,014ms, baseline
  LINQ:             192,905ms, x 0,89

Array.Where(Method).Select(Method).ToList():
  Foreach loop:      17,312ms, baseline
  LINQ:              52,204ms, x 3,02

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     1,209ms, baseline
  LINQ:               2,322ms, x 1,92

Array.SelectMany(Array).ToList():
  Nested foreach:    16,563ms, baseline
  LINQ:              55,598ms, x 3,36
</pre>

Output for 50M items (200+ MB RAM, so working set doesn't fit into L2):
<pre>
Iteration count: 50000000

Array.Where():
  For loop:         286,645ms, baseline
  Foreach loop:     250,922ms, x 0,88
  Unsafe loop:      243,444ms, x 0,85
  LINQ:             587,352ms, x 2,05

Array.Where().Select():
  For loop:         316,386ms, baseline
  Foreach loop:     249,046ms, x 0,79
  Unsafe loop:      233,320ms, x 0,74
  LINQ:             676,696ms, x 2,14

Array.Where().Select().ToList():
  For loop:         513,258ms, baseline
  Foreach loop:     514,219ms, x 1,00
  Unsafe loop:      450,329ms, x 0,88
  LINQ:             961,839ms, x 1,87

List.Where().Select().ToList():
  For loop:         560,672ms, baseline
  Foreach loop:     732,309ms, x 1,31
  LINQ:            1153,024ms, x 2,06

Sequence.Where().Select().ToList():
  Foreach loop:    1702,147ms, baseline
  LINQ:            2049,494ms, x 1,20

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:    3572,019ms, baseline
  LINQ:            4362,822ms, x 1,22

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:    6330,244ms, baseline
  LINQ:           14922,893ms, x 2,36

Array.Where(Method).Select(Method).ToList():
  Foreach loop:    1380,327ms, baseline
  LINQ:            2390,778ms, x 1,73

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:    60,780ms, baseline
  LINQ:             105,368ms, x 1,73

Array.SelectMany(Array).ToList():
  Nested foreach:   812,857ms, baseline
  LINQ:            2677,457ms, x 3,29
</pre>

