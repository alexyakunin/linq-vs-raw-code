LINQ vs Raw Code
================

LINQ to Enumerable performance tests.

Output for 20 items:
<pre>
Iteration count: 20

Array.Where():
  For loop:           0,265ns, baseline
  Foreach loop:       0,096ns, x 0,36
  Unsafe loop:        0,230ns, x 0,87
  LINQ:               0,635ns, x 2,40

Array.Where().Select():
  For loop:           0,069ns, baseline
  Foreach loop:       0,242ns, x 3,51
  Unsafe loop:        0,084ns, x 1,22
  LINQ:               0,877ns, x12,71

Array.Where().Select().ToList():
  For loop:           0,712ns, baseline
  Foreach loop:       0,793ns, x 1,11
  Unsafe loop:        0,677ns, x 0,95
  LINQ:               1,817ns, x 2,55

List.Where().Select().ToList():
  For loop:           0,997ns, baseline
  Foreach loop:       1,201ns, x 1,20
  LINQ:               1,967ns, x 1,97

Sequence.Where().Select().ToList():
  Foreach loop:       1,216ns, baseline
  LINQ:               1,532ns, x 1,26

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       1,216ns, baseline
  LINQ:               1,612ns, x 1,33

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:       6,086ns, baseline
  LINQ:               5,527ns, x 0,91

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       1,085ns, baseline
  LINQ:               1,967ns, x 1,81

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     0,115ns, baseline
  LINQ:               2,159ns, x18,77

Array.SelectMany(Array).ToList():
  Nested foreach:     0,962ns, baseline
  LINQ:               2,055ns, x 2,14
</pre>

Output for 100 items:
<pre>
Iteration count: 100

Array.Where():
  For loop:           1,039ns, baseline
  Foreach loop:       1,281ns, x 1,23
  Unsafe loop:        1,201ns, x 1,16
  LINQ:               2,921ns, x 2,81

Array.Where().Select():
  For loop:           0,904ns, baseline
  Foreach loop:       1,077ns, x 1,19
  Unsafe loop:        0,885ns, x 0,98
  LINQ:               3,672ns, x 4,06

Array.Where().Select().ToList():
  For loop:           3,071ns, baseline
  Foreach loop:       2,944ns, x 0,96
  Unsafe loop:        2,806ns, x 0,91
  LINQ:               5,554ns, x 1,81

List.Where().Select().ToList():
  For loop:           3,299ns, baseline
  Foreach loop:       4,095ns, x 1,24
  LINQ:               5,589ns, x 1,69

Sequence.Where().Select().ToList():
  Foreach loop:       4,754ns, baseline
  LINQ:               5,805ns, x 1,22

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       5,678ns, baseline
  LINQ:               8,542ns, x 1,50

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:      32,498ns, baseline
  LINQ:              31,189ns, x 0,96

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       3,722ns, baseline
  LINQ:               6,155ns, x 1,65

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     0,377ns, baseline
  LINQ:               2,440ns, x 6,47

Array.SelectMany(Array).ToList():
  Nested foreach:     2,675ns, baseline
  LINQ:               7,302ns, x 2,73
</pre>

Output for 10K items:
<pre>
Iteration count: 10000

Array.Where():
  For loop:           0,112ms, baseline
  Foreach loop:       0,119ms, x 1,06
  Unsafe loop:        0,115ms, x 1,03
  LINQ:               0,283ms, x 2,51

Array.Where().Select():
  For loop:          98,900ns, baseline
  Foreach loop:       0,107ms, x 1,08
  Unsafe loop:       95,400ns, x 0,96
  LINQ:               0,269ms, x 2,72

Array.Where().Select().ToList():
  For loop:           0,179ms, baseline
  Foreach loop:       0,174ms, x 0,97
  Unsafe loop:        0,186ms, x 1,04
  LINQ:               0,439ms, x 2,45

List.Where().Select().ToList():
  For loop:           0,198ms, baseline
  Foreach loop:       0,267ms, x 1,35
  LINQ:               0,536ms, x 2,71

Sequence.Where().Select().ToList():
  Foreach loop:       0,359ms, baseline
  LINQ:               0,368ms, x 1,03

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:       0,647ms, baseline
  LINQ:               0,806ms, x 1,25

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:       2,886ms, baseline
  LINQ:               2,834ms, x 0,98

Array.Where(Method).Select(Method).ToList():
  Foreach loop:       0,229ms, baseline
  LINQ:               0,508ms, x 2,22

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:    15,598ns, baseline
  LINQ:              26,423ns, x 1,69

Array.SelectMany(Array).ToList():
  Nested foreach:     0,140ms, baseline
  LINQ:               0,460ms, x 3,28
</pre>

Output for 1M items:
<pre>
Iteration count: 1000000

Array.Where():
  For loop:          10,937ms, baseline
  Foreach loop:      11,977ms, x 1,10
  Unsafe loop:       11,483ms, x 1,05
  LINQ:              29,113ms, x 2,66

Array.Where().Select():
  For loop:          11,068ms, baseline
  Foreach loop:      12,251ms, x 1,11
  Unsafe loop:       11,243ms, x 1,02
  LINQ:              30,652ms, x 2,77

Array.Where().Select().ToList():
  For loop:          23,177ms, baseline
  Foreach loop:      22,231ms, x 0,96
  Unsafe loop:       19,717ms, x 0,85
  LINQ:              42,373ms, x 1,83

List.Where().Select().ToList():
  For loop:          25,652ms, baseline
  Foreach loop:      33,857ms, x 1,32
  LINQ:              49,754ms, x 1,94

Sequence.Where().Select().ToList():
  Foreach loop:      37,353ms, baseline
  LINQ:              46,364ms, x 1,24

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:      74,042ms, baseline
  LINQ:              83,540ms, x 1,13

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:     223,701ms, baseline
  LINQ:             213,429ms, x 0,95

Array.Where(Method).Select(Method).ToList():
  Foreach loop:      21,793ms, baseline
  LINQ:              55,992ms, x 2,57

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:     1,352ms, baseline
  LINQ:               2,337ms, x 1,73

Array.SelectMany(Array).ToList():
  Nested foreach:    21,347ms, baseline
  LINQ:              54,527ms, x 2,55
</pre>

Output for 50M items (200+ MB RAM, so working set doesn't fit into L2):
<pre>
Iteration count: 50000000

Array.Where():
  For loop:         304,532ms, baseline
  Foreach loop:     254,501ms, x 0,84
  Unsafe loop:      248,859ms, x 0,82
  LINQ:             594,770ms, x 1,95

Array.Where().Select():
  For loop:         237,000ms, baseline
  Foreach loop:     259,270ms, x 1,09
  Unsafe loop:      232,964ms, x 0,98
  LINQ:             742,167ms, x 3,13

Array.Where().Select().ToList():
  For loop:         521,007ms, baseline
  Foreach loop:     506,575ms, x 0,97
  Unsafe loop:      456,465ms, x 0,88
  LINQ:             974,755ms, x 1,87

List.Where().Select().ToList():
  For loop:         566,526ms, baseline
  Foreach loop:     741,751ms, x 1,31
  LINQ:            1167,201ms, x 2,06

Sequence.Where().Select().ToList():
  Foreach loop:    1728,183ms, baseline
  LINQ:            2082,702ms, x 1,21

Array.Where(HashSet.Contains).Select().ToList():
  Foreach loop:    3734,223ms, baseline
  LINQ:            4477,445ms, x 1,20

Array.Select(StringBuilder.Append(int.ToString)):
  Foreach loop:   13803,435ms, baseline
  LINQ:           14977,691ms, x 1,09

Array.Where(Method).Select(Method).ToList():
  Foreach loop:    1402,488ms, baseline
  LINQ:            2435,355ms, x 1,74

Array.Where(v => Array.Contains(v + 1)).ToList():
  Nested foreach:    62,424ms, baseline
  LINQ:             108,131ms, x 1,73

Array.SelectMany(Array).ToList():
  Nested foreach:   826,061ms, baseline
  LINQ:            2724,124ms, x 3,30
</pre>

