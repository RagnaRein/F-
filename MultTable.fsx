
///<summary> 
///For this assignment we were supposed to create a program that prints n rows of the multiplication table (10 * 10) only using one string as an argument.
///To create the program I created a string variable, formatted to look just like the output shown in the worksheet.
///I then needed to create a function that would extract a given number of rows.
///To begin with I attempted to create a function that used the number of elements in each row to create an index. I soon gave up this idea as I found it was very sensitive to changes in the formatting of the string.
///Instead I created a counter and a iterator that when it comes across a rowbreak (\n) tells counter to add by one.
/// I.e. my program counts the number of rows by counting the number of row breaks. 
/// I realise this might not be the most common solution but I hope it will do. It runs with a few warnings because of my indentations, but without errors.<\summary>
///<remarks> This program has only been tested for 1 <= n <= 10.<\remarks> 
/// <param name= "str">string<\param>
///<param name= "n"> a positive integer (int)<\param>
///<example> The following function call <code> mulTable 3 <\code> returns <c> 
///      1    2   3   4   5   6   7   8   9  10
/// 1    1    2   3   4   5   6   7   8   9  10
/// 2    2    4   6   8  10  12  14  16  18  20
/// 3    3    6   9  12  15  18  21  24  27  30 <\c>
///<returns> n rows of the the multiplaction table. <\returns> 


// The string that used as argument. 
let str = "      1    2   3   4   5   6   7   8   9  10\n" +
  " 1    1    2   3   4   5   6   7   8   9  10\n" +
  " 2    2    4   6   8  10  12  14  16  18  20\n" +
  " 3    3    6   9  12  15  18  21  24  27  30\n" +
  " 4    4    8  12  16  20  24  28  32  36  40\n" +
  " 5    5   10  15  20  25  30  35  40  45  50\n" +
  " 6    6   12  18  24  30  36  42  48  54  60\n" +
  " 7    7   14  21  28  35  42  49  56  63  70\n" +
  " 8    8   16  24  32  40  48  56  64  72  80\n" +
  " 9    9   18  27  36  45  54  63  72  81  90\n" +
  "10   10   20  30  40  50  60  70  80  90 100\n"

//The main function, i.e. the starting point of the execution of the program. 
let mulTable n = 
//A counter that counts the number of row breaks (\n).
  let mutable counter = 0  
//An iterator, i goes through all elements in the string, one by one, and when i comes across a row break the counter adds by 1. 
  let mutable i = 0
//I only want to activate this function when n is less than ten. The same process is not needed when n = 10.
// The function continues until the counter is equal to n. 
  if n < 10 then   
    while (counter <= n) do 
//c is the character in the element that the iterator i is currently checking.     
      let c = str.[i] 
//When the character in the element i is currently checking is \n, the counter adds by 1.    
      if c = '\n' then 
        counter <- counter + 1
//The characters in the string are printed one by one until the counter reaches its maximum value (n). 
//"i <- i + 1" makes the iterator to move forward one element at a time within the string, without it would stop at element 0. 
//I.e. when one element has been checked and its character has been printed, the iterator moves to the next element. Unless counter = n, beacause then it stops. 
      do printf "%c" c; i <- i + 1

//If n = 10 there is no need to count the row breaks as the program should print the whole string. 
  if n = 10 then
    do printf "%s" str


mulTable 1

mulTable 2

mulTable 3

mulTable 10 
 