
//XMLdoc header for merge 
///<summary> 
/// The function merge merges two integer lists lists.
///<\summary>
/// <param name= "xs"> A list of integers <\param>
///<param name= "ys"> A list of integers <\param>
/// <remarks> This program can be adapted to work on other types of lists but is here used on integer lists. <\remarks>
///<returns> A list of integers <\returns>
///<example>  The following function call <code> merge [1; 2; 3] [4: 5; 6] <\code> returns <c> [1; 2; 3; 4; 5; 6]  <\c> <\example>

//val merge int list -> int list -> int list                              //signature
let rec merge (xs : int list) (ys : int list) : int list =                //definition 
  match xs, ys with                                                       //beginning of algorithm
  | [] , ys -> ys
  | xs , [] -> xs
  | x::xs , y::ys -> 
     if x < y then x :: merge xs (y::ys)
     else y :: merge ys (x::xs)                                           //end of algorithm 
;;

//Black box testing for true 
merge [] [4; 5; 6; 7] = [4; 5; 6;7] ;;
merge [] [] = [] ;;
merge [1] [2] = [1; 2] ;;
merge [1; 2; 3] [4; 5; 6; 7] = [1; 2; 3; 4; 5; 6; 7] ;;