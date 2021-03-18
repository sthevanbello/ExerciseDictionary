using ExerciseDictionary.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExerciseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Temp\Dictionary\in.csv";

            Dictionary<string, int> candidatesAll = new Dictionary<string, int>();

            Candidate candidates;

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int votes = int.Parse(line[1]);
                        candidates = new Candidate(name, votes);

                        if (!candidatesAll.ContainsKey(name))
                        {
                            candidatesAll[candidates.Name] = candidates.Vote;
                        }
                        else
                        {
                            candidatesAll[candidates.Name] += candidates.Vote;
                        }

                    }

                }

                foreach (KeyValuePair<string, int> item in candidatesAll)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }



            Console.ReadKey();

        }
    }
}
