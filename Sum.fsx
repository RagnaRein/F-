
/// <summary>
///The purpose of this assignment was to create a program that sums all integers from 1 to n.<\summary>
/// <param name= "n">positive integer (int) <\param>
///<remarks> This program have only been tested for 1 <= n <= 10.<\remarks>
///<example> The function call <code> sum 10 <\code> prints <c>(sum) = 55<\c> to the console. <\example>
///<returns> The sum of all integers from 1 to n (1 + 2 + ... + n). <\returns> 

// The main function, i.e. where program exeution starts. 
let sum n = 
//i is an iterator that goes thorugh all values from 1 up to n. For every new value it "points to", it adds that value to s, and then moves on to the next. 
//This process continues until i has checked all values from 1 to n (i is equal to n). 
  let mutable s = 0
  let mutable i = 1
  while i <= n do
    s <- s + i
    i <- i + 1
//The return is printed to the console.     
  do printfn "sum = %i" s
//calling the function. 
sum 10 