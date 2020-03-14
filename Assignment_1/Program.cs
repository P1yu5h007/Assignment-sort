using System;
using System.IO;

namespace Assignment_1
{
    class Program
    {
        public static void Search()
        {
            Console.WriteLine("Which search would you like to use?");
            int searchChoice = 0;
            while(searchChoice <= 0 || searchChoice > 2)
            {
                Console.WriteLine("Please enter the number related to corresponding search.");
                Console.WriteLine("1. Linear Search");
                Console.WriteLine("2. Binary Search");

                bool userInputChecker = int.TryParse(Console.ReadLine(), out searchChoice);
                if(userInputChecker == false)
                {
                    Console.WriteLine("That is an invalid input, please try again");
                }
            }
        }
        public static void Sorts()
        {
            Console.WriteLine("Which sort would you like to use ?");
            int sortChoice = 0;
            while (sortChoice <= 0 || sortChoice > 4)//Options from 1 to 4
            {
                Console.WriteLine("Please enter the number of the corresponding sort you would like to use from 1 to 4.");
                Console.WriteLine("1.Bubble Sort");
                Console.WriteLine("2. ");
                Console.WriteLine("3.");
                Console.WriteLine("4.");

                //using a bool to check if what is inputted is a string or not, and if it is saving it to sortChoice var
                bool userInputChecker = int.TryParse(Console.ReadLine(), out sortChoice);
                if (userInputChecker == false)
                {
                    Console.WriteLine("That is an invalid input, please try again.");
                }
            }
            switch (sortChoice)
            {
                case 1:
                    Console.WriteLine("Bubble Sort");
                    bubbleSort();
                    
                    break;

                case 2:
                    Console.WriteLine("");

                    break;

                case 3:
                    Console.WriteLine("");

                    break;

                case 4:
                    Console.WriteLine("");

                    break;
            }
        }
        public static void Main(String[] args)
            {
                //Ask user which text file/array they would like to analyze
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
                    elementList = 9;
                }
                else if (file == 2)
                {
                    fileName = "Net_2_256.txt";
                    size = 256;
                    elementList = 9;
                }
                else if (file == 3)
                {
                    fileName = "Net_3_256.txt";
                    size = 256;
                    elementList = 9;
                }
                else if (file == 4)
                {
                    fileName = "Net_1_2048.txt";
                    size = 2048;
                    elementList = 49;
                }
                else if (file == 5)
                {
                    fileName = "Net_2_2048.txt";
                    size = 2048;
                    elementList = 49;
                }
                else
                {
                    fileName = "Net_3_2048.txt";
                    size = 2048;
                    elementList = 49;
                }

                int[] userArray = readFile(fileName, size);
                bubbleSort(userArray);

                int[] readFile(string fileName, int size)
                {
                    int[] array = new int[size];
                    int counter = 0;

                    StreamReader sr = new StreamReader(fileName);

                    while (sr.EndOfStream == false)
                    {
                        array[counter] = Convert.ToInt32(sr.ReadLine().Trim());
                        counter++;
                    }
                    sr.Close();
                    return array;
                }
                void bubbleSort(int[] array)
                {
                    int[] tempArray = new int[array.Length + 1];
                    array.CopyTo(tempArray, 1);

                    int temp = 0;

                    for (int write = 0; write < array.Length; write++)
                    {
                        for (int sort = 0; sort < array.Length - 1; sort++)
                        {
                            if (array[sort] > array[sort + 1])//Ascending bubble sort
                            {
                                temp = array[sort + 1];
                                array[sort + 1] = array[sort];
                                array[sort] = temp;
                            }
                            if (tempArray[sort] < tempArray[sort + 1])//Descending bubble sort
                            {
                                temp = tempArray[sort + 1];
                                tempArray[sort + 1] = tempArray[sort];
                                tempArray[sort] = temp;
                            }
                        }

                    }
                    Console.WriteLine("Ascending");
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.WriteLine(array[i]);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("List of every " + (elementList + 1) + "nth element(Ascending):");
                    for (int o = 0; o < array.Length; o += elementList)
                    {
                        Console.WriteLine(array[o]);
                    }
                    Console.ReadLine();
                    Console.WriteLine("Descending");
                    for (int j = 0; j < tempArray.Length; j++)
                    {
                        Console.WriteLine(tempArray[j]);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("List of every " + (elementList + 1) + "nth element(Descending):");
                    for (int o = 0; o < tempArray.Length; o += elementList)
                    {
                        Console.WriteLine(tempArray[o]);
                    }
                    Console.ReadLine();

                }
            }
    }
}

