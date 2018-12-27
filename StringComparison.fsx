
///<summary> Assignment 
///This program compares two strings. If the strings are equal it prints "true" to the console, if not it prints "false". 
///The program consists of two different functions that create a multiplication table (in string type) in two different ways.
///The program then compares if the two functions create the same string by using the string comparison "=", for different values of n. <\summary>
///<remarks> The functions in this program have only been tested for 1 <= n <= 10. It runs with a few warnings for some of the indentations but wothout errors. <\remarks>  
///<param name= "str">string<\param>
///<param name= "n"> positive integer (int)<\param>
///<param name= "col">string<\param>
///<param name= "j">positive integer (int)<\param>
///<param name= "m">positive integer (int)<\param>
///<param name= "A">mutable string<\param>
///<param name= "B"> mutable string<\param>
///<example> For example the function call <code>mulTable 10<\code> together with <code>loopMulTable 10<\code> will print 
///<c>
///1   true
///2   true
///3   true
///4   true
///5   true
///6   true
///7   true
///8   true
///9   true
///10  true <\c> to the console. <\example>
///<returns> A table with two columns displaying the values of n and the result of the string comparison.<\returns> 
///<summary> Assignment 3i1d
///The difference between "printfn "%A"" and "printfn "%s""
/// "%A" can be used for all types while "%s" is a commando specifically for strings. 
/// If you are to print the content of a string, "%s" will be able to extract what is within the "". 
///"%A" will print the string with the "" as it won't read it as a string but just print everything as a whole. <\summary>

//A string that numbers the columns in the multiplication table. 
let col = "    1   2   3   4   5   6   7   8   9   10\n"
//Converts integer type values into string type. 
let intConv x = sprintf "%-4i" x
//Converts character type values into string type. 
let charConv x = sprintf "%c" x

//mulTable is built using the following string as an argument. 
let str = "    1   2   3   4   5   6   7   8   9   10\n" +
  "1   1   2   3   4   5   6   7   8   9   10  \n" + 
  "2   2   4   6   8   10  12  14  16  18  20  \n" +
  "3   3   6   9   12  15  18  21  24  27  30  \n" +
  "4   4   8   12  16  20  24  28  32  36  40  \n" +
  "5   5   10  15  20  25  30  35  40  45  50  \n" +
  "6   6   12  18  24  30  36  42  48  54  60  \n" +
  "7   7   14  21  28  35  42  49  56  63  70  \n" +
  "8   8   16  24  32  40  48  56  64  72  80  \n" +
  "9   9   18  27  36  45  54  63  72  81  90  \n" +
  "10  10  20  30  40  50  60  70  80  90  100 \n"

// mulTable is one of the two function that creates a multiplication table. 
let mulTable n =
//B is an empty string to which the program can add the string values of mulTable. 
//This is to store the values of mulTable instead of priting them to console. 
  let mutable B = ""
//A counter that counts the number of row breaks (\n). 
  let mutable counter = 0 
//An iterator, i goes through all the elements in the string, one by one, and when i comes across a row break the counter adds by 1.  
  let mutable i = 0
//This function only runs when n is lower than ten. The same process is not needed when n = 10.
// The function continues until the counter is equal to n.   
  if n < 10 then
    while (counter <= n) do
//c is the character in the element that the iterator i is currently checking.   
      let c = str.[i]
//When the character in elment i is \n, the counter is added by one.      
      if c = '\n' then
        counter <- counter + 1
//Instead of printing the string to the console, the string is stored in the empty string B. 
//The string is added to B one character at a time (the function charConv turns the character type into string type) until the counter = n. 
//"i <- i + 1" tells the iterator i to move forward within the string one element at a time.  
//I.e. when one element has beenchecked and its character has been printed, i checks the next element. Unless counter = n, beacause then it stops.          
      B <- B + (charConv c); i <- i + 1
// If n = 10 the whole string str is directly added into the empty string B.       
  if n = 10 then 
     B <- B + str
//Calling B can be seen as getting the return of mulTable. 
  B

// mulTable n is executed for all values of n between 1 and 10.   
mulTable 1
mulTable 2
mulTable 3
mulTable 4
mulTable 5
mulTable 6
mulTable 7
mulTable 8
mulTable 9
mulTable 10 

//loopMulTable is the second function that creates a multiplication table. It builds string dynamically. 
let loopMulTable n = 
//A is an empty string to which I can add the produced string. 
//The string is stored instead of printed to console so it later can be compared to the other string (mulTable).
  let mutable A = ""
// str multiplies j with m and turns the integer type factors into string type using sprintf. 
  let str j m = sprintf "%-4i" (j * m)
//A for loop that tells the program to multiply j with m for all values of j.  
  for j = 1 to n do
//If j equals 1 the function adds the string col to the empty string A.  
     if j = 1 then A <- A + col 
//j is multiplied with m for all integer values of m between 1 and 10.      
     for m = 1 to 10 do 
//If m equals 1 the function adds all the values of j to the empty string A, 
//using the function intConv to turn integer values into string values.      
        if m = 1 then A <- A + (intConv j)
//Instead of printing the finished table to the console the function adds it to the empty string A. 
//Whenever m = 10 the function adds a row break to A  to format the string like a table.         
        A <- A + (str j m)
        if m = 10 then A <- A + "\n" 

//Calling A can be seen as getting the return of loopMulTable.         
  A
// loopMulTable is executed for all values of n between 1 and 10.  
loopMulTable 1
loopMulTable 2
loopMulTable 3
loopMulTable 4
loopMulTable 5
loopMulTable 6
loopMulTable 7
loopMulTable 8
loopMulTable 9
loopMulTable 10

//Comparing the strings
//The strings are compared for all values of n (1-10). 
for n = 1 to 10 do 
//The function stores the finished strings in the mutable strings A and B. 
  let B = mulTable n
  let A = loopMulTable n 
//A column with all values of n is printed.   
  do printf "%-4i" n 
//The strings are compared for the different values of n. If they are the same it prints "true" to the console. If not it prints "false".

  if A = B then do printfn "true" else do printfn "false"

//3i1d 
// The difference between "printfn "%A"" and "printfn "%s""
// "%A" can be used for all types while "%s" is a commando specifically for strings. 
// If you are to print the content of a string, "%s" will be able to extract what is within the "". 
//"%A" will print the string with the "" as it won't read it as a string. 