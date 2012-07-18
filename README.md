LINQ vs Raw Code
================

LINQ to Enumerable performance tests.

Example output (100 000 loop cycles):
<pre>
Array.Where():                                                                                                                                 
  For loop:          1,73ms, baseline                                                                                                          
  Foreach loop:      1,39ms, x 0,80                                                                                                            
  LINQ:              3,71ms, x 2,14                                                                                                            
    Enumerator:    WhereArrayIterator`1                                                                                                        
                                                                                                                                               
Array.Where().Select():                                                                                                                        
  For loop:          1,71ms, baseline                                                                                                          
  Foreach loop:      1,58ms, x 0,93                                                                                                            
  LINQ:              3,13ms, x 1,83                                                                                                            
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
Array.Where().Select().ToList():                                                                                                               
  For loop:          3,27ms, baseline                                                                                                          
  Foreach loop:      2,11ms, x 0,65                                                                                                            
  LINQ:              5,93ms, x 1,82                                                                                                            
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
List.Where().Select().ToList():                                                                                                                
  For loop:          2,63ms, baseline                                                                                                          
  Foreach loop:      3,34ms, x 1,27                                                                                                            
  LINQ:              5,73ms, x 2,18                                                                                                            
    Enumerator:    WhereSelectListIterator`2                                                                                                   
                                                                                                                                               
Sequence.Where().Select().ToList():                                                                                                            
  Foreach loop:      6,22ms, baseline                                                                                                          
  LINQ:              7,23ms, x 1,16                                                                                                            
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Sequence.Where(HashSet.Contains).Select().ToList():                                                                                            
  Foreach loop:     11,51ms, baseline                                                                                                          
  LINQ:             13,25ms, x 1,15                                                                                                            
    Enumerator:    WhereSelectEnumerableIterator`2 
</pre>
    
Example output (1 000 000 loop cycles):
<pre>
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