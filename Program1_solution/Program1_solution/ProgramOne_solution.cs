using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


class ProgramOne_solution {

    static int LengthOfLongestSubstring(string s) { 
    
        HashSet<char> set = new HashSet<char>();

        int left = 0;
        int subStringMax = 0;

        for (int right = 0; right < s.Length; right++) {

            while (set.Contains(s[right])) {
                set.Remove(s[left]);
                left++;
            }

            set.Add(s[right]);

            subStringMax = Math.Max(subStringMax, right - left + 1);
        }

        return subStringMax;
    }

    static void Main(string[] args) {

        Console.Write("Enter string: ");
        string s = Console.ReadLine() ?? "";
        if (s.Length <= 0 && s.Length <= 100000) {
            Console.Write("Invad input! Enter a string whose length is greater then zero and less then 10000");
            s = Console.ReadLine() ?? "hahaaha";
        }

        int result =  LengthOfLongestSubstring(s);

        Console.WriteLine(result);
    
    }
   


}
