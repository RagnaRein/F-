

///<summary> 
///The program  converts a list of lists into one list. 
///<\summary>
/// <param name= "xss"> List of integer lists<\param>
///<param name= "xs">Intger list<\param>
///<remarks> The program should preferably be run with F# interactive <\remarks> 
///<returns>  A list of integers <\returns>
///<example>  The following function call <code> concat [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]] <\code> returns <c> [1; 2; 3; 4; 5; 6; 7; 8; 9] <\c>
 

//val concat int list list -> int list                                  //signature 
let concat (xss : int list list) : int list =                           //definition 

   List.collect (fun xs -> xs) xss                                      //algorithm  

;; 

//testing true with fsharp interactive 
concat [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]] = [1; 2; 3; 4; 5; 6; 7; 8; 9]  // list of integer lists
concat [] = [] ;;                                                       // empty list
concat [[]] = [] ;;                                                     // list of empty list 
concat [[1; 2; 3]; [4; 6]; [9]] = [1; 2; 3; 4; 6; 9] ;;                 // list of lists with different lengths 