﻿using System.Linq;
using System.Collections.Generic;
using System;

namespace ReadOnlyList
{
	public class ReadOnlyList<T> where T : class
	{
		private readonly List<T> _items;

		public ReadOnlyList (IEnumerable<T> items)
		{
			_items = items.ToList ();
		}

		public static ReadOnlyList<T> Empty{
			get{
				return new ReadOnlyList<T> (
					new List<T> ());
			}
		}

		public bool IsEmpty
		{
			get{return _items.Count == 0;}
		}

		public T this[int index] 
		{
			get { return _items[index]; }
		}

		public T First
		{
			get { return _items[0]; }
		}

		public T Last
		{
			get { return _items [_items.Count - 1]; }
		}

		public int Count 
		{
			get { return _items.Count; }
		}	

		public ReadOnlyList<T> Take(int numberOfElements)
		{
			if(numberOfElements <= 0){
				return ReadOnlyList<T>.Empty;
			}
			if(numberOfElements >= Count){
				return this;
			}
			var result = new List<T> ();
			for(var position=0; position<numberOfElements; position++){
				result.Add (_items [position]);
			}
			return new ReadOnlyList<T> (result);
		}

		public ReadOnlyList<T> Append(T item){
			_items.Add(item);
			return new ReadOnlyList<T>(_items);
		}

		public ReadOnlyList<T> Where(Func<T, bool> filter)
		{
			var result = new List<T> ();
			foreach(var item in _items){
				if(filter(item)){
					result.Add (item);
				}
			}
			return new ReadOnlyList<T> (result);
		}

		public void  ForEach(Action<T> action)
		{
			foreach(var item in _items)
			{
				action (item);
			}
		}

		public int Sum(Func<T, int> sum)
		{
			var result = 0;
			foreach(var item in _items){
				result = result + sum(item);
			}
			return result;
		}

		public bool Contains(T element){
			foreach(var item in _items){
				if(item == element){
					return true;
				}
			}
			return false;
		}

		public decimal Average(Func<T, int> average)
		{
			var result = 0;
			foreach(var item in _items){
				result = result + average(item);
			}
			return (decimal)result/Count;
		}

		public int Min(Func<T, int> min)
		{
			var result = int.MaxValue;
			foreach(var item in _items){
				if(result > min(item)){
					result = min(item);
				}
			}
			return result;
		}

		public int Max(Func<T, int> max)
		{
			var result = int.MinValue;
			foreach(var item in _items){
				if(result < max(item)){
					result = max(item);
				}
			}
			return result;
		}

		public ReadOnlyList<T> Reverse()
		{
			var result = new List<T>();
			for(var position = Count-1; position>=0; position--){
				result.Add (_items[position]);
			}

			return new ReadOnlyList<T> (result);
		}

		public T SingleOrDefault(Func<T, bool> selection)
		{
			foreach(var item in _items)
			{
				if(selection(item)){
					return item;
				}
			}
			return default(T);
		}

		public bool Any(Func<T, bool> condition)
		{
			foreach(var item in _items)
			{
				if(condition(item)){
					return true;
				}
			}
			return false;
		}

		public bool All(Func<T, bool> condition)
		{
			foreach(var item in _items)
			{
				if(!condition(item)){
					return false;
				}
			}
			return true;
		}

		public ReadOnlyList<T> Pipe(Func<T, T> action)
		{
			var result = new List<T> ();
			foreach(var item in _items)
			{
				result.Add(action(item));
			}
			return new ReadOnlyList<T>(result);
		}

		public ReadOnlyList<T> Zip(ReadOnlyList<T> list)
		{
			if(list.IsEmpty && this.IsEmpty){
				return ReadOnlyList<T>.Empty;
			}
			if(list.IsEmpty){
				return this;
			}
			if(IsEmpty){
				return list;
			}
			var result = new List<T> ();
			if(this.Count == list.Count){
				for(var position=0; position < this.Count; position++)
				{
					result.Add (this[position]);
					result.Add (list [position]);
				}
				return new ReadOnlyList<T> (result);
			}
			if(this.Count > list.Count){
				for(var position=0; position < this.Count; position++)
				{
					if (list.Count > position) {
						result.Add (_items [position]);
						result.Add (list [position]);
					}else{ 
						result.Add (_items[position]);
					}
				}
				return new ReadOnlyList<T> (result);
			}
			for(var position=0; position < list.Count; position++)
			{
				if (this.Count > position) {
					result.Add (_items [position]);
					result.Add (list [position]);
				}else{ 
					result.Add (list[position]);
				}
			}
			return new ReadOnlyList<T> (result);
		}

		private ReadOnlyList<T> Zip(ReadOnlyList<T> listOne, ReadOnlyList<T> listTwo){
			throw new NotImplementedException ();
		}
	}
}

