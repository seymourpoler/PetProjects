using System.Collections.Generic;
using NUnit.Framework;
using Should;
using System;

namespace ReadOnlyList.Tests
{
	[TestFixture]
	public class ReadOnlyListTests
	{
		[Test]
		public void CreatesReadOnlyList()
		{
			var result = new ReadOnlyList<string> (new List<string> ());

			result.ShouldBeType<ReadOnlyList<string>> ();
		}

		[Test]
		public void ReturnsFirstElement()
		{
			var first = "first";
			var second = "second";
			var third = "third";
			var elements = new ReadOnlyList<string> (new List<string> { first, second, third });

			var result = elements.First;

			result.ShouldEqual (first);
		}

		[Test]
		public void ReturnsLastElement()
		{
			var first = "first";
			var second = "second";
			var third = "third";
			var elements = new ReadOnlyList<string> (new List<string> { first, second, third });

			var result = elements.Last;

			result.ShouldEqual (third);
		}

		[Test]
		public void RetunsTrueWhenIsEmpty()
		{
			var elements = new ReadOnlyList<string> (new List<string> ());

			var result = elements.IsEmpty;

			result.ShouldEqual (true);
		}

		[Test]
		public void RetunsFalseWhenIsNotEmpty()
		{
			var elements = new ReadOnlyList<string> (new List<string> {"first", "last"});

			var result = elements.IsEmpty;

			result.ShouldEqual (false);
		}

		[Test]
		public void ReturnsNumberOfElements()
		{
			var elements = new ReadOnlyList<string> (new List<string> {"one", "two", "three"});

			var result = elements.Count;

			result.ShouldEqual (3);
		}

		[Test]
		public void ReturnsNewReadOnlyListWithNewItemAppended()
		{
			var newElement = new DataTest ("_three", 3);

			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_one", 1),
					new DataTest("_two", 2),
				});

			var result = elements.Append (newElement);

			result.Count.ShouldEqual (3);
			result.Last.Id.ShouldEqual ("_three");
		}

		[Test]
		public void ReturnsFilteredReadOnlyList()
		{
			var elements = new ReadOnlyList<string> (new List<string>{ "_one", "two", "_three" });

			var result = elements.Where (x => x.StartsWith("_"));

			result.First.ShouldEqual ("_one");
		}

		[Test]
		public void RetunsForEach()
		{
			var elements = new ReadOnlyList<string> (new List<string>{ "_one", "two", "_three" });

			var total = 0;
			elements.ForEach (x => total = total+1);

			total.ShouldEqual (3);
		}

		[Test]
		public void RetunsSum()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_one", 1),
					new DataTest("_two", 2),
				});

			var result = elements.Sum (x => x.Number);

			result.ShouldEqual (3);
		}

		[Test]
		public void ReturnsAny()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_one", 1),
					new DataTest("_two", 2),
				});

			var result = elements.Any(x => x.Number < 2);

			result.ShouldBeTrue();
		}

		[Test]
		public void ReturnsWithPipe(){
			var elements = new ReadOnlyList<string> (new List<string>{ "_one", "_two" });

			var result = elements.Pipe(x => x.Replace("_", String.Empty));

			result.First.ShouldEqual ("one");
		}

		[Test]
		public void ReturnsSelectedReadOnlyList()
		{
			var elements = new ReadOnlyList<string> (new List<string>{"_one", "two", "_three" });

			var result = elements.Select (x => new DataTest(x, 2));

			result.First.Id.ShouldEqual("_one");
		}

		[Test]
		public void ReturnsAll()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_one", 4),
					new DataTest("_two", 5),
				});

			var result = elements.All (x => x.Number > 2);

			result.ShouldBeTrue();
		}

		[Test]
		public void ReturnsAverage()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_one", 4),
					new DataTest("_two", 5),
				});

			var result = elements.Average (x => x.Number);

			result.ShouldEqual((decimal)4.5);
		}

		[Test]
		public void ReturnsMin()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_one", 4),
					new DataTest("_two", 1),
					new DataTest("_three", 5),
				});

			var result = elements.Min (x => x.Number);

			result.ShouldEqual(1);
		}

		[Test]
		public void ReturnsMax()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_one", 4),
					new DataTest("_two", 1),
					new DataTest("_three", 5),
				});

			var result = elements.Max (x => x.Number);

			result.ShouldEqual(5);
		}

		[Test]
		public void ReturnsReverse()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_two", 1),
					new DataTest("_one", 4),
					new DataTest("_three", 5),
				});

			var result = elements.Reverse ();

			result.First.Id.ShouldEqual("_three");
			result.Last.Id.ShouldEqual("_two");
		}

		[Test]
		public void ReturnsSingle()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_two", 1),
					new DataTest("_one", 4),
					new DataTest("_three", 5),
				});

			var result = elements.SingleOrDefault (x => x.Number == 4);

			result.Id.ShouldEqual("_one");
			result.Number.ShouldEqual(4);
		}

		[Test]
		public void ReturnsDefaultForSingleOrDefault()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_two", 1),
					new DataTest("_one", 4),
					new DataTest("_three", 5),
				});

			var result = elements.SingleOrDefault (x => x.Number > 10);

			result.ShouldBeNull ();
		}

		[Test]
		public void ReturnsOrderedListAscending()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_three", 5),
					new DataTest("_two", 1),
					new DataTest("_one", 4),
				});

			var result = elements.OrderAscendingBy(x => x.Id);

			result.First.Id.ShouldEqual ("_one");
			result.Last.Id.ShouldEqual ("_two");
		}

		[Test]
		public void ReturnsOrderedListDescending()
		{
			var elements = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_three", 5),
					new DataTest("_two", 1),
					new DataTest("_one", 4),
				});

			var result = elements.OrderDescendingBy(x => x.Id);

			result.First.Id.ShouldEqual ("_two");
			result.Last.Id.ShouldEqual ("_one");
		}

		[Test]
		public void ReturnsEmptyList()
		{
			var result = ReadOnlyList<DataTest>.Empty;

			result.Count.ShouldEqual (0);
			result.IsEmpty.ShouldBeTrue();
		}

		[Test]
		public void ReturnsZippedListWithAnEmptyLists()
		{
			var listOne = ReadOnlyList<DataTest>.Empty;

			var listTwo = ReadOnlyList<DataTest>.Empty;

			var result = listOne.Zip(listTwo);

			result.IsEmpty.ShouldBeTrue();
		}

		[Test]
		public void ReturnsZippedListWithOneEmptyLists()
		{
			var listOne = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_three", 5),
					new DataTest("_two", 1),
					new DataTest("_one", 4),
				});

			var listTwo = ReadOnlyList<DataTest>.Empty;

			var result = listOne.Zip(listTwo);

			result.Count.ShouldEqual(3);
			result.First.Number.ShouldEqual (5);
		}

		[Test]
		public void ReturnsZippedListWithAnotherEmptyLists()
		{
			var listOne = new ReadOnlyList<DataTest> (
				new List<DataTest>{ 
					new DataTest("_three", 5),
					new DataTest("_two", 1),
					new DataTest("_one", 4),
				});

			var listTwo = ReadOnlyList<DataTest>.Empty;

			var result = listTwo.Zip(listOne);

			result.Count.ShouldEqual(3);
			result.First.Number.ShouldEqual (5);
		}
	}

	internal class DataTest{
		public string Id{ get; private set;}
		public int Number{ get; private set;}

		public DataTest(){
			Id = "_zero";
			Number = 0;
		}

		public DataTest(string id, int number){
			Id = id;
			Number = number;
		}
	}

}

