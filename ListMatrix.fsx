
///<summary> 
///The program evaluates if a list is a vaild matrix. 
///<\summary>
/// <param name= "xss"> List of integer lists<\param>
///<param name= "xs">Integer list<\param>
///<remarks> The program should preferably be run with F# interactive <\remarks> 
///<returns> A boolean value <\returns>
///<example> The following function call <code> isTable [[1; 2; 3]; [4; 5; 6]] <\code> returns <c> true <\c> <\example>
 

//val isTable int list list -> bool                                                             //signature 
let isTable (xss : int list list) : bool =                                                      //definition
    not (List.isEmpty xss)                                                                      //beginning of algorithm
    && not (List.isEmpty (List.head xss))  
    && List.forall (fun xs -> (List.length xs = List.length (List.head xss))) xss               //end of algorithm                                                                
                                        
;; 

//testing true with fsharp interactive 
isTable [[1; 2]; [3; 4]; [5; 6]] = true ;;        // list of integer lists of the same length 
isTable [[1]; [2]] = true ;;                   // list of lists with only one element 
isTable [[]] = false ;;                        // list of empty list  
isTable [] = false ;;                          // empty list                                                          
isTable [[1; 3]; [2]; []] = false ;;           // list of lists of different length (one empty)
isTable [[1; 2; 3]; [4; 5; 6; 7]] = false ;;   // list of integer lists with more than one element 

