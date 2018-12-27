(*Opgave 7i1
Ragna Reinhammar
2017-11-01 *)

//val merge int list -> int list -> int list                    //signature 
let rec merge (xs : int list) (ys : int list) =                 //definition 
  match xs, ys with                                             //beginning of algorithm 
  | [] , ys -> ys
  | xs , [] -> xs
  | x::xs , y::ys -> 
     if x < y then x :: merge xs (y::ys)
     else y :: merge ys (x::xs)                                   //end of algorithm 
;;
//val msort int list -> int list                                  //signature 
let rec msort (xs : int list) : int list =                        //definition 
    let sz = List.length xs                                       //beginning of algorithm 
    if sz < 2 then xs
    else let n = sz / 2
         let ys = xs.[0..n-1]
         let zs = xs.[n..sz-1]
         in merge (msort ys) (msort zs)                            //end of algorithm 
;;

//Black box testing for true 
msort [] = [];;
msort [1] = [1];;
msort [1; 1; 1] = [1; 1; 1] ;;
msort [3; 1] = [1; 3];;
msort [5; 3; 2; 1; 4; 6] = [1; 2; 3; 4; 5; 6] ;;
msort [1; 2; 3; 4; 5; 6] = [1; 2; 3; 4; 5; 6] ;;
msort [6; 5; 4; 3; 2; 1] = [1; 2; 3; 4; 5; 6] ;;
msort [-2; -1; 5; 6; 3] = [-2; -1; 3; 5; 6] ;; 



