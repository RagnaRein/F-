
//XMLdoc header for levensthein 
///<summary>
///The program calculates the Levensthein distance between two strings through mutual recursion. 
///Inline min is a utility function that helps speeding up the calculation. The use of "inline" was inspired by Jons notes. 
///<\summary>
/// <param name= "a"> A string <\param>
///<param name= "b"> A string <\param>
///<remarks>  <\remarks> 
///<returns> An integer <\returns>
///<example> The following function call <code>  levensthein "horse" "house" <\code> returns <c>  1 <\c> <\example>

/// val inline min : m:'a -> n:'a -> o:'a -> 'a when 'a : comparison 
let inline min m n o = 
    if m < n && m < o then m
    elif n < o then n
    else o

//val levensthein string -> string -> int    
let levensthein (a: string) (b: string) =  
    let i = a.Length 
    let j = b.Length
    let arr = Array2D.create (i + 1) (j + 1) -1 
 
    let rec leven (a: string) (b: string) (i: int) (j: int) = 
        match i, j with 
            | i, j when j = 0 -> i 
            | i, j when i = 0 -> j 
            | _ ->  
                let del = (leven_cache a b (i-1) j) + 1   
                let add = (leven_cache a b i (j-1)) + 1
                let subst = 
                    match a.[i-1] = b.[j-1] with 
                    | true ->  (leven_cache a b (i-1) (j-1)) + 0
                    | false -> (leven_cache a b (i-1) (j-1)) + 1
                min del add subst               

    and leven_cache (a: string) (b: string) (i: int) (j: int) = 
        if arr.[i,j] = -1 then  
            arr.[i,j] <- leven a b i j 
        
        arr.[i,j]

    leven a b i j     
;;

//Black box testing for true 
levensthein "house" "horse" = 1 ;;
levensthein "hi" "hej" = 2 ;;
levensthein "danger" "dangerous" = 3 ;;
levensthein "dangerous house" "danger horse" = 4 ;;
levensthein "programmering" "problemløsning" = 7 ;;




