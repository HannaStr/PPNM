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


======================================================================
WHAT I'VE DONE
----------------------------------------------------------------------
My algorithm is based on the algorithm from the Homework about integrals. There we used subdivision of the interval into two.
I've modified it to have it divide into three subintervals instead. 

I used the values for reusable points and the rules (xi, wi, vi) as given in the question.
I checked that they are correct using the equations from the Book e.g. eqn(15) {from the chapter on integrals}.


I've tested my implementation on the same functions as in the homework:
(taking integrals from 0 to 1 in respect of x)
    1) sqrt(x)
    2) 1/sqrt(x)
    3) 4*sqrt(1-x^2)
    4) ln(x)/sqrt(x)

I've encountered some problems for functions 2 and 4 where the algorithm didn't want to compute.
However, I realised that it is due to the nature of the function and the limits of integration. 
The algorithm was evaluating the function f(0) for which we get:
    2) 1/0 which of course is not allowed
    4) ln(0)/0 which once again is not allowed

I've solved that problem by replacing the limits of those 2 functions with a very small number (approx. 0) which is not 0.
This has solved the problem and the algorithm is now working as it should.

The modified algorithm for calculating the integral is (same as the old one) reusing some points. 
In the subdivision into 2 intervals we had points (f1, f2, f3, f4). 
Then points (f1, f2) were reused in Interval 1 and renamed as (f2, f3).
Similarly, points (f3, f4) were reused in Interval 2 and renamed as (f2, f3).

In the case of the subdivision into 3 intervals I instead used three points (f1, f2, f3).
They were then being reused one in each interval and renamed as f2 in their respective interval.

Below is an attempt at a visual representation of the subdivision into 3 intervals and the renaming of the reused points.

    X - f1 - o - f2 - o - f3 - X
    |   :    |   :    |   :    |
    |   :    |   :    X - f2 - X
    |   :    X - f2 - X
    X - f2 - X

I have also plotted the error function (erf.svg and erf_zoom.svg) to compare the intgration using division into 2 and 3 subintervals with each other and with the real values.
The fit for both seems to be good and any differences aren't very noticible. 

The erf_zoom.svg is the same plot as erf.svg but with the range of z chosen as [-0.5:1.5] for the purpose of investigating the smoothness of the error function around z = +/- 1. 


======================================================================
CONCLUSIONS
----------------------------------------------------------------------
The algorithm with division into 3 subintervals seems to perform better for larger values of delta and epsilon. 
The results for both algorithms (lets call the division into 2 subintervals "sub_2" and into 3 subintervals "sub_3") gives results that are close to the expected values.
However, when choosing large delta and epsilon sub_3 gives more accurate results. 
For smaller values of delta and epsilon it changes and the sub_2 seems to be giving results closer to the true value.
However, the differences are very small. Most of the time the errors on both are within the same order of magnitude.

It could be that the effectivness of my adaptive integrator depends on the specific functions in question. 
Potentially, there could be a recursive error within the code that accumulates over time, however after investigating it closely I could's find it.

The argument for the differences in accuracy being due to the nature of the functions (and which - sub_2 or sub_3 matches them better) whould be that when taken larger delta and epsilon
function 4) is the only one which has higher accuracy using sub_2 than sub_3 and for smaller delta and epsilon the accuracy of function 1) is higher with sub_3 whereas for all the other
functions the results are better with sub_2.

From the plots it's also visible that the problem with smoothness of the function around z = +/- 1 which was notcible in the Homework is made better with sub_3.
When using the large values of delta & epsilon (e.g. 0.01) the error function of sub_3 is visibly smoother (especially visible on erf_zoom.svg).


======================================================================
FILES
----------------------------------------------------------------------
README.md - you are here :)
Makefile 
main 
Out - results printed out for sub_2 and sub_3 for the chosen functions
ari - adaptive recursive integrator
erf - error function (data, operation and plots)
erf_zoom - error function plotted for a smaller range of z
erf_wiki - data for the error function from wikipedia (true values)
dir test - past attempts before getting it right (can be ignored)
======================================================================