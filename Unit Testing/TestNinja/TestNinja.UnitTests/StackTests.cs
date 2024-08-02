using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int> s;

        [SetUp]
        public void SetUp()
        {
            s = new Stack<int>();
        }

        [Test]
        public void Peek_AtLeast1Element_ReturnsTopMost()
        {
            s.Push(1);
            s.Push(2);
            Assert.That(s.Peek() == 2);
        }

        [Test]
        public void Peek_EmptyStack_ThrowsEX()
        {
            Assert.That(() => s.Peek(), Throws.InvalidOperationException);
        }

        //[Test]
        //public void Push_NullElement_ThrowsEX()
        //{
        //    Assert.That(() => s.Push(null as int), Throws.ArgumentNullException);
        //}

        [Test]
        public void Push_AddingAnElement_AddsElementEndOfList()
        {
            s.Push(1);
            Assert.That(s.Peek() == 1 && s.Count == 1);
        }

        [Test]
        public void Push_PushingMultiple_ReturnTop()
        {
            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.That(s.Peek() == 3 && s.Count == 3);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsEX()
        {
            Assert.That(() => s.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_1Element_ThrowsEX()
        {
            s.Push(1);
            int res = s.Pop();
            Assert.That(res == 1 && s.Count == 0);
        }

        [Test]
        public void Pop_MultipleElemets_ReturnsDelElemet()
        {
            s.Push(1);
            s.Push(2);
            s.Push(3);

            int res = s.Pop();

            Assert.That(res == 3 && s.Peek() == 2 && s.Count == 2);
        }
    }
}
