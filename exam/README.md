======================================================================
EXAM QUESTION 10
----------------------------------------------------------------------
Adaptive recursive integrator with subdivision into three subintervals
======================================================================

Implement a (one-dimensional) adaptive recursive integrator which at each iteration subdivides the interval not into two, but into three sub-intervals. Reuse points. 

Compare its effectiveness with the adaptive integrator from your homework.

For example, a rule like this (check that the numbers are correct):

    xi={1/6,3/6,5/6}    reusable points for division by 3;
    wi={3/8,2/8,3/8}    trapezium rule;
    vi={1/3,1/3,1/3}    rectangle rule;

    
Extra: try quadratic vs trapezium.