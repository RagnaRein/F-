(*Opgave 7i3 
Ragna Reinhammar
2017-11-01 *)

//XMLdoc header for levensthein
///<summary> Assignment 7i3
/// This program calculates the Levensthein distance between two strings using recursion. 
///Inline min is a utility function that helps speeding up the calculation. The use of "inline" was inspired by Jons notes. 
///<\summary>
///<param name= "a"> A string <\param>
///<param name= "b">  A string <\param>
///<remarks> This program is slow and therefor isn't suitable for longer strings. <\remarks> 
///<returns> An integer <\returns>
///<example> The following function call <code> levensthein "horse" "house" <\code> returns <c> 1 <\c> <\example>

// val inline min : m:'a -> n:'a -> o:'a -> 'a when 'a : comparison //signature
let inline min m n o =                                              //definition 
    if m < n && m < o then m 
    elif n < o then n
    else o 

//val levensthein string -> string -> int                          //signature
let levensthein (a: string) (b: string) =                          //definition 
    let x = a.Length                                             
    let z = b.Length 

    let rec leven (a: string) (b: string) (x: int) (z: int) = 
        match x, z with                                             
            | x, z when z = 0 -> x 
            | x, z when x = 0 -> z 
            | _ ->
                let del = leven a b (x-1) (z) + 1    
                let add = leven a b (x) (z-1) + 1
                let subst = 
                    match a.[x-1] = b.[z-1] with 
                    | true ->  leven a b (x-1) (z-1) + 0
                    | false -> leven a b (x-1) (z-1) + 1 
                min del add subst    
    leven a b x z 
                   
//Black box testing for true 
levensthein "house" "horse" = 1 ;;
levensthein "hi" "hej" = 2 ;;
levensthein "danger" "dangerous" = 3 ;;              

