LINQ to Objects vs raw code performance
================

A set of tests comparing performance of LINQ to Objects and raw code.

The same computations are performed using LINQ to Objects, for/foreach loops 
and loops with unsafe pointers (when possible).

Output for 20 items:
<pre>
Iteration count: 20

Array.Where():
  For loop:                0,100ns, baseline
  Foreach loop:            0,250ns, x 2,50
  Unsafe loop:             0,088ns, x 0,88
  LINQ:                    0,746ns, x 7,46 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:                0,307ns, baseline
  Foreach loop:            0,088ns, x 0,29
  Unsafe loop:             0,311ns, x 1,01
  LINQ:                    0,954ns, x 3,11 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:                0,488ns, baseline
  Foreach loop:            0,354ns, x 0,73
  Unsafe loop:             0,562ns, x 1,15
  LINQ:                    1,408ns, x 2,89 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:                0,696ns, baseline
  Foreach loop:            0,943ns, x 1,35
  LINQ:                    1,705ns, x 2,45 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:            1,358ns, baseline
  LINQ:                    2,302ns, x 1,70 (WhereSelectEnumerableIterator`2)

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:            1,254ns, baseline
  LINQ:                    2,001ns, x 1,60 (WhereSelectArrayIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:            6,228ns, baseline
  LINQ:                    7,010ns, x 1,13 (WhereSelectArrayIterator`2)

Array.Where(Method).Select(Method).ToList():
  Foreach loop:            1,162ns, baseline
  LINQ:                    1,959ns, x 1,69 (WhereSelectArrayIterator`2)

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:          0,134ns, baseline
  LINQ:                    2,109ns, x15,74 (WhereArrayIterator`1)

Array.SelectMany(Array).ToList():
  Nested foreach:          0,920ns, baseline
  LINQ:                    2,506ns, x 2,72 (<SelectManyIterator>d__14`2)

Dictionary.Where().Select():
  Foreach loop:            0,723ns, baseline
  LINQ:                    1,678ns, x 2,32 (WhereSelectEnumerableIterator`2)

LINQ only: List.Where().Where():
  .Where(a && b):          0,839ns, baseline (WhereListIterator`1)
  .Where(a).Where(b):      1,154ns, x 1,38 (WhereListIterator`1)
  where a where b:         1,228ns, x 1,46 (WhereListIterator`1)
</pre>

Output for 100 items:
<pre>
Iteration count: 100

Array.Where():
  For loop:                0,997ns, baseline
  Foreach loop:            1,166ns, x 1,17
  Unsafe loop:             0,854ns, x 0,86
  LINQ:                    3,160ns, x 3,17

Array.Where().Select():
  For loop:                0,935ns, baseline
  Foreach loop:            1,208ns, x 1,29
  Unsafe loop:             0,916ns, x 0,98
  LINQ:                    3,530ns, x 3,78

Array.Where().Select().ToList():
  For loop:                2,879ns, baseline
  Foreach loop:            2,779ns, x 0,97
  Unsafe loop:             2,640ns, x 0,92
  LINQ:                    5,743ns, x 1,99

List.Where().Select().ToList():
  For loop:                2,975ns, baseline
  Foreach loop:            4,065ns, x 1,37
  LINQ:                    6,971ns, x 2,34

Sequence.Where().Select().ToList():
  Foreach loop:            5,266ns, baseline
  LINQ:                    7,976ns, x 1,51

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:            7,033ns, baseline
  LINQ:                    8,037ns, x 1,14

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:           31,335ns, baseline
  LINQ:                   32,783ns, x 1,05

Array.Where(Method).Select(Method).ToList():
  Foreach loop:            3,764ns, baseline
  LINQ:                    6,201ns, x 1,65

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:          0,465ns, baseline
  LINQ:                    2,302ns, x 4,95

Array.SelectMany(Array).ToList():
  Nested foreach:          2,479ns, baseline
  LINQ:                    7,537ns, x 3,04

Dictionary.Where().Select():
  Foreach loop:            2,994ns, baseline
  LINQ:                    6,936ns, x 2,32

LINQ only: List.Where().Where():
  .Where(a && b):          3,888ns, baseline
  .Where(a).Where(b):      5,089ns, x 1,31
  where a where b:         5,085ns, x 1,31
</pre>

Output for 10K items:
<pre>
Iteration count: 10000

Array.Where():
  For loop:                0,108ms, baseline
  Foreach loop:            0,100ms, x 0,93
  Unsafe loop:            89,300ns, x 0,83
  LINQ:                    0,283ms, x 2,61

Array.Where().Select():
  For loop:                0,113ms, baseline
  Foreach loop:            0,115ms, x 1,01
  Unsafe loop:            95,400ns, x 0,84
  LINQ:                    0,325ms, x 2,87

Array.Where().Select().ToList():
  For loop:                0,174ms, baseline
  Foreach loop:            0,212ms, x 1,22
  Unsafe loop:             0,174ms, x 1,00
  LINQ:                    0,378ms, x 2,17

List.Where().Select().ToList():
  For loop:                0,197ms, baseline
  Foreach loop:            0,324ms, x 1,64
  LINQ:                    0,480ms, x 2,43

Sequence.Where().Select().ToList():
  Foreach loop:            0,351ms, baseline
  LINQ:                    0,672ms, x 1,91

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:            0,752ms, baseline
  LINQ:                    0,873ms, x 1,16

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:            2,468ms, baseline
  LINQ:                    2,830ms, x 1,15

Array.Where(Method).Select(Method).ToList():
  Foreach loop:            0,268ms, baseline
  LINQ:                    0,497ms, x 1,85

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:         16,618ns, baseline
  LINQ:                   25,553ns, x 1,54

Array.SelectMany(Array).ToList():
  Nested foreach:          0,134ms, baseline
  LINQ:                    0,557ms, x 4,17

Dictionary.Where().Select():
  Foreach loop:            0,305ms, baseline
  LINQ:                    0,684ms, x 2,24

LINQ only: List.Where().Where():
  .Where(a && b):          0,319ms, baseline
  .Where(a).Where(b):      0,412ms, x 1,29
  where a where b:         0,499ms, x 1,56
</pre>

Output for 1M items:
<pre>
Iteration count: 1000000

Array.Where():
  For loop:               11,549ms, baseline
  Foreach loop:           12,360ms, x 1,07
  Unsafe loop:            10,848ms, x 0,94
  LINQ:                   28,738ms, x 2,49

Array.Where().Select():
  For loop:               11,643ms, baseline
  Foreach loop:           12,289ms, x 1,06
  Unsafe loop:            11,232ms, x 0,96
  LINQ:                   32,517ms, x 2,79

Array.Where().Select().ToList():
  For loop:               22,210ms, baseline
  Foreach loop:           21,941ms, x 0,99
  Unsafe loop:            18,098ms, x 0,81
  LINQ:                   44,723ms, x 2,01

List.Where().Select().ToList():
  For loop:               24,972ms, baseline
  Foreach loop:           30,437ms, x 1,22
  LINQ:                   54,103ms, x 2,17

Sequence.Where().Select().ToList():
  Foreach loop:           39,461ms, baseline
  LINQ:                   66,389ms, x 1,68

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:           72,100ms, baseline
  LINQ:                   87,901ms, x 1,22

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:          217,456ms, baseline
  LINQ:                  205,195ms, x 0,94

Array.Where(Method).Select(Method).ToList():
  Foreach loop:           18,976ms, baseline
  LINQ:                   47,032ms, x 2,48

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:          1,334ms, baseline
  LINQ:                    2,314ms, x 1,73

Array.SelectMany(Array).ToList():
  Nested foreach:         16,406ms, baseline
  LINQ:                   52,146ms, x 3,18

Dictionary.Where().Select():
  Foreach loop:           31,401ms, baseline
  LINQ:                   61,925ms, x 1,97

LINQ only: List.Where().Where():
  .Where(a && b):         39,116ms, baseline
  .Where(a).Where(b):     48,132ms, x 1,23
  where a where b:        46,936ms, x 1,20
</pre>

Output for 25M items (100+ MB RAM, so working set doesn't fit into L2):
<pre>
Iteration count: 25000000

Array.Where():
  For loop:              182,161ms, baseline
  Foreach loop:          173,742ms, x 0,95
  Unsafe loop:           149,876ms, x 0,82
  LINQ:                  294,730ms, x 1,62

Array.Where().Select():
  For loop:              120,786ms, baseline
  Foreach loop:          127,528ms, x 1,06
  Unsafe loop:           117,591ms, x 0,97
  LINQ:                  335,451ms, x 2,78

Array.Where().Select().ToList():
  For loop:              247,557ms, baseline
  Foreach loop:          346,269ms, x 1,40
  Unsafe loop:           258,102ms, x 1,04
  LINQ:                  488,278ms, x 1,97

List.Where().Select().ToList():
  For loop:              274,787ms, baseline
  Foreach loop:          361,860ms, x 1,32
  LINQ:                  571,422ms, x 2,08

Sequence.Where().Select().ToList():
  Foreach loop:          468,448ms, baseline
  LINQ:                  777,550ms, x 1,66

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:          835,675ms, baseline
  LINQ:                 1034,647ms, x 1,24

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:         3163,697ms, baseline
  LINQ:                 7359,304ms, x 2,33

Array.Where(Method).Select(Method).ToList():
  Foreach loop:          672,086ms, baseline
  LINQ:                 1189,170ms, x 1,77

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:         30,923ms, baseline
  LINQ:                   52,832ms, x 1,71

Array.SelectMany(Array).ToList():
  Nested foreach:        398,050ms, baseline
  LINQ:                 1326,204ms, x 3,33

Dictionary.Where().Select():
  Foreach loop:          713,222ms, baseline
  LINQ:                 1535,782ms, x 2,15

LINQ only: List.Where().Where():
  .Where(a && b):        881,839ms, baseline
  .Where(a).Where(b):   1137,126ms, x 1,29
  where a where b:      1136,625ms, x 1,29
</pre>

