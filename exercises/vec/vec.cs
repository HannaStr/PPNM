using static System.Console;
using static System.Math;
public class vec{
	public double x,y,z;
	public vec (double a,double b,double c){x=a;y=b;z=c;}
	public vec (){ x=y=z=0;}
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}");}
	public static vec operator+(vec u, vec v){/* u+v */
		return new vec(u.x+v.x, u.y+v.y, u.z+v.z);
			}
	
	public static vec operator-(vec u, vec v){/* u+v */
                return new vec(u.x-v.x, u.y-v.y, u.z-v.z);
                        }

	public static vec operator-(vec v){/* -u  */
                return new vec(-v.x, -v.y, -v.z);
                        }

	public static vec operator*(vec u, double c){ /* u*c */
		return new vec(u.x*c, u.y*c, u.z*c);
                        }

	public static vec operator*(double c, vec u){ /* c*c */
                return u*c;
                        }

	public static double operator% (vec u, vec v){ /*u%v = dotproduct */
		return u.x*v.x + u.y*v.y + u.z*v.z;
			}
	public double dot (vec other){ return this%other; }

	public vec cross (vec v){
		return new vec (this.y*v.z - this.z*v.y,
                                this.z*v.x - this.x*v.z,
                                this.x*v.y - this.y*v.x);
			}
	public  double norm (){
		return Sqrt( this.x*this.x + this.y*this.y + this.z*this.z );
			}


	static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
                if(Abs(a-b)<acc)return true;
                if(Abs(a-b)/(Abs(a)+Abs(b))<eps)return true;
                return false;
                }

	public bool approx(vec other){
		if(!approx(this.x,other.x)){return false;}
		if(!approx(this.y,other.y)){return false;}
		if(!approx(this.z,other.z)){return false;}
		return true;
		}
	public static bool approx(vec u, vec v){return u.approx(v);}
}