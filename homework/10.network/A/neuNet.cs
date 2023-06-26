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

    public double response(double x){                     //return the response of the network to the input signal
        double result = 0;
        
        for (int i = 0; i < n; i++){
            double ai = p[3 * i    ];
            double bi = p[3 * i + 1];
            double wi = p[3 * i + 2];

            result += f((x-ai)/bi)*wi;
        }

        return result;
    }

    public vector train(vector x, vector y){                 //train the network to interpolate the given table {x,y}
        Func<vector, double> cost_f = (p) =>
            {
                double cost = 0;

                for (int k = 0; k < x.size; k++){
                    double predicted = response(x[k]);
                    double actual = y[k];
                    cost += Pow(predicted - actual, 2);
                }

                return cost;
            };
        var (p_trained, steps) = multimin.qnewton(cost_f, p);
        p = p_trained;
        //return p;
        //p = multimin.qnewton(cost_f,p);
        return p;
    }

}