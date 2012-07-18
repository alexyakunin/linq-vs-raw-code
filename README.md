LINQ to Objects vs raw code performance
================

A set of tests comparing performance of LINQ to Objects and raw code.

The same computations are performed using LINQ to Objects, for/foreach loops 
and loops with unsafe pointers (when possible).

Output for 20 items:
<pre>
Iteration count: 20

Array.Where():
  For loop:           0,092ns, baseline
  Foreach loop:       0,250ns, x 2,72
  Unsafe loop:        0,080ns, x 0,87
  LINQ:               0,723ns, x 7,86 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:           0,269ns, baseline
  Foreach loop:       0,076ns, x 0,28
  Unsafe loop:        0,300ns, x 1,12
  LINQ:               0,935ns, x 3,48 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:           0,727ns, baseline
  Foreach loop:       0,793ns, x 1,09
  Unsafe loop:        0,708ns, x 0,97
  LINQ:               1,736ns, x 2,39 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:           0,816ns, baseline
  Foreach loop:       1,054ns, x 1,29
  LINQ:               1,905ns, x 2,33 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:       1,204ns, baseline
  LINQ:               1,578ns, x 1,31 (WhereSelectArrayIterator`2)

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       1,074ns, baseline
  LINQ:               1,524ns, x 1,42 (WhereSelectArrayIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:       6,163ns, baseline
  LINQ:               6,894ns, x 1,12 (WhereSelectArrayIterator`2)

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       1,085ns, baseline
  LINQ:               1,951ns, x 1,80 (WhereSelectArrayIterator`2)

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     0,138ns, baseline
  LINQ:               2,136ns, x15,48 (WhereArrayIterator`1)

Array.SelectMany(Array).ToList():
  Nested foreach:     0,958ns, baseline
  LINQ:               2,590ns, x 2,70 (<SelectManyIterator>d__14`2)

Dictionary.Where().Select():
  Foreach loop:       0,500ns, baseline
  LINQ:               1,747ns, x 3,49 (WhereSelectEnumerableIterator`2)

LINQ only: List.Where().Where():
  .Where(a && b):     0,900ns, x 1,80 (WhereListIterator`1)
  .Where(a).Where(b): 1,251ns, x 2,50 (WhereListIterator`1)
  where a where b:    1,339ns, x 2,68 (WhereListIterator`1)
</pre>

Output for 100 items:
<pre>
Iteration count: 100

Array.Where():
  For loop:           0,808ns, baseline
  Foreach loop:       1,208ns, x 1,50
  Unsafe loop:        0,781ns, x 0,97
  LINQ:               3,129ns, x 3,87

Array.Where().Select():
  For loop:           0,800ns, baseline
  Foreach loop:       1,278ns, x 1,60
  Unsafe loop:        0,800ns, x 1,00
  LINQ:               3,660ns, x 4,58

Array.Where().Select().ToList():
  For loop:           3,152ns, baseline
  Foreach loop:       2,906ns, x 0,92
  Unsafe loop:        2,898ns, x 0,92
  LINQ:               5,389ns, x 1,71

List.Where().Select().ToList():
  For loop:           3,106ns, baseline
  Foreach loop:       3,922ns, x 1,26
  LINQ:               6,555ns, x 2,11

Sequence.Where().Select().ToList():
  Foreach loop:       4,661ns, baseline
  LINQ:               5,601ns, x 1,20

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       7,063ns, baseline
  LINQ:               8,438ns, x 1,19

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:      27,563ns, baseline
  LINQ:              32,082ns, x 1,16

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       3,776ns, baseline
  LINQ:               6,140ns, x 1,63

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     0,400ns, baseline
  LINQ:               2,359ns, x 5,90

Array.SelectMany(Array).ToList():
  Nested foreach:     2,521ns, baseline
  LINQ:               7,441ns, x 2,95

Dictionary.Where().Select():
  Foreach loop:       2,983ns, baseline
  LINQ:               5,955ns, x 2,00

LINQ only: List.Where().Where():
  .Where(a && b):     4,596ns, x 1,54
  .Where(a).Where(b): 5,200ns, x 1,74
  where a where b:    5,200ns, x 1,74
</pre>

Output for 10K items:
<pre>
Iteration count: 10000

Array.Where():
  For loop:           0,120ms, baseline
  Foreach loop:       0,118ms, x 0,98
  Unsafe loop:        0,112ms, x 0,93
  LINQ:               0,234ms, x 1,94

Array.Where().Select():
  For loop:          96,200ns, baseline
  Foreach loop:       0,124ms, x 1,29
  Unsafe loop:        0,112ms, x 1,16
  LINQ:               0,325ms, x 3,38

Array.Where().Select().ToList():
  For loop:           0,214ms, baseline
  Foreach loop:       0,211ms, x 0,98
  Unsafe loop:        0,178ms, x 0,83
  LINQ:               0,370ms, x 1,73

List.Where().Select().ToList():
  For loop:           0,239ms, baseline
  Foreach loop:       0,324ms, x 1,35
  LINQ:               0,433ms, x 1,81

Sequence.Where().Select().ToList():
  Foreach loop:       0,306ms, baseline
  LINQ:               0,375ms, x 1,23

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       0,627ms, baseline
  LINQ:               0,785ms, x 1,25

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:       2,771ms, baseline
  LINQ:               2,772ms, x 1,00

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       0,266ms, baseline
  LINQ:               0,410ms, x 1,54

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:    15,113ns, baseline
  LINQ:              25,203ns, x 1,67

Array.SelectMany(Array).ToList():
  Nested foreach:     0,154ms, baseline
  LINQ:               0,557ms, x 3,62

Dictionary.Where().Select():
  Foreach loop:       0,303ms, baseline
  LINQ:               0,693ms, x 2,28

LINQ only: List.Where().Where():
  .Where(a && b):     0,311ms, x 1,03
  .Where(a).Where(b): 0,403ms, x 1,33
  where a where b:    0,403ms, x 1,33
</pre>

Output for 1M items:
<pre>
Iteration count: 1000000

Array.Where():
  For loop:          12,067ms, baseline
  Foreach loop:      10,901ms, x 0,90
  Unsafe loop:       10,319ms, x 0,86
  LINQ:              28,656ms, x 2,37

Array.Where().Select():
  For loop:          11,494ms, baseline
  Foreach loop:      12,750ms, x 1,11
  Unsafe loop:       11,283ms, x 0,98
  LINQ:              32,210ms, x 2,80

Array.Where().Select().ToList():
  For loop:          22,234ms, baseline
  Foreach loop:      21,921ms, x 0,99
  Unsafe loop:       20,007ms, x 0,90
  LINQ:              45,069ms, x 2,03

List.Where().Select().ToList():
  For loop:          24,754ms, baseline
  Foreach loop:      33,308ms, x 1,35
  LINQ:              48,543ms, x 1,96

Sequence.Where().Select().ToList():
  Foreach loop:      36,849ms, baseline
  LINQ:              44,502ms, x 1,21

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:      69,277ms, baseline
  LINQ:              85,202ms, x 1,23

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:     200,799ms, baseline
  LINQ:             183,346ms, x 0,91

Array.Where(Method).Select(Method).ToList():
  Foreach loop:      17,151ms, baseline
  LINQ:              46,926ms, x 2,74

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     1,178ms, baseline
  LINQ:               2,158ms, x 1,83

Array.SelectMany(Array).ToList():
  Nested foreach:    16,527ms, baseline
  LINQ:              52,149ms, x 3,16

Dictionary.Where().Select():
  Foreach loop:      30,881ms, baseline
  LINQ:              63,435ms, x 2,05

LINQ only: List.Where().Where():
  .Where(a && b):     38,244ms, x 1,24
  .Where(a).Where(b): 45,296ms, x 1,47
  where a where b:    49,298ms, x 1,60
</pre>

Output for 25M items (100+ MB RAM, so working set doesn't fit into L2):
<pre>
Iteration count: 25000000

Array.Where():
  For loop:         182,666ms, baseline
  Foreach loop:     173,715ms, x 0,95
  Unsafe loop:      150,063ms, x 0,82
  LINQ:             294,534ms, x 1,61

Array.Where().Select():
  For loop:         121,073ms, baseline
  Foreach loop:     129,798ms, x 1,07
  Unsafe loop:      116,994ms, x 0,97
  LINQ:             335,846ms, x 2,77

Array.Where().Select().ToList():
  For loop:         247,467ms, baseline
  Foreach loop:     244,712ms, x 0,99
  Unsafe loop:      226,315ms, x 0,91
  LINQ:             476,688ms, x 1,93

List.Where().Select().ToList():
  For loop:         275,324ms, baseline
  Foreach loop:     362,865ms, x 1,32
  LINQ:             571,522ms, x 2,08

Sequence.Where().Select().ToList():
  Foreach loop:     399,250ms, baseline
  LINQ:             477,763ms, x 1,20

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:     811,892ms, baseline
  LINQ:             995,548ms, x 1,23

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:    3146,245ms, baseline
  LINQ:            3482,612ms, x 1,11

Array.Where(Method).Select(Method).ToList():
  Foreach loop:     663,216ms, baseline
  LINQ:            1184,619ms, x 1,79

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:    30,512ms, baseline
  LINQ:              52,683ms, x 1,73

Array.SelectMany(Array).ToList():
  Nested foreach:   398,517ms, baseline
  LINQ:            1324,179ms, x 3,32

Dictionary.Where().Select():
  Foreach loop:     710,682ms, baseline
  LINQ:            1601,456ms, x 2,25

LINQ only: List.Where().Where():
  .Where(a && b):      866,343ms, x 1,22
  .Where(a).Where(b): 1121,336ms, x 1,58
  where a where b:    1120,927ms, x 1,58
</pre>
