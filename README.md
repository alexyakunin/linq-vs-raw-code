LINQ vs Raw Code
================

LINQ to Enumerable performance tests.

Output for 20 items:
<pre>
Iteration count: 20

Array.Where():
  For loop:            0,084ns, baseline
  Foreach loop:        0,250ns, x 2,98
  LINQ:                0,742ns, x 8,83 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:            0,234ns, baseline
  Foreach loop:        0,088ns, x 0,38
  LINQ:                0,958ns, x 4,09 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:            0,485ns, baseline
  Foreach loop:        0,442ns, x 0,91
  LINQ:                1,520ns, x 3,13 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:            0,546ns, baseline
  Foreach loop:        0,939ns, x 1,72
  LINQ:                1,501ns, x 2,75 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:        1,254ns, baseline
  LINQ:                2,328ns, x 1,86 (WhereSelectEnumerableIterator`2)

Sequence.Where(HashSet.Contains).Select().ToList():
  Foreach loop:        2,521ns, baseline
  LINQ:                3,183ns, x 1,26 (WhereSelectEnumerableIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:        5,959ns, baseline
  LINQ:                6,767ns, x 1,14 (WhereSelectArrayIterator`2)
</pre>

Output for 100 items:
<pre>
Iteration count: 100

Array.Where():
  For loop:            0,958ns, baseline
  Foreach loop:        1,031ns, x 1,08
  LINQ:                3,129ns, x 3,27 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:            1,151ns, baseline
  Foreach loop:        0,958ns, x 0,83
  LINQ:                3,591ns, x 3,12 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:            3,087ns, baseline
  Foreach loop:        3,118ns, x 1,01
  LINQ:                4,800ns, x 1,55 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:            2,952ns, baseline
  Foreach loop:        3,356ns, x 1,14
  LINQ:                6,401ns, x 2,17 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:        5,439ns, baseline
  LINQ:                9,543ns, x 1,75 (WhereSelectEnumerableIterator`2)

Sequence.Where(HashSet.Contains).Select().ToList():
  Foreach loop:        9,608ns, baseline
  LINQ:               14,562ns, x 1,52 (WhereSelectEnumerableIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:       29,680ns, baseline
  LINQ:               33,275ns, x 1,12 (WhereSelectArrayIterator`2)
</pre>

Output for 10K items:
<pre>
Iteration count: 10000

Array.Where():
  For loop:           91,600ns, baseline
  Foreach loop:       97,000ns, x 1,06
  LINQ:                0,286ms, x 3,12 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:            0,124ms, baseline
  Foreach loop:       91,600ns, x 0,74
  LINQ:                0,268ms, x 2,16 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:            0,215ms, baseline
  Foreach loop:        0,176ms, x 0,82
  LINQ:                0,374ms, x 1,74 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:            0,197ms, baseline
  Foreach loop:        0,265ms, x 1,34
  LINQ:                0,436ms, x 2,21 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:        0,356ms, baseline
  LINQ:                0,656ms, x 1,84 (WhereSelectEnumerableIterator`2)

Sequence.Where(HashSet.Contains).Select().ToList():
  Foreach loop:        0,800ms, baseline
  LINQ:                1,102ms, x 1,38 (WhereSelectEnumerableIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:        2,805ms, baseline
  LINQ:                2,728ms, x 0,97 (WhereSelectArrayIterator`2)
</pre>

Output for 1M items:
<pre>
Iteration count: 1000000

Array.Where():
  For loop:           10,154ms, baseline
  Foreach loop:       10,509ms, x 1,03
  LINQ:               28,903ms, x 2,85 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:           12,724ms, baseline
  Foreach loop:       11,210ms, x 0,88
  LINQ:               32,702ms, x 2,57 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:           20,386ms, baseline
  Foreach loop:       21,817ms, x 1,07
  LINQ:               40,314ms, x 1,98 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:           24,851ms, baseline
  Foreach loop:       33,270ms, x 1,34
  LINQ:               54,097ms, x 2,18 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:       44,288ms, baseline
  LINQ:               69,834ms, x 1,58 (WhereSelectEnumerableIterator`2)

Sequence.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       90,389ms, baseline
  LINQ:              113,597ms, x 1,26 (WhereSelectEnumerableIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:      217,628ms, baseline
  LINQ:              208,195ms, x 0,96 (WhereSelectArrayIterator`2)
</pre>

Output for 50M items (200+ MB RAM, so working set doesn't fit into L2):
<pre>
Iteration count: 50000000

Array.Where():
  For loop:          233,423ms, baseline
  Foreach loop:      247,751ms, x 1,06
  LINQ:              595,641ms, x 2,55 (WhereArrayIterator`1)

Array.Where().Select():
  For loop:          260,201ms, baseline
  Foreach loop:      233,213ms, x 0,90
  LINQ:              671,803ms, x 2,58 (WhereSelectArrayIterator`2)

Array.Where().Select().ToList():
  For loop:          518,380ms, baseline
  Foreach loop:      499,462ms, x 0,96
  LINQ:              985,381ms, x 1,90 (WhereSelectArrayIterator`2)

List.Where().Select().ToList():
  For loop:          557,315ms, baseline
  Foreach loop:      731,668ms, x 1,31
  LINQ:             2479,229ms, x 4,45 (WhereSelectListIterator`2)

Sequence.Where().Select().ToList():
  Foreach loop:     2023,822ms, baseline
  LINQ:             3530,739ms, x 1,74 (WhereSelectEnumerableIterator`2)

Sequence.Where(HashSet.Contains).Select().ToList():
  Foreach loop:     4567,696ms, baseline
  LINQ:             5736,907ms, x 1,26 (WhereSelectEnumerableIterator`2)

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:     13369,015ms, baseline
  LINQ:             14848,029ms, x 1,11 (WhereSelectArrayIterator`2)
</pre>
