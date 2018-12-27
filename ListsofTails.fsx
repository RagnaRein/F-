
///<summary> 
///The program creates a new list of lists consisting of only the tails of lists within a list.  
///<\summary>
/// <param name= "xss"> List of integer lists<\param>
///<param name= "xs">Intger list<\param>
///<remarks> The program should preferably be run with F# interactive <\remarks> 
///<returns> A list of integer lists <\returns> 
///<example> The following function call <code> dropFirstColumn [[1; 2; 3]; [4; 5; 6]] <\code> returns <c> [[2; 3]; [5; 6]] <\c> <\example>


//val dropFirstColumn int list list -> int list list            //signature
let dropFirstColumn (xss : int list list) : int list list =     //definition 

    List.collect (fun x -> [List.tail x]) xss                   //algorithm 

;; 

//testing true with fsharp interactive   
dropFirstColumn [[1; 2; 3]; [4; 5; 6]] = [[2; 3]; [5; 6]] ;;    //list of integer lists 
dropFirstColumn [] = [] ;;                                      //empty list
dropFirstColumn [[3]; [6]] = [[]; []] ;;                        // list of lists with only one element 
dropFirstColumn [[1; 2; 3]; [4; 6]; [9]] = [[2; 3]; [6]; []] ;; // list of lists with different lengths 