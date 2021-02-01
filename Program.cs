// Mark Morey U36467084
// Assignment 1 ISM 6225 Spring 2021

using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {// start of main method 

            ////Question 1 Print a triangle of "*" n times
            Console.WriteLine("Q1 : Enter the number of rows for the triangle:");
            int n = Convert.ToInt32(Console.ReadLine());
            int counter = 1;
            counter = n - 1;
            printTriangle(n, counter); // need to call both variables used in method or else will error 
            Console.WriteLine();

            //// Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            int x = 0;
            int y = 1;
            int z = 0;
            printPellSeries(n2, x, y, z);
            Console.WriteLine();

            ////Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int c = Convert.ToInt32(Console.ReadLine());
            bool flag = SquareSums(c);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            int[] nums = arr.Distinct().ToArray();
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(nums, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            // Question 5:
            List<string> emails = new List<string>();
            // create dummy lists to add back to throughout cleaning process
            List<string> noDots = new List<string>();
            List<string> noPluses = new List<string>();
            List<string> newEmails = new List<string>();

            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails, noDots, noPluses, newEmails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            // Question 6 Destination City
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            //creating dummy lists to put cities in
            List<string> origins = new List<string>();
            List<string> destinations = new List<string>();

            // create variable to store answer
            string destination = DestCity(paths, origins, destinations);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }// end of main method




        // creates the print triangle method with letter (int) n, and counter which is input - 1
        // also creates error message to tell user if they entered wrong type of input
        private static void printTriangle(int n, int counter)
        {// start of print triangle
            try
            {
                for (int i = 1; i <= n; i++) // perform the loops n number of times
                {
                    for (int j = 1; j <= counter; j++) //create a space, need counter variable to decrement # of the spaces as the triangle gets bigger
                        Console.Write(" ");
                    counter--;
                    for (int k = 1; k <= 2 * i - 1; k++) //print the star, will increment by 2 each time but still start at 1 
                        Console.Write("*"); //need to use write not write line because it will create a whole new line
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }// end of print triangle 

        // Start of Pell Series
        private static void printPellSeries(int n2, int x, int y, int z)
        {
            try
            {
                if (n2 == 0) // in case soemone wants 0 digits returned
                { Console.Write(" "); }
                else if (n2 == 1) // in case someone just wants 1 digit returned
                { Console.Write("0"); }
                else // use the loop if anything more than 1 is entered for n2
                {
                    Console.Write(x + "," + y + ","); // print 0 and 1 
                    for (int i = 2; i < n2; ++i)
                    {
                        z = x + y * 2; // 3rd number in the pell calculation loop 
                        Console.Write(z + ",");
                        x = y; // each loop the last number becomes the new first
                        y = z; // each loop the third number becomes the new second


                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        } // end of pell series

        private static bool SquareSums(int c)//start of sum squares
        {
            int a; // creating local variable
            int b; // creating local variable
            if (c >= 0) // checking for non negative
            {
                for (a = 0; a <= c; a++) // iterating from 0 to n 
                {
                    for (b = a + 1; b <= c; b++) //iterating from 1 to n 
                    {
                        if ((a * a) + (b * b) == c) // testing if a squared and b squared equal n 
                        {
                            return true;
                        }

                    }
                }
            }
            return false; // need to put false outside last if statement or else method will not run 

        } // end of sum squares

        private static int diffPairs(int[] nums, int k)
        {// start of diffpairs
            try
            {
                int i; // loop variables
                int j;

                int count = 0; // count variable

                for (i = 0; i < nums.Length; i++) // looping through length of array
                {
                    for (j = i + 1; j < nums.Length; j++)
                        if (Math.Abs(nums[i] - nums[j]) == k) // checking diff between 2 numbers
                            count++; // increasing counter 
                }

                return count; // if success return our count and statement created earlier on 
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw; // error message
            }

        }// end of diff pairs 

        private static int UniqueEmails(List<string> emails, List<string> newEmails, List<string> noDots, List<string> noPluses)
        {//start of unique emails
            try
            {
                for (int i = 0; i < emails.Count; i++)

                {   // removing dots
                    noDots.Add(emails[i].Replace(".", ""));

                    // getting indexes of the +'s and rmeoving everything after it 
                    int plusindex = noDots[i].IndexOf("+");
                    noPluses.Add(noDots[i].Remove(plusindex));

                    //getting the domain name back
                    // find index, then find substring, then concatenate to new local names
                    string domain = "@";
                    int atIndex = emails[i].IndexOf(domain);
                    newEmails.Add(noPluses[i].Trim() + emails[i].Substring(atIndex));


                }

                // clear old list
                emails.Clear();

                // add newly cleaned emails back to the original list
                for (int j = 0; j < newEmails.Count; j++)
                {
                    emails.Add(newEmails[j]);
                    emails[j].Trim();
                }

                // use Linq to select the distinct # of email addresses
                int ans5 = (from x in emails select x).Distinct().Count();

                return ans5;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        } // end of unqiue emails

        private static string DestCity(string[,] paths, List<string> origins, List<string> destinations)
        {// start of Dest City
            try
            {
                //loop through array and create two lists 
                //one of where we have been and where we are going to 
                for (int i = 0; i < paths.GetLength(0); i++)
                {
                    origins.Add(paths[i, 0]);
                    destinations.Add(paths[i, 1]);
                }


                //loop through origins and search for a destination not in that list
                // if we haven't been there before it won't complete the circle
                string destination = null;
                for (int i = 0; i < paths.GetLength(0); i++)
                {
                    if (!origins.Contains(destinations[i]))
                    {
                        destination = destinations[i];
                    }

                }
                return destination;


            }
            catch (Exception)
            {

                throw;
            }


        } // end of dest city


    }// end of class
}// end of namespace

    

