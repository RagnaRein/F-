
///<summary> 
///The program  creates a new list with only the first elements from lists within a list. 
///<\summary>
/// <param name= "xss"> List of integer lists<\param>
///<param name= "xs">Intger list<\param>
///<remarks> The program should preferably be run with F# interactive <\remarks> 
///<returns>  A list of integers <\returns> 
///<example> The following function call <code> firstColumn [[1; 2; 3]; [4; 5; 6]] <\code> returns <c> [1; 4] <\c> <\example>



//val firstColumn int list list -> int list                      //signature 
let firstColumn (xss : int list list) : int list =               //definition 

    List.collect (fun xs -> [List.head xs]) xss                   //algorithm  

;; 
//testing true with fsharp interactive 
firstColumn [[1; 2; 3]; [4; 5; 6]] = [1; 4] ;;                   //list of integer lists 
firstColumn [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]] = [1; 4; 7] ;;     //list of integer lists
firstColumn [] = [] ;;                                           //empty list 
firstColumn [[3]; [6]] = [3; 6] ;;                               // list of integer lists with only one element 

