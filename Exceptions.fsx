//XML-doc header for safeIndexIf, safeIndexTry and safeIndexOption.
///<summary> Assignment 9i-0 consists of three separate functions: safeIndexIf, safeIndexTry and safeIndexOption. 
///They all take the same arguments, arr and i, but they have different return values. safeIndexIf and safeIndexTry return 'a, and safeIndexOption returns 'a option. 
///They are all supposed to return value i of an array, or throw an exception. 
///<\summary>
/// <param name= "arr"> Array of undefinied type and length<\param>
///<param name= "i">Integer<\param>
///<remarks>safeIndexIf lacks a reasonable solution and safeIndexOption uses a helper function or .Value to print to the screen. More about this can be read in my report. 
/// Since the program stops when an exception occurs, only the an exception for the last function is left. 
///In the first two I have have given examples for what causes an exception but "//" for it not to be excuted. <\remarks> 
///<returns> Value i of an array. <\returns>


//val safeIndexIf : arr:'a [] -> i:int -> 'a                                                 //signature
let safeIndexIf (arr: 'a []) (i : int) : 'a =                                                //definition 
   if 0 <= i && i <= arr.Length then arr.[i]
   else arr.[i]

printfn "%A" (safeIndexIf [|1; 2; 3|] 1) 
printfn "%A" (safeIndexIf [|1; 2; 3; 5; 6|] 3) 
printfn "%A" (safeIndexIf [|"hej"; "d"; "S"|] 1) 
//exception 
//printfn "%A" (safeIndexIf [|1; 2; 3; 5; 6|] 7) (* = System.Exception*) 


// val safeIndexTry : arr:'a [] -> i:int -> 'a                                              //signature
let safeIndexTry (arr: 'a []) (i : int) : 'a =                                              //definition 
    try 
       arr.[i]
    with 
        | :? System.IndexOutOfRangeException -> failwith "Ogiltigt index"
        | _ -> failwith "Ogiltigt index och/eller array" 

//test
printfn "%A" (safeIndexTry [|1; 2; 3|] 1) 
printfn "%A" (safeIndexTry [|1; 2; 3; 5; 6|] 3)
printfn "%A" (safeIndexTry [|"hej"; "d"; "S"|] 1)
//exception
//printfn "%A" (safeIndexTry [|1; 2; 3; 5; 6|] 7) (* = System.Exception: Ogiltigt index*) 


//val safeIndexOption : arr:'a [] -> i:int -> 'a option                                         //signature
let safeIndexOption (arr : 'a []) (i : int) : 'a option =                                       //definition
    try 
        Some(arr.[i])
    with 
        | :? System.IndexOutOfRangeException -> None
        | _ -> None   

//help function for printing
//val printVal : safeIndexOption:'a option -> 'a             
let printVal (safeIndexOption : 'a option) : 'a = 
    try 
        Option.get (safeIndexOption)
    with 
        | :? System.ArgumentException -> failwith "Option-värdet var None"
        | _ -> failwith "Något gick fel!"   

//testing for true 
printfn "%A" ((safeIndexOption [|1; 2; 3|] 1).Value)
printfn "%A" (printVal(safeIndexOption [|1; 2; 3; 5; 6|] 3))  
printfn "%A" ((safeIndexOption [|"hej"; "d"; "S"|] 1).Value) 
printfn "%A" (printVal(safeIndexOption [|"hej"; "d"; "S"|] 1)) 

//testing exceptions
//printfn "%A" (safeIndexOption [|1; 2; 3; 5; 6|] 7).Value (*program crashes : System.NullReferenceException*)  ;;
printfn "%A" (printVal(safeIndexOption [|1; 2; 3; 5; 6|] 7)) (*System.Exception: Option-värdet var None*) ;;