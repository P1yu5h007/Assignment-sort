using System;
using System.IO;

namespace Assignment_1
{
    class counter
    {
        public static int count = 0;
        public static int count2 = 0;
    }
    class Program
    {
        public static void Search(int[] network)
        {
            int x = 0;
            while (x  == 0) {

                Console.WriteLine("Which search would you like to search for");
                bool userInputChecker = int.TryParse(Console.ReadLine(), out x);
                if (userInputChecker == false)
                {
                    Console.WriteLine("That is an invalid input, please try again");
                }
            }
            int pos = -1;
            Console.WriteLine("Which search would you like to use?");
            int searchChoice = 0;
            while (searchChoice <= 0 || searchChoice > 2)
            {
                Console.WriteLine("Please enter the number related to corresponding search.");
                Console.WriteLine("1. Linear Search");
                Console.WriteLine("2. Binary Search");

                bool userInputChecker = int.TryParse(Console.ReadLine(), out searchChoice);
                if (userInputChecker == false)
                {
                    Console.WriteLine("That is an invalid input, please try again");
                }
            }

            switch (searchChoice)
            {
                case 1: pos = linear(network,x);
                    break;
                case 2: pos = binary(network, x, 0, network.Length - 1);  break;
            }
            if (pos != -1)
            {
                Console.WriteLine("value is found at " + pos);
            }
            else
                Console.WriteLine("4 0 4  value not found");
        }

        private static int linear(int[] network, int x)
        {
            int leg = network.Length;
            for (int i = 0; i < leg; i++)
            {
                if (network[i] == x)
                    return i;
            }
            return -1;
        }

        public static int binary(int[] network, int x, int smoll, int big)
        {
            if (big >= smoll)
            {
                int mid = smoll + (big - 1) / 2;
                if (network[mid] == x)
                    return mid;
                if (network[mid] > x)
                    return binary(network, smoll, mid - 1, x);

                return binary(network,  mid + 1, big, x);
            }
            return -1;
        }
        public static void Sorts(int[] network, int elementList)
        {
            Console.WriteLine("Which sort would you like to use ?");
            int sortChoice = 0;
            while (sortChoice <= 0 || sortChoice > 4)//Options from 1 to 4
            {
                Console.WriteLine("Please enter the number of the corresponding sort you would like to use from 1 to 4.");
                Console.WriteLine("1.Bubble Sort");
                Console.WriteLine("2.Quick Sort ");
                Console.WriteLine("3.Selection sort");
                Console.WriteLine("4.Cockatil sort");

                //using a bool to check if what is inputted is a string or not, and if it is saving it to sortChoice var
                bool userInputChecker = int.TryParse(Console.ReadLine(), out sortChoice);
                if (userInputChecker == false)
                {
                    Console.WriteLine("That is an invalid input, please try again.");
                }
            }
            int[] tempnet1 = network;
            int[] tempnet2 = network;
            switch (sortChoice)
            {
                case 1:
                    Console.WriteLine("Bubble Sort");
                    BubbleSortDown(tempnet1);
                    bubbleSortup(tempnet2);
                    break;

                case 2:
                    Console.WriteLine("Quick sort");
                    quickdown(tempnet1, 0, tempnet1.Length - 1);
                    quickup(tempnet2, 0, tempnet1.Length - 1);
                    break;

                case 3:
                    Console.WriteLine("");
                    selectiondown(tempnet1);
                    selectionup(tempnet2);
                    break;

                case 4:
                    Console.WriteLine("");
                    cocktaildown(tempnet1);
                    cocktailup(tempnet2);
                    break;
            }
            Console.WriteLine("would you want up or down 1 for up 2 for down. 1 is default?");
            int check = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(check);
            if (check == 1)
            {
                printnetwork(tempnet1, elementList);
                Console.WriteLine("To sort took " + counter.count + " Iterations");
            }
            if (check == 2)
            {
                printnetwork(tempnet2, elementList);
                Console.WriteLine("To sort took " + counter.count2 + " Iterations");
            }
            Search(tempnet1);
        }
        public static void printnetwork(int[] network, int elementList)
        {

            for (int i = 0; i < network.Length; i += elementList)
            {
                Console.WriteLine( i + ": " +network[i]);
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
        }
        public static void BubbleSortDown(int[] network)
        {
            int width = network.Length;
            for (int c = 0; c < width - 1; c++)
            {
                for (int sorter = 0; sorter < width - 1 - c; sorter++)
                {
                    if (network[sorter] > network[sorter + 1])
                    {

                        counter.count2++;
                        int temp = network[sorter]; network[sorter] = network[sorter + 1]; network[sorter + 1] = temp;

                    }
                }
            }
        }
        public static void bubbleSortup(int[] network)
        {
            int width = network.Length;
            for (int c = 0; c < width - 1; c++)
            {
                for (int sorter = 0; sorter < width - 1 - c; sorter++)
                {
                    if (network[sorter] > network[sorter + 1])
                    {

                        counter.count++;
                        int temp = network[sorter]; network[sorter] = network[sorter + 1]; network[sorter + 1] = temp;

                    }
                }
            }
        }
        public static void quickup(int[] network, int smol  , int big)
        {
            if (smol < big)
            {
                counter.count++;
                int sp = segpart(network, smol, big);
                quickup(network, smol, sp - 1);
                quickup(network, sp + 1, big);
            }
        }
        public static void quickdown(int[] network, int smol, int big)
        {
            if (smol < big)
            {

                counter.count2++;
                int sp = segpartdown(network, smol, big);
                quickdown(network, smol, sp - 1); quickdown(network, sp + 1, big);
            }
        }

        private static int segpartdown(int[] network, int smol, int big)
        {
            int mid = network[big];
            int c = (smol - 1);
            for (int i = smol; i < big; i++)
            {
                if (network[i] > mid)
                {
                    c++;
                    int tep = network[c];
                    network[c] = network[i];
                    network[i] = tep;
                }
            }
            int tep2 = network[c + 1];
            network[c + 1] = network[big];
            network[big] = tep2;
            return c + 1;
        }

        private static int segpart(int[] network, int smol, int big)
        {
            int mid = network[big];

            int c = (smol - 1);
                for (int i = smol; i < big; i++)
            {
                if (network[i] < mid)
                {
                    c++;
                    int tep = network[c];
                    network[c] = network[i];
                    network[i] = tep;
                }
            }
            int tep2 = network[c + 1];
            network[c + 1] = network[big];
            network[big] = tep2;

            return c + 1;
        }
        public static void selectionup(int[] network)
        {
            int leg = network.Length;
            for (int i = 0; i< leg -1; i++)
            {
                int minimuminx = i;
                for (int p = i + 1; p<leg; p++)
                {
                    if(network[p] < network[minimuminx])
                    {
                        minimuminx = p;
                    }
                }
                int temp = network[minimuminx];
                network[minimuminx] = network[i];
                network[i] = temp;

                counter.count++;
            }
        }
        public static void selectiondown(int[] network)
        {
            int leg = network.Length;
            for (int i = 0; i < leg - 1; i++)
            {
                int minimuminx = i;
                for (int p = i + 1; p < leg; p++)
                {
                    if (network[p] > network[minimuminx])
                    {
                        minimuminx = p;
                    }
                }
                int temp = network[i];
                network[i] = network[minimuminx];
                network[minimuminx] = temp;

                counter.count2++;
            }
        }
        public static void cocktailup(int[] network) 
        {
            bool flip = true;
            int begin = 0;
            int stop = network.Length -1 ;

            while(flip == true)
            {
                flip = false;
                for ( int i = begin; i < stop; i++)
                {
                    if (network[i] < network[i + 1])
                    {

                        counter.count++;
                        int tmp = network[i+1];
                        network[i+1] = network[i];
                        network[i] = tmp;
                        flip = true;
                    }
                }
                if (flip ==false)
                    break;
                flip = false;
                stop = stop - 1;
                for (int i = stop; i >= begin; i--)
                {
                    if (network[i] < network[i + 1])
                    {
                        int tmp = network[i + 1];
                        network[i + 1] = network[i];
                        network[i] = tmp;
                        flip = true;
                    }
                }
                begin = begin + 1;
            }
        }
        public static void cocktaildown(int[] network)
        {
            bool flip = true;
            int begin = 0;
            int stop = network.Length - 1;

            while (flip == true)
            {
                flip = false;
                for (int i = begin; i < stop; i++)
                {
                    if (network[i] < network[i + 1])
                    {

                        counter.count2++;
                        int tmp = network[i + 1];
                        network[i+1] = network[i];
                        network[i] = tmp;
                        flip = true;
                    }
                }
                if (flip == false)
                    break;
                flip = false;
                stop = stop - 1;
                for (int i = stop; i >= begin; i--)
                {
                    if (network[i]> network[i + 1])
                    {
                        int tmp = network[i];
                        network[i] = network[i + 1];
                        network[i + 1] = tmp;
                        flip = true;
                    }
                }
                begin = begin + 1;
            }
        }
        public static void Main(String[] args)
        {
            //Ask user which text file/network they would like to analyze
            Console.WriteLine("Which file would you like to look at ?");
            int file = 0;
            while (file <= 0 || file > 6)//Options from 1 to 6
            {
                Console.WriteLine("Please select the number of the file you wish to view, between 1 and 6:");//User is given the options to choose from 1-6  
                Console.WriteLine("1. Net_1_256.txt");
                Console.WriteLine("2. Net_2_256.txt");
                Console.WriteLine("3. Net_3_256.txt");
                Console.WriteLine("4. Net_1_2048.txt");
                Console.WriteLine("5. Net_2_2048.txt");
                Console.WriteLine("6. Net_3_2048.txt");
                //using a bool to check if what is inputted is a string or not, and if it is saving it to file var
                bool userInputChecker = int.TryParse(Console.ReadLine(), out file);
                if (userInputChecker == false)
                {
                    Console.WriteLine("That is an invalid input, please try again.");
                }

            }
            int size = 0;
            string fileName = "";
            int elementList = 0;
            if (file == 1)
            {
                fileName = "Net_1_256.txt";
                size = 256;
                elementList = 10;
            }
            else if (file == 2)
            {
                fileName = "Net_2_256.txt";
                size = 256;
                elementList = 10;
            }
            else if (file == 3)
            {
                fileName = "Net_3_256.txt";
                size = 256;
                elementList = 10;
            }
            else if (file == 4)
            {
                fileName = "Net_1_2048.txt";
                size = 2048;
                elementList = 50;
            }
            else if (file == 5)
            {
                fileName = "Net_2_2048.txt";
                size = 2048;
                elementList = 50;
            }
            else
            {
                fileName = "Net_3_2048.txt";
                size = 2048;
                elementList = 50;
            }

            int[] network = new int[size];
            int counter = 0;

            StreamReader sr = new StreamReader(fileName);

            while (sr.EndOfStream == false)
            {
                network[counter] = Convert.ToInt32(sr.ReadLine().Trim());
                counter++;
            }
            sr.Close();
            printnetwork(network, elementList);
            Sorts(network, elementList);
        }       

    }
}