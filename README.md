LINQ vs Raw Code
================

LINQ to Enumerable performance tests.

Output for 20 items:
<pre>
Array.Where():
  For loop:            0,246ns, baseline                                                                                                       
  Foreach loop:        0,096ns, x 0,39                                                                                                         
  LINQ:                0,588ns, x 2,39                                                                                                         
    Enumerator:    WhereArrayIterator`1                                                                                                        
                                                                                                                                               
Array.Where().Select():                                                                                                                        
  For loop:            0,369ns, baseline                                                                                                       
  Foreach loop:        0,084ns, x 0,23                                                                                                         
  LINQ:                0,769ns, x 2,08                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
Array.Where().Select().ToList():                                                                                                               
  For loop:            0,642ns, baseline                                                                                                       
  Foreach loop:        0,762ns, x 1,19                                                                                                         
  LINQ:                1,705ns, x 2,66                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
List.Where().Select().ToList():                                                                                                                
  For loop:            0,750ns, baseline                                                                                                       
  Foreach loop:        1,231ns, x 1,64                                                                                                         
  LINQ:                2,001ns, x 2,67                                                                                                         
    Enumerator:    WhereSelectListIterator`2                                                                                                   
                                                                                                                                               
Sequence.Where().Select().ToList():                                                                                                            
  Foreach loop:        1,239ns, baseline                                                                                                       
  LINQ:                2,390ns, x 1,93                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Sequence.Where(HashSet.Contains).Select().ToList():                                                                                            
  Foreach loop:        2,444ns, baseline                                                                                                       
  LINQ:                3,533ns, x 1,45                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Array.Select(StringBuilder.Append(int.ToString)):                                                                                              
  Foreach loop:        5,173ns, baseline                                                                                                       
  LINQ:                7,029ns, x 1,36                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2  
</pre>
    
Output for 100 items:
<pre>
Array.Where():
  For loop:            0,989ns, baseline                                                                                                       
  Foreach loop:        0,769ns, x 0,78                                                                                                         
  LINQ:                2,459ns, x 2,49                                                                                                         
    Enumerator:    WhereArrayIterator`1                                                                                                        
                                                                                                                                               
Array.Where().Select():                                                                                                                        
  For loop:            1,070ns, baseline                                                                                                       
  Foreach loop:        0,796ns, x 0,74                                                                                                         
  LINQ:                2,914ns, x 2,72                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
Array.Where().Select().ToList():                                                                                                               
  For loop:            3,191ns, baseline                                                                                                       
  Foreach loop:        2,486ns, x 0,78                                                                                                         
  LINQ:                4,654ns, x 1,46                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
List.Where().Select().ToList():                                                                                                                
  For loop:            3,095ns, baseline                                                                                                       
  Foreach loop:        4,011ns, x 1,30                                                                                                         
  LINQ:                6,505ns, x 2,10                                                                                                         
    Enumerator:    WhereSelectListIterator`2                                                                                                   
                                                                                                                                               
Sequence.Where().Select().ToList():                                                                                                            
  Foreach loop:        4,465ns, baseline                                                                                                       
  LINQ:                7,733ns, x 1,73                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Sequence.Where(HashSet.Contains).Select().ToList():                                                                                            
  Foreach loop:        7,668ns, baseline                                                                                                       
  LINQ:               15,525ns, x 2,02                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Array.Select(StringBuilder.Append(int.ToString)):                                                                                              
  Foreach loop:       31,139ns, baseline                                                                                                       
  LINQ:               27,971ns, x 0,90                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2         
</pre>

Output for 10K items:
<pre>
Array.Where():
  For loop:           95,400ns, baseline                                                                                                       
  Foreach loop:       99,700ns, x 1,05                                                                                                         
  LINQ:                0,231ms, x 2,42                                                                                                         
    Enumerator:    WhereArrayIterator`1                                                                                                        
                                                                                                                                               
Array.Where().Select():                                                                                                                        
  For loop:            0,104ms, baseline                                                                                                       
  Foreach loop:       92,000ns, x 0,89                                                                                                         
  LINQ:                0,268ms, x 2,59                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
Array.Where().Select().ToList():                                                                                                               
  For loop:            0,185ms, baseline                                                                                                       
  Foreach loop:        0,176ms, x 0,95                                                                                                         
  LINQ:                0,365ms, x 1,97                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
List.Where().Select().ToList():                                                                                                                
  For loop:            0,200ms, baseline                                                                                                       
  Foreach loop:        0,268ms, x 1,34                                                                                                         
  LINQ:                0,443ms, x 2,22                                                                                                         
    Enumerator:    WhereSelectListIterator`2                                                                                                   
                                                                                                                                               
Sequence.Where().Select().ToList():                                                                                                            
  Foreach loop:        0,355ms, baseline                                                                                                       
  LINQ:                0,609ms, x 1,72                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Sequence.Where(HashSet.Contains).Select().ToList():                                                                                            
  Foreach loop:        0,814ms, baseline                                                                                                       
  LINQ:                1,035ms, x 1,27                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Array.Select(StringBuilder.Append(int.ToString)):                                                                                              
  Foreach loop:        2,391ms, baseline                                                                                                       
  LINQ:                2,685ms, x 1,12                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2
</pre>

Output for 1M items:
<pre>
Array.Where():
  For loop:            9,875ms, baseline                                                                                                       
  Foreach loop:       11,780ms, x 1,19                                                                                                         
  LINQ:               25,594ms, x 2,59                                                                                                         
    Enumerator:    WhereArrayIterator`1                                                                                                        
                                                                                                                                               
Array.Where().Select():                                                                                                                        
  For loop:           12,038ms, baseline                                                                                                       
  Foreach loop:       10,815ms, x 0,90                                                                                                         
  LINQ:               33,284ms, x 2,76                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
Array.Where().Select().ToList():                                                                                                               
  For loop:           21,142ms, baseline                                                                                                       
  Foreach loop:       22,266ms, x 1,05                                                                                                         
  LINQ:               40,463ms, x 1,91                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
List.Where().Select().ToList():                                                                                                                
  For loop:           24,801ms, baseline                                                                                                       
  Foreach loop:       33,048ms, x 1,33                                                                                                         
  LINQ:               49,843ms, x 2,01                                                                                                         
    Enumerator:    WhereSelectListIterator`2                                                                                                   
                                                                                                                                               
Sequence.Where().Select().ToList():                                                                                                            
  Foreach loop:       44,170ms, baseline                                                                                                       
  LINQ:               68,396ms, x 1,55                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Sequence.Where(HashSet.Contains).Select().ToList():                                                                                            
  Foreach loop:       83,631ms, baseline                                                                                                       
  LINQ:              106,531ms, x 1,27                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Array.Select(StringBuilder.Append(int.ToString)):                                                                                              
  Foreach loop:      219,423ms, baseline                                                                                                       
  LINQ:              224,952ms, x 1,03                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2
</pre>

Output for 50M items (200+MB RAM, so working set doesn't fit into L2):
<pre>
Array.Where():
  For loop:          390,241ms, baseline                                                                                                       
  Foreach loop:      344,634ms, x 0,88                                                                                                         
  LINQ:              582,065ms, x 1,49                                                                                                         
    Enumerator:    WhereArrayIterator`1                                                                                                        
                                                                                                                                               
Array.Where().Select():                                                                                                                        
  For loop:          262,519ms, baseline                                                                                                       
  Foreach loop:      234,266ms, x 0,89                                                                                                         
  LINQ:              674,851ms, x 2,57                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
Array.Where().Select().ToList():                                                                                                               
  For loop:          521,292ms, baseline                                                                                                       
  Foreach loop:      503,221ms, x 0,97                                                                                                         
  LINQ:             2152,902ms, x 4,13                                                                                                         
    Enumerator:    WhereSelectArrayIterator`2                                                                                                  
                                                                                                                                               
List.Where().Select().ToList():                                                                                                                
  For loop:         1168,731ms, baseline                                                                                                       
  Foreach loop:     1552,632ms, x 1,33                                                                                                         
  LINQ:             2523,515ms, x 2,16                                                                                                         
    Enumerator:    WhereSelectListIterator`2                                                                                                   
                                                                                                                                               
Sequence.Where().Select().ToList():                                                                                                            
  Foreach loop:     2047,536ms, baseline                                                                                                       
  LINQ:             3475,886ms, x 1,70                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Sequence.Where(HashSet.Contains).Select().ToList():                                                                                            
  Foreach loop:     4584,820ms, baseline                                                                                                       
  LINQ:             5792,739ms, x 1,26                                                                                                         
    Enumerator:    WhereSelectEnumerableIterator`2                                                                                             
                                                                                                                                               
Array.Select(StringBuilder.Append(int.ToString)):                                                                                              
  Foreach loop:     14102,777ms, baseline                                                                                                      
  LINQ:             15253,793ms, x 1,08                                                                                                        
    Enumerator:    WhereSelectArrayIterator`2  
</pre>
