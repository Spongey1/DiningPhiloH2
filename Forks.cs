namespace DiningPhilo
{
    public class Forks
    {
        // Forks themselves
        public static bool[] forks = new bool[5];

        // Index 0 has 1, index 1 has 2 and so on. Lastly index 4 has 0
        // Used to check left and right forks
        public static int[] AllowedForks = { 1, 2, 3, 4, 0 };

    }
}