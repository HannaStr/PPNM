using System;
using static System.Math;


//from homework description
public class ann{
    int n;                                          //number of hidden neurons
    Func<double,double> f = x => x*Exp(-x*x);       //activation function
    vector p;                                       //network parameters

    public ann (int n){                                    //constructor
        this.n = n;
        this.p = new vector (3*n);  //ai, bi & wi for each hidden neuron
    }

    public ann (vector p){
        this.n = p.size/3;
        this.p = p;
    }

    public double response(double x){                     //return the response of the network to the input signal
        double F_p = 0;
        
        for (int i = 0; i < n; i++){
            double ai = p[3 * i    ];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];

            F_p += f((x-ai)/bi)*wi;                      //summation neuron: sums the outputs of the hidden neurons and sends the result to the output
        }
        return F_p;
    }   

    public vector train(vector x, vector y){                 //train the network to interpolate the given table {x,y}
        for(int i=0; i<n; i++){
            p[i] = 1.0;
            p[i+n] = 1.0;
            p[i+2*n] = x[0] + ( x[x.size-1] - x[0] )*i/(n-1);
        };
        Func<vector, double> cost_f = (v) =>
            {
                ann ann_v = new ann(v);
                double cost = 0;
                double N = x.size;
                for (int k = 0; k < N; k++){
                    double predicted = ann_v.response(x[k]);
                    double actual = y[k];
                    cost += Pow(predicted - actual, 2);
                }

                return cost/x.size;
            };
        var (p_trained, steps) = multimin.qnewton(cost_f, p);
        p = p_trained;
        return p;
    }


}
