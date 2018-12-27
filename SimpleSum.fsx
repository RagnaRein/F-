
///<summary> 
///The purpose of this assignment is to code a function that sums all intergers from 1 up to n.<\summary>
/// <remarks> The function has only been tested for positive integer values of n.<\remarks> 
///<param name="n"> positive integer (int)< <\param>
///<example> The function call <code> simpleSum 10 <\code> prints <c>(simpleSum) = 55<\c> to the console. <\example>
///<returns> The sum of all integers from 1 to n (1 + 2 + ... + n).<\returns>  

//The main function, i.e. where program exeution starts.
let simpleSum n = 
//The formula used to calculate the sum of all integers from 1 up to n. 
  let s = n * (n + 1) / 2 
//The return is printed to the console.   
  printfn "(simpleSum) = %i" s
//Calling the function. 
simpleSum 10 