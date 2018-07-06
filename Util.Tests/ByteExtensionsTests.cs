using NUnit.Framework;
using System;

namespace Util.Tests
{
	[TestFixture]
	public class ByteExtensionsTests
	{
		#region IndexesOf()

		[Test]
		public void IndexesOf_EmptyValue_ThrowsException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new byte[] { 1, 2 }.IndexesOf(new byte[0]));
		}

		[Test]
		public void IndexesOf_LargerArrayValue_ReturnsNothing()
		{
			var indexes = new byte[] { 1, 2 }.IndexesOf(new byte[] { 1, 2, 3 });

			CollectionAssert.IsEmpty(indexes);
		}

		[Test]
		[TestCase(0)]
		[TestCase(1, 0, 4)]
		[TestCase(2, 1, 3)]
		[TestCase(3, 2)]
		[TestCase(4)]
		public void IndexesOf_SingleByte(byte b, params int[] expectedIndexes)
		{
			var indexes = new byte[] { 1, 2, 3, 2, 1 }.IndexesOf(new[] { b });

			CollectionAssert.AreEqual(expectedIndexes, indexes);
		}

		[Test]
		[TestCase(1, 1)]
		[TestCase(1, 2, 0, 3)]
		[TestCase(2, 3, 1, 4)]
		[TestCase(3, 1, 2)]
		public void IndexesOf_TwoBytes(byte b1, byte b2, params int[] expectedIndexes)
		{
			var indexes = new byte[] { 1, 2, 3, 1, 2, 3 }.IndexesOf(new[] { b1, b2 });

			CollectionAssert.AreEqual(expectedIndexes, indexes);
		}

		#endregion

		#region ContainsAt()

		[Test]
		public void ContainsAt_EmptyValue_ReturnsTrue()
		{
			var contained = new byte[1].ContainsAt(0, new byte[0]);

			Assert.IsTrue(contained);
		}

		[Test]
		public void ContainsAt_EqualArrays_ReturnsTrue()
		{
			var contained = new byte[] { 1 }.ContainsAt(0, new byte[] { 1 });

			Assert.IsTrue(contained);
		}

		[Test]
		[TestCase(0, 1)]
		[TestCase(1, 2)]
		[TestCase(2, 3)]
		public void ContainsAt_SingleByte_ReturnsTrue(int index, byte b)
		{
			var contained = new byte[] { 1, 2, 3 }.ContainsAt(index, new[] { b });

			Assert.IsTrue(contained);
		}

		[Test]
		[TestCase(0, 2)]
		[TestCase(1, 3)]
		[TestCase(2, 1)]
		public void ContainsAt_SingleByte_ReturnsFalse(int index, byte b)
		{
			var contained = new byte[] { 1, 2, 3 }.ContainsAt(index, new[] { b });

			Assert.IsFalse(contained);
		}

		[Test]
		[TestCase(0, 1, 2)]
		[TestCase(1, 2, 3)]
		public void ContainsAt_TwoBytes_ReturnsTrue(int index, byte b1, byte b2)
		{
			var contained = new byte[] { 1, 2, 3 }.ContainsAt(index, new[] { b1, b2 });

			Assert.IsTrue(contained);
		}

		[Test]
		[TestCase(0, 1, 1)]
		[TestCase(0, 2, 3)]
		[TestCase(1, 2, 2)]
		[TestCase(1, 2, 1)]
		[TestCase(2, 3, 3)]
		[TestCase(2, 3, 2)]
		public void ContainsAt_TwoBytes_ReturnsFalse(int index, byte b1, byte b2)
		{
			var contained = new byte[] { 1, 2, 3 }.ContainsAt(index, new byte[] { b1, b2 });

			Assert.IsFalse(contained);
		}

		#endregion
	}
}
