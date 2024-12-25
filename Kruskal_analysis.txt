1-Initialization of Sets:
_The Make-Set(v) operation is called once for each vertex v.
_Time complexity:O(V).

2-Sorting the Edges:
_The edges E are sorted by weight.
_Time complexity: O(ElogE).  //ElogE can also be written as O(ElogV), since E≤V^2.

3-Iterating Over Edges:
_each edge (u,v), Find-Set(u) and Find-Set(v) are performed to check if u and v belong to the same set.

_Using the Union-Find data structure with path compression and union by rank, the amortized time complexity for Find-Set and Union is O(α(V)), where α is the inverse Ackermann function (very slow-growing, practically constant).Since we process each edge in O(α(V)) time:
_Time complexity: O(E⋅α(V)).


Overall Time Complexity
Adding up all components: O(V)+O(ElogE)+O(E⋅α(V))
Dominant term: O(ElogE).

Therefore, the overall time complexity is: O(ElogE) or equivalently O(ElogV)