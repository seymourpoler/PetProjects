using System;
using NUnit.Framework;

namespace FunqIoC.Test
{
	[TestFixture()]
	public class ServiceKeyTest
	{
		[Test()]
		public void KeyEqualsByServiceTypeAndFactoryType ()
		{
			var keyOne = new ServiceKey (typeof(IFormatProvider), typeof(IFormattable));
			var keyTwo = new ServiceKey (typeof(IFormatProvider), typeof(IFormattable));
			
			Assert.AreEqual (keyOne, keyTwo);
			Assert.AreEqual (keyOne.GetHashCode (), keyTwo.GetHashCode ());
		}
		
		[Test()]
		public void KeyNotEqualsByDifferentServiceTypes ()
		{
			var keyOne = new ServiceKey (typeof(object), typeof(IFormattable));
			var keyTwo = new ServiceKey (typeof(IFormatProvider), typeof(IFormattable));
			
			Assert.AreNotEqual (keyOne, keyTwo);
			Assert.AreNotEqual (keyOne.GetHashCode (), keyTwo.GetHashCode ());
		}
	
		[Test()]
		public void KeyNotEqualsByDifferentFactoryTypes ()
		{
			var keyOne = new ServiceKey (typeof(IFormatProvider), typeof(object));
			var keyTwo = new ServiceKey (typeof(IFormatProvider), typeof(IFormattable));
			
			Assert.AreNotEqual (keyOne, keyTwo);
			Assert.AreNotEqual (keyOne.GetHashCode (), keyTwo.GetHashCode ());
		}
	
	}
}

