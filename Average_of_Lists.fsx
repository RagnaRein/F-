
///<summary> 
///The program calculates the average of the elements in a list of floats, given that the list of floats is not empty. 
///<\summary>
///<param name= "xs"> List of floats<\param>
///<remarks> The program should preferably be run with F# interactive <\remarks> 
///<returns> A float option <\returns> 
///<example>  The following function call <code> gennemsnit [1.0; 2.2; 3.5; 4.6; 5.7; 7.9; 8.11; 9.12] <\code> returns <c> Some 5.26625 <\c>


//val gennemsnit float list -> float option            //signature 
let gennemsnit (xs : float list) : float option =      //definition 
                       
  if xs = [] then None else                            //beginning of algorithm   
    Some ((List.fold (+) 0.0 xs) / (float xs.Length))  //end of algorithm
;; 

//testing true with fsharp interactive 
gennemsnit [] = None ;;                                                    // empty list
gennemsnit [1.0; 2.2; 3.5; 4.6; 5.7; 7.9; 8.11; 9.12] = Some 5.26625 ;;    // non empty list of postive floats
gennemsnit [-1.0; 2.2; 3.5; -4.6; 5.7; 7.9; -8.11; 9.12] = Some 1.83875 ;; // non empty list with positive and negative floats 
