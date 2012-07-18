LINQ to Objects vs raw code performance
================

A set of tests comparing performance of LINQ to Objects and raw code.

The same computations are performed using LINQ to Objects, for/foreach loops 
and loops with unsafe pointers (when possible).

Output for 20 items:
<pre>
Iteration count: 20

Array.Where():
  For loop:                0,227ns, baseline
  Foreach loop:            0,100ns, x 0,44
  Unsafe loop:             0,234ns, x 1,03
  LINQ:                    0,569ns, x 2,51 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:                0,157ns, baseline
  Foreach loop:            0,088ns, x 0,56
  Unsafe loop:             0,234ns, x 1,49
  LINQ:                    0,862ns, x 5,49 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:                0,704ns, baseline
  Foreach loop:            0,635ns, x 0,90
  Unsafe loop:             0,835ns, x 1,19
  LINQ:                    1,524ns, x 2,16 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:                0,858ns, baseline
  Foreach loop:            1,027ns, x 1,20
  LINQ:                    1,678ns, x 1,96 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:            1,331ns, baseline
  LINQ:                    1,158ns, x 0,87 (WhereSelectArrayIterator`2)

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:            1,116ns, baseline
  LINQ:                    1,624ns, x 1,46 (WhereSelectArrayIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:            6,247ns, baseline
  LINQ:                    6,979ns, x 1,12 (WhereSelectArrayIterator`2)

Array.Where(Method).Select(Method).ToList():
  Foreach loop:            1,285ns, baseline
  LINQ:                    1,932ns, x 1,50 (WhereSelectArrayIterator`2)

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:          0,138ns, baseline
  LINQ:                    2,090ns, x15,14 (WhereArrayIterator`1)

Array.SelectMany(Array).ToList():
  Nested foreach:          0,997ns, baseline
  LINQ:                    2,902ns, x 2,91 (<SelectManyIterator>d__14`2)

Dictionary.Where().Select():
  Foreach loop:            0,500ns, baseline
  LINQ:                    1,551ns, x 3,10 (WhereSelectEnumerableIterator`2)

LINQ only: List.Where().Where():
  .Where(a && b):          0,773ns, baseline (WhereListIterator`1)
  .Where(a).Where(b):      1,185ns, x 1,53 (WhereListIterator`1)
  where a where b:         1,266ns, x 1,64 (WhereListIterator`1)
</pre>

Output for 100 items:
<pre>
Iteration count: 100

Array.Where():
  For loop:                1,285ns, baseline
  Foreach loop:            0,946ns, x 0,74
  Unsafe loop:             1,235ns, x 0,96
  LINQ:                    2,898ns, x 2,26

Array.Where().Select():
  For loop:                0,858ns, baseline
  Foreach loop:            1,366ns, x 1,59
  Unsafe loop:             0,823ns, x 0,96
  LINQ:                    3,768ns, x 4,39

Array.Where().Select().ToList():
  For loop:                3,006ns, baseline
  Foreach loop:            2,771ns, x 0,92
  Unsafe loop:             2,602ns, x 0,87
  LINQ:                    5,408ns, x 1,80

List.Where().Select().ToList():
  For loop:                2,894ns, baseline
  Foreach loop:            3,903ns, x 1,35
  LINQ:                    6,890ns, x 2,38

Sequence.Where().Select().ToList():
  Foreach loop:            4,842ns, baseline
  LINQ:                    5,678ns, x 1,17

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:            7,052ns, baseline
  LINQ:                    8,253ns, x 1,17

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:           30,507ns, baseline
  LINQ:                   32,967ns, x 1,08

Array.Where(Method).Select(Method).ToList():
  Foreach loop:            3,753ns, baseline
  LINQ:                    6,147ns, x 1,64

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:          0,504ns, baseline
  LINQ:                    2,521ns, x 5,00

Array.SelectMany(Array).ToList():
  Nested foreach:          2,594ns, baseline
  LINQ:                    7,298ns, x 2,81

Dictionary.Where().Select():
  Foreach loop:            3,191ns, baseline
  LINQ:                    7,529ns, x 2,36

LINQ only: List.Where().Where():
  .Where(a && b):          3,849ns, baseline
  .Where(a).Where(b):      5,431ns, x 1,41
  where a where b:         5,477ns, x 1,42
</pre>

Output for 10K items:
<pre>
Iteration count: 10000

Array.Where():
  For loop:                0,115ms, baseline
  Foreach loop:            0,119ms, x 1,03
  Unsafe loop:            98,900ns, x 0,86
  LINQ:                    0,283ms, x 2,45

Array.Where().Select():
  For loop:                0,110ms, baseline
  Foreach loop:            0,100ms, x 0,91
  Unsafe loop:            92,700ns, x 0,84
  LINQ:                    0,268ms, x 2,43

Array.Where().Select().ToList():
  For loop:                0,216ms, baseline
  Foreach loop:            0,210ms, x 0,97
  Unsafe loop:             0,187ms, x 0,87
  LINQ:                    0,437ms, x 2,02

List.Where().Select().ToList():
  For loop:                0,240ms, baseline
  Foreach loop:            0,323ms, x 1,34
  LINQ:                    0,434ms, x 1,81

Sequence.Where().Select().ToList():
  Foreach loop:            0,360ms, baseline
  LINQ:                    0,436ms, x 1,21

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:            0,641ms, baseline
  LINQ:                    0,965ms, x 1,50

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:            2,451ms, baseline
  LINQ:                    3,117ms, x 1,27

Array.Where(Method).Select(Method).ToList():
  Foreach loop:            0,266ms, baseline
  LINQ:                    0,496ms, x 1,87

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:         14,485ns, baseline
  LINQ:                   24,864ns, x 1,72

Array.SelectMany(Array).ToList():
  Nested foreach:          0,154ms, baseline
  LINQ:                    0,461ms, x 2,99

Dictionary.Where().Select():
  Foreach loop:            0,306ms, baseline
  LINQ:                    0,606ms, x 1,98

LINQ only: List.Where().Where():
  .Where(a && b):          0,390ms, baseline
  .Where(a).Where(b):      0,444ms, x 1,14
  where a where b:         0,493ms, x 1,27
</pre>

Output for 1M items:
<pre>
Iteration count: 1000000

Array.Where():
  For loop:               10,489ms, baseline
  Foreach loop:           10,882ms, x 1,04
  Unsafe loop:            11,485ms, x 1,09
  LINQ:                   28,315ms, x 2,70

Array.Where().Select():
  For loop:               11,173ms, baseline
  Foreach loop:           11,928ms, x 1,07
  Unsafe loop:            10,941ms, x 0,98
  LINQ:                   32,706ms, x 2,93

Array.Where().Select().ToList():
  For loop:               22,545ms, baseline
  Foreach loop:           20,065ms, x 0,89
  Unsafe loop:            16,244ms, x 0,72
  LINQ:                   45,329ms, x 2,01

List.Where().Select().ToList():
  For loop:               22,489ms, baseline
  Foreach loop:           30,020ms, x 1,33
  LINQ:                   57,522ms, x 2,56

Sequence.Where().Select().ToList():
  Foreach loop:           36,869ms, baseline
  LINQ:                   41,502ms, x 1,13

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:           72,732ms, baseline
  LINQ:                   89,893ms, x 1,24

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:          189,645ms, baseline
  LINQ:                  196,209ms, x 1,03

Array.Where(Method).Select(Method).ToList():
  Foreach loop:           16,403ms, baseline
  LINQ:                   46,315ms, x 2,82

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:          1,153ms, baseline
  LINQ:                    2,012ms, x 1,75

Array.SelectMany(Array).ToList():
  Nested foreach:         16,510ms, baseline
  LINQ:                   57,336ms, x 3,47

Dictionary.Where().Select():
  Foreach loop:           28,437ms, baseline
  LINQ:                   62,829ms, x 2,21

LINQ only: List.Where().Where():
  .Where(a && b):         34,468ms, baseline
  .Where(a).Where(b):     44,955ms, x 1,30
  where a where b:        45,942ms, x 1,33
</pre>

Output for 25M items (100+ MB RAM, so working set doesn't fit into L2):
<pre>
Iteration count: 25000000

Array.Where():
  For loop:              157,113ms, baseline
  Foreach loop:          161,099ms, x 1,03
  Unsafe loop:           157,857ms, x 1,00
  LINQ:                  294,093ms, x 1,87

Array.Where().Select():
  For loop:              116,909ms, baseline
  Foreach loop:          125,255ms, x 1,07
  Unsafe loop:           113,408ms, x 0,97
  LINQ:                  338,736ms, x 2,90

Array.Where().Select().ToList():
  For loop:              251,818ms, baseline
  Foreach loop:          245,916ms, x 0,98
  Unsafe loop:           220,339ms, x 0,87
  LINQ:                  475,278ms, x 1,89

List.Where().Select().ToList():
  For loop:              331,007ms, baseline
  Foreach loop:          361,614ms, x 1,09
  LINQ:                  573,187ms, x 1,73

Sequence.Where().Select().ToList():
  Foreach loop:          398,239ms, baseline
  LINQ:                  475,732ms, x 1,19

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:          845,070ms, baseline
  LINQ:                 1016,649ms, x 1,20

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:         6691,470ms, baseline
  LINQ:                 7482,744ms, x 1,12

Array.Where(Method).Select(Method).ToList():
  Foreach loop:          661,993ms, baseline
  LINQ:                 1239,790ms, x 1,87

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:         30,722ms, baseline
  LINQ:                   53,114ms, x 1,73

Array.SelectMany(Array).ToList():
  Nested foreach:        397,239ms, baseline
  LINQ:                 1326,786ms, x 3,34

Dictionary.Where().Select():
  Foreach loop:          710,104ms, baseline
  LINQ:                 1584,562ms, x 2,23

LINQ only: List.Where().Where():
  .Where(a && b):        866,559ms, baseline
  .Where(a).Where(b):    642,665ms, x 0,74
  where a where b:       508,153ms, x 0,59
</pre>
