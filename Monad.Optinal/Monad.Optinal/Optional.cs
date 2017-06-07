namespace Monad.Optinal
{
	public interface IOptional<T> where T : class
	{
		
	}

	public class Optional
	{
		public static IOptional<T> From<T>(T value) where T : class
		{
			if(value == default(T)){
				return new None<T> ();
			}
			return new Some<T> (value);
		}
	}

	public class Some<T> : IOptional<T> where T : class{
		private readonly T _value;

		public Some(T value){
			_value = value;	
		}
	}

	public class None<T> : IOptional<T> where T : class{}
}

