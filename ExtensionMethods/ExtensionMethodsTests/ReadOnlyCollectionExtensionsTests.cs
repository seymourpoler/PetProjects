using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExtensionMethods.ReadOnlyCollection;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class ReadOnlyCollectionExtensionsTests
    {
        [Fact]
        public void ReturnTrueWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsNull();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnTrueWhenIsEmpty()
        {
            var values = new List<string>().AsReadOnly();

            var result = values.IsEmpty();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnFalseWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsNotEmpty();

            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnFalseWhenIsEmpty()
        {
            var values = new List<string>().AsReadOnly();

            var result = values.IsNotEmpty();

            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnTrueWhenIsNotEmpty()
        {
            var values = new List<string> { "John" }.AsReadOnly();

            var result = values.IsNotEmpty();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnsTrueWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsNullOrEmpty();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnsTrueWhenIsEmpty()
        {
            var values = new List<string>().AsReadOnly();

            var result = values.IsNullOrEmpty();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnsFalseWhenIsNoEmpty()
        {
            var values = new List<string> { "John" }.AsReadOnly();

            var result = values.IsNullOrEmpty();

            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenIsNull()
        {
            IReadOnlyCollection<string> values = null;

            var result = values.IsNotNullAndNotEmpty();

            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsFalseWhenIsEmpty()
        {
            var values = new List<string>().AsReadOnly();

            var result = values.IsNotNullAndNotEmpty();

            result.ShouldBeFalse();
        }

        [Fact]
        public void ReturnsTrueWhenIsNotNullAndNotEmpty()
        {
            var values = new List<string> { "John" }.AsReadOnly();

            var result = values.IsNotNullAndNotEmpty();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnsZeroWhenIsNull()
        {
            IReadOnlyCollection<int> values = null;
            var result = 0;

            values.ForEach(x => result = result + x);

            result.ShouldBe(0);
        }

        [Fact]
        public void DoesNotingWhenActionIsNull()
        {
            var values = new List<int> { 1, 2, 3 }.AsReadOnly();
            var result = 0;

            values.ForEach(null);

            result.ShouldBe(0);
        }

        [Fact]
        public void ReturnsTheSumOfItems()
        {
            var values = new List<int> { 1, 2, 3 }.AsReadOnly();

            var result = 0;
            values.ForEach(x => result = result + x);

            result.ShouldBe(6)
        }
}