using NUnit.Framework;
using System;

namespace Util.Tests
{
	[TestFixture]
	public class IListExtensionsTests
	{
		#region IndexesOf()

		[Test]
		public void IndexesOf_EmptyValue_ThrowsException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new [] { 1, 2 }.IndexesOf(new int[0]));
		}

		[Test]
		public void IndexesOf_LargerArrayValue_ReturnsNothing()
		{
			var indexes = new [] { 1, 2 }.IndexesOf(new [] { 1, 2, 3 });

			CollectionAssert.IsEmpty(indexes);
		}

		[Test]
		[TestCase(0)]
		[TestCase(1, 0, 4)]
		[TestCase(2, 1, 3)]
		[TestCase(3, 2)]
		[TestCase(4)]
		public void IndexesOf_SingleItem(int item, params int[] expectedIndexes)
		{
			var indexes = new [] { 1, 2, 3, 2, 1 }.IndexesOf(new[] { item });

			CollectionAssert.AreEqual(expectedIndexes, indexes);
		}

		[Test]
		[TestCase(1, 1)]
		[TestCase(1, 2, 0, 3)]
		[TestCase(2, 3, 1, 4)]
		[TestCase(3, 1, 2)]
		public void IndexesOf_TwoItems(int item1, int item2, params int[] expectedIndexes)
		{
			var indexes = new [] { 1, 2, 3, 1, 2, 3 }.IndexesOf(new[] { item1, item2 });

			CollectionAssert.AreEqual(expectedIndexes, indexes);
		}

		#endregion

		#region ContainsAt()

		[Test]
		public void ContainsAt_EmptyValue_ReturnsTrue()
		{
			var contained = new int[1].ContainsAt(0, new int[0]);

			Assert.IsTrue(contained);
		}

		[Test]
		public void ContainsAt_EqualArrays_ReturnsTrue()
		{
			var contained = new [] { 1 }.ContainsAt(0, new int[] { 1 });

			Assert.IsTrue(contained);
		}

		[Test]
		[TestCase(0, 1)]
		[TestCase(1, 2)]
		[TestCase(2, 3)]
		public void ContainsAt_SingleItem_ReturnsTrue(int index, int item)
		{
			var contained = new [] { 1, 2, 3 }.ContainsAt(index, new[] { item });

			Assert.IsTrue(contained);
		}

		[Test]
		[TestCase(0, 2)]
		[TestCase(1, 3)]
		[TestCase(2, 1)]
		public void ContainsAt_SingleItem_ReturnsFalse(int index, int item)
		{
			var contained = new [] { 1, 2, 3 }.ContainsAt(index, new[] { item });

			Assert.IsFalse(contained);
		}

		[Test]
		[TestCase(0, 1, 2)]
		[TestCase(1, 2, 3)]
		public void ContainsAt_TwoItems_ReturnsTrue(int index, int item1, int item2)
		{
			var contained = new [] { 1, 2, 3 }.ContainsAt(index, new[] { item1, item2 });

			Assert.IsTrue(contained);
		}

		[Test]
		[TestCase(0, 1, 1)]
		[TestCase(0, 2, 3)]
		[TestCase(1, 2, 2)]
		[TestCase(1, 2, 1)]
		[TestCase(2, 3, 3)]
		[TestCase(2, 3, 2)]
		public void ContainsAt_TwoItem_ReturnsFalse(int index, int item1, int item2)
		{
			var contained = new [] { 1, 2, 3 }.ContainsAt(index, new[] { item1, item2 });

			Assert.IsFalse(contained);
		}

		#endregion
	}
}
