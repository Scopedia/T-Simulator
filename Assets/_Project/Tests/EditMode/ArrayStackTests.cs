using NUnit.Framework;
using TSim.Collections;

namespace TSim.Tests
{
    // Her [Test] kucuk bir senaryo: bir sey yap, sonucun dogru oldugunu Assert ile kontrol et.
    // Unity'de: Window > General > Test Runner > EditMode > Run All
    public class ArrayStackTests
    {
        [Test]
        public void YeniStack_Bos()
        {
            var s = new ArrayStack<int>();

            Assert.AreEqual(0, s.Count);
        }

        [Test]
        public void Push_CountuArtirir()
        {
            var s = new ArrayStack<int>();
            s.Push(1);
            s.Push(2);

            Assert.AreEqual(2, s.Count);
        }

        [Test]
        public void TryPop_SonGireniIlkVerir_LIFO()
        {
            var s = new ArrayStack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);

            Assert.IsTrue(s.TryPop(out int a));
            Assert.AreEqual(3, a);           // son giren ilk cikar
            Assert.IsTrue(s.TryPop(out int b));
            Assert.AreEqual(2, b);
            Assert.AreEqual(1, s.Count);
        }

        [Test]
        public void TryPop_BosStackte_FalseDonerVeCokmez()
        {
            var s = new ArrayStack<string>();

            bool basardi = s.TryPop(out string item);

            Assert.IsFalse(basardi);
            Assert.IsNull(item);
        }

        [Test]
        public void Grow_KapasiteDolunca_ElemanlarKaybolmaz()
        {
            var s = new ArrayStack<int>(capacity: 2);
            for (int i = 1; i <= 10; i++)    // 2 -> 4 -> 8 -> 16: uc kez buyur
                s.Push(i);

            Assert.AreEqual(10, s.Count);
            for (int beklenen = 10; beklenen >= 1; beklenen--)
            {
                s.TryPop(out int x);
                Assert.AreEqual(beklenen, x);
            }
            Assert.AreEqual(0, s.Count);
        }

        [Test]
        public void SacmaKapasite_SifirVerilse_Calisir()
        {
            var s = new ArrayStack<int>(capacity: 0);
            s.Push(5);

            Assert.IsTrue(s.TryPop(out int x));
            Assert.AreEqual(5, x);
        }
    }
}
