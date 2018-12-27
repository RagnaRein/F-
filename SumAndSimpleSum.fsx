
///<summary>Assignment 3i0c
///This program prints a table with three columns; n, sum and simpleSum. A table is convenient when comparing if the two functions return the same value.<\summary>
///<param name= "n">positive integer (int)<\param>
///<example> When n is set to <code>n < 6 <\code> the program prints the following table to the console: <c> 
///1    (sum) = 1    (simpleSum) = 1
///2    (sum) = 3    (simpleSum) = 3
///3    (sum) = 6    (simpleSum) = 6
///4    (sum) = 10   (simpleSum) = 10
///5    (sum) = 15   (simpleSum) = 15
///6    (sum) = 21   (simpleSum) = 21 <\c> <\example>
///<returns> A  table with three columns, presenting the value of n and the sum of integers from 1 to n caculated with two different functions.<\returns> 

///<summary> Assignment 3i0d 
/// These functions handle positive integer values of the type 'int'. F# only handles int values in the range -2,147,483,648 to 2,147,483,647. 
/// In theory the biggest sum these functions could calculate is 2147483647, which is the sum of all integers from 1 up to 6335. 
/// If we want the program to be able to calculate bigger sums we could use one of the types of values that have bigger ranges. 
/// For example 'int64' (-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807), or 'uint64' (0 to 18,446,744,073,709,551,615) (since I only caculate sums for positive integers). <\summary>

// n is a mutable parameter that can take on different integer values. Here n < 12, but the user can change this. 
//n < 12 prints 12 rows, since n (in this case) will take on all values from 1 to 11 and is always added by one (11 + 1 = 12).  
let mutable n = 0 
while n < 12 do
   n <- n + 1 

//This function sums all integers from 1 to n. When the iterator i is less than or equal to n, s is added by the value the iterator is currently "pointing to". 
//Every time the current value of i has been added to s, i is added by one. 
   let mutable s = 0
   let mutable i = 0
   while i <= n do
      s <- s + i
      i <- i + 1

//This function uses the formula n * (n + 1) / 2 to sum all integers from 1 to n. 
   let simpleSum n = n * (n + 1) / 2

//The result is printed to the console, formatted as a table with three columns. 
//One column for n, one for sum and one for simpleSum.
   printf "%-4d (sum) = %-4i (simpleSum) = %-4i \n" n s (simpleSum n)


//3i0d 
// These functions handle positive integer values of the type 'int'. F# only handles int values in the range -2,147,483,648 to 2,147,483,647. 
// In theory the biggest sum these functions could calculate is 2147483647, which is the sum of all integers from 1 up to 6335. 
// If we want the program to be able to calculate bigger sums we could use one of the types of values that have bigger ranges. 
//For example 'int64' (-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807), 
//or 'uint64' (0 to 18,446,744,073,709,551,615) (since I only caculate sums for positive integers). 