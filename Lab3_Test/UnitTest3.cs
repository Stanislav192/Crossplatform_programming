using Lab3;

namespace Lab3_Test
{
    public class UnitTest3
    {
        //Test State Creation from Inputs
        [Fact]
        public void Test_Read_ValidInput()
        {
            string[] lines = { "ABCD", "EFGH", "IJKL", "MNOP" };
            State expected = new State();
            expected.a[0, 0] = 'A'; expected.a[0, 1] = 'B'; expected.a[0, 2] = 'C'; expected.a[0, 3] = 'D';
            expected.a[1, 0] = 'E'; expected.a[1, 1] = 'F'; expected.a[1, 2] = 'G'; expected.a[1, 3] = 'H';

            State result = State.Read(lines, 0);

            Assert.Equal(expected, result);

            if (expected == result)
            {
                Console.WriteLine("Test is passed.");
            }
            else
            {
                Console.WriteLine("Test is failed");
            }
        }

        // Test Deep Copy
        [Fact]
        public void Test_DeepCopy()
        {
            State original = new State();
            original.a[0, 0] = 'A'; original.a[0, 1] = 'B'; original.a[0, 2] = 'C'; original.a[0, 3] = 'D';
            original.a[1, 0] = 'E'; original.a[1, 1] = 'F'; original.a[1, 2] = 'G'; original.a[1, 3] = 'H';

            State copy = original.DeepCopy();

            Assert.Equal(original, copy);
            if (copy == original)
            {
                Console.WriteLine("Test is passed.");
            }
            else
            {
                Console.WriteLine("Test is failed");
            }
        }

        //Test Equality Method
        [Fact]
        public void Test_Equals_SameState()
        {
            State state1 = new State();
            state1.a[0, 0] = 'A'; state1.a[0, 1] = 'B'; state1.a[0, 2] = 'C'; state1.a[0, 3] = 'D';
            state1.a[1, 0] = 'E'; state1.a[1, 1] = 'F'; state1.a[1, 2] = 'G'; state1.a[1, 3] = 'H';

            State state2 = state1.DeepCopy();

            Assert.True(state1.Equals(state2));
            Console.WriteLine("Test is passed.");
        }

        [Fact]
        public void Test_GetHashCode_Consistency()
        {
            State state = new State();
            state.a[0, 0] = 'A'; state.a[0, 1] = 'B'; state.a[0, 2] = 'C'; state.a[0, 3] = 'D';
            state.a[1, 0] = 'E'; state.a[1, 1] = 'F'; state.a[1, 2] = 'G'; state.a[1, 3] = 'H';

            int hash1 = state.GetHashCode();
            int hash2 = state.GetHashCode();

            Assert.Equal(hash1, hash2);
            Console.WriteLine("Test is passed.");
        }

        //Test Shift Method with Out of Bounds Move
        [Fact]
        public void Test_Shift_OutOfBoundsMove()
        {
            State state = new State();
            state.a[0, 0] = '#'; 
            state.a[0, 1] = 'B';
            state.a[0, 2] = 'C';
            state.a[0, 3] = 'D';
            state.a[1, 0] = 'E';
            state.a[1, 1] = 'F';
            state.a[1, 2] = 'G';
            state.a[1, 3] = 'H';

            State result = state.Shift(-1, 0); 

            Assert.Equal(state, result);
            Console.WriteLine("Test is passed.");
        }
    }

}