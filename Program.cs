namespace Assignment_5._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of flowers to plant in the flowerbed: ");
            int flowers;
            while (!int.TryParse(Console.ReadLine(), out flowers)) ;

            int[] flowerbed;
            if (args.Length > 0)
            {
                flowerbed = new int[args.Length];
                int i = 0;
                foreach (var arg in args)
                {
                    if (int.TryParse(arg, out var value))
                        flowerbed[i] = value;
                    i++;
                }
                Console.WriteLine(MaximumPlantableSpots(flowerbed) >= flowers);
            }
            else
            {
                int testCases = 10;
                Random rng = new Random();
                for (int n = 0; n < testCases; n++)
                {
                    flowerbed = new int[rng.Next(10)];

                    Console.Write("[ ");
                    for (int i = 0; i < flowerbed.Length; i++)
                    {
                        Console.Write($"{flowerbed[i] = rng.Next(2)} ");
                    }
                    Console.Write("] ");

                    Console.WriteLine(MaximumPlantableSpots(flowerbed) >= flowers);
                }
            }
        }

        static int MaximumPlantableSpots(int[] flowerbed)
        {
            int spots = 0;
            bool plantable = false;

            // go through the flowerbed and count all plantable spots
            for (int i = 0; i < flowerbed.Length; i++)
            {
                #region pseudocode
                // if empty spot
                //     if spot is edge case start of flowerbed
                //         check next spot is empty
                //     if spot is edge case end of flowerbed
                //         check previous spot is empty
                //     if spots next and previous are empty
                //         spot is plantable and have to skip next spot 
                #endregion
                if (flowerbed[i] == 0)
                {
                    if (i == 0)
                    {
                        #region pseudocode
                        // if next spot exists && is empty
                        //     increment spots
                        // else
                        //     increment spots 
                        #endregion
                        plantable = (flowerbed.Length == 1 || i + 1 < flowerbed.Length && flowerbed[i + 1] == 0);
                    }
                    else if (i == flowerbed.Length - 1)
                    {
                        #region pseudocode
                        // if previous spot exists && is empty
                        //     increment spots
                        // else
                        //     increment spots 
                        #endregion
                        plantable = (i - 1 > -1 && flowerbed[i - 1] == 0);
                    }
                    else
                    {
                        #region pseudocode
                        // if previous spot and next spot are empty
                        //     increment spots then increment index by 1 to skip next spot 
                        #endregion
                        plantable = (flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0);
                    }

                    if (plantable)
                    {
                        spots++;
                        i++;
                    }
                }
            }

            return spots;
        }
    }
}
