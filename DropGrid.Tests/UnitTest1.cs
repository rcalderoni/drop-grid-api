using DropGrid.Logic;

namespace DropGrid.Tests
{
    [TestClass]
    public class DropGridTests
    {
        [TestMethod]
        public void new_drop_reaches_bottom_row()
        {
            var grid = new Grid(3, 10);

            grid.Drop(7);

            var check = grid.Current;

            Assert.AreEqual(7, check[0,9]);
        }

        [TestMethod]
        public void drops_stack_correctly()
        {
            var grid = new Grid(3, 10);

            grid.Drop(7);
            grid.Drop(5);

            var check = grid.Current;

            Assert.AreEqual(7, check[0, 9]);
            Assert.AreEqual(5, check[0, 8]);
        }

        [TestMethod]
        public void drops_into_full_row_throws_exception()
        {
            var grid = new Grid(3, 3);

            grid.Drop(7);
            grid.Drop(5);
            grid.Drop(3);

            var check = grid.Current;

            Assert.AreEqual(7, check[0, 2]);
            Assert.AreEqual(5, check[0, 1]);
            Assert.AreEqual(3, check[0, 0]);

            Assert.ThrowsException<Exception>(() =>
            {
                grid.Drop(9);
            });
        }

        [TestMethod]
        public void remove_removes_valid_drop()
        {
            var grid = new Grid(3, 10);

            grid.Drop(7);
            grid.Drop(5);

            grid.Remove(new System.Numerics.Vector2(0, 9));

            var check = grid.Current;

            Assert.AreEqual(0, check[0, 9]);
            Assert.AreEqual(5, check[0, 8]);
        }

        [TestMethod]
        public void after_remove_fall_properly_sends_drops_to_bottom()
        {
            var grid = new Grid(3, 10);

            grid.Drop(7);
            grid.Drop(5);

            grid.Drop(9, 1);
            grid.Drop(99, 1);
            grid.Drop(999, 1);

            grid.Remove(new System.Numerics.Vector2(0, 9));

            grid.Remove(new System.Numerics.Vector2(1, 8));
            grid.Remove(new System.Numerics.Vector2(1, 9));

            var check = grid.Current;

            Assert.AreEqual(0, check[0, 9]);
            Assert.AreEqual(5, check[0, 8]);

            Assert.AreEqual(0, check[1, 9]);
            Assert.AreEqual(0, check[1, 8]);
            Assert.AreEqual(999, check[1, 7]);

            grid.Fall();

            check = grid.Current;

            Assert.AreEqual(5, check[0, 9]);

            Assert.AreEqual(999, check[1, 9]);
            Assert.AreEqual(0, check[1, 8]);
            Assert.AreEqual(0, check[1, 7]);
        }
    }
}