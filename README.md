LINQ vs Raw Code
================

LINQ to Enumerable performance tests.

Example output:
<pre>
Iteration count: 1000000
Warmup...
  Done.

Array.Where():
  For loop:         12,18ms, baseline
  Foreach loop:     13,00ms, x 1,07
  LINQ:             30,09ms, x 2,47
    Enumerator:    WhereArrayIterator`1

Array.Where().Select():
  For loop:         15,78ms, baseline
  Foreach loop:     15,78ms, x 1,00
  LINQ:             32,27ms, x 2,04
    Enumerator:    WhereSelectArrayIterator`2

Array.Where().Select().ToList():
  For loop:         25,73ms, baseline
  Foreach loop:     19,46ms, x 0,76
  LINQ:             41,72ms, x 1,62
    Enumerator:    WhereSelectArrayIterator`2

List.Where().Select().ToList():
  For loop:         22,67ms, baseline
  Foreach loop:     30,94ms, x 1,36
  LINQ:             46,97ms, x 2,07
    Enumerator:    WhereSelectListIterator`2

Sequence.Where().Select().ToList():
  Foreach loop:     39,14ms, baseline
  LINQ:             63,53ms, x 1,62
    Enumerator:    WhereSelectEnumerableIterator`2

Sequence.Where(HashSet.Contains).Select().ToList():
  Foreach loop:     87,82ms, baseline
  LINQ:            102,69ms, x 1,17
    Enumerator:    WhereSelectEnumerableIterator`2
</pre>