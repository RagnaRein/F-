
///<summary> 
///The program transposes a (n*3) matrix. 
///<\summary>
/// <param name= "xss"> List of integer lists<\param>
///<param name= "xs">Intger list<\param>
///<remarks> The program should preferably be run with F# interactive. The program only works for n * 3 matrices, i.e the number of rows can vary but not the number of columns.<\remarks> 
///<returns> A list of integer lists <\returns> 
///<example> The following function call  <code> transpose [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]] <\code> returns <c> [[1; 4; 7]; [2; 5; 8]; [3; 6; 9]]<\c>



//val transpose int list list -> int list list                                  //signature
let transpose (xss : int list list) : int list list =                           //definition 
  
    (List.collect (fun xs -> [List.head xs]) xss)                               //beginning of algorithm 
    :: (List.collect (fun xs -> [List.head (List.tail xs)]) xss) 
    :: (List.collect (fun xs -> List.tail (List.tail xs)) xss) 
    :: []                                                                       //end of algorithm 
;;    

//testing true with fsharp interactive 
transpose [[1; 2; 3]; [4; 5; 6]; [7; 8; 9]] = [[1; 4; 7]; [2; 5; 8]; [3; 6; 9]] ;;                        //3*3 matrix
transpose [] = [[]; []; []] ;;                                                                            //empty list
transpose [[1; 2; 3; 4]; [5; 6; 7; 8]; [9; 10; 11; 12]] = [[1; 5; 9]; [2; 6; 10]; [3; 4; 7; 8; 11; 12]];; //4*4 matrix ("INCORRECT" OUTPUT)
 
