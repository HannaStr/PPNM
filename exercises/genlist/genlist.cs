public class genlist<T>{
	public T[] data;
	public int size => data.Length;
	public int size_double=0, capacity=8;
	public T this[int i] => data[i];
	public genlist(){ data = new T[0]; }
	
	public void add(T item){
		T[] newdata = new T[size+1];
		System.Array.Copy(data,newdata,size);
		newdata[size]=item;
		data=newdata;
	}
/*
	public void remove(int i){
		T[] newdata = new T[size-1];
		for(int j = 0; j<size; j++){
			if(j<i) {newdata[j] = data[j];}
			if(j>i) {newdata[j-1] = data[j];}
		}
		data = newdata;
	}
*//*	
	Commented out for ode exercise
	public genlist(){data = new T[capacity];}
	public void add_double(T item){ /* add item to list *//*
		if(size_double==capacity){
			T[] newdata = new T[capacity*=2];
			for(int k = 0; k < size_double; k++){
				newdata[k] = data[k];
				data=newdata;
			}
			}
		data[size_double]=item;
		size_double++;
	}
	*/
}
