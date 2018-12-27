
//XML-doc header for fileReplace
///<summary>  
///The program replaces all the occurances of the needle argument with the replace argumen tin a text file. 
///<\summary>
/// <param name= "filename"> A text file <\param>
///<param name= "needle"> A string<\param>
///<param name= "replace">A string <\param>
///<remarks> Instruction restricted the choice of functions as we had to use (at least) OpenText, ReadLine and WriteLine. Doesn't take into account whether a character is capital or not. 
///A more thorough exception handling could've been done. I have focused on the more common exceptions. 
/// My exception messages are in Swedish as I was told it should not be in English to make it clearer what is coming from me and what is just from the system. <\remarks> 
///<returns> An edited version of the file filename. <\returns>

open System.IO 
open System

//val fileReplace : filname: string -> needle:string -> replace:string -> unit                                 //signature
let fileReplace (filename : string) (needle : string) (replace : string) : unit =                               //definition 
  try
    if needle= "" then invalidArg "needle" (needle); () else                                                    //exception: incorrect needle argument ("")                       
    let reader = System.IO.File.OpenText(filename)                                                              //opens file to read
    let mutable line = ""
    while not(reader.EndOfStream) do                                                                            //collects all lines in one long string
        let lines = reader.ReadLine()
        line <- line + lines + "\n"                                                                             //ReadLine discards new lines, therefore they have to be added back
    reader.Close()

    let rec replacer (line : string) (needle : string) (replace : string) : string =                           //replaces needle string eith replace string using active pattern
        if needle=replace then line
        elif line.Contains(needle) then
            let strings = [| line.Substring(0, line.IndexOf(needle)); replace; line.Substring(line.IndexOf(needle) + needle.Length) |]
            let newTxt = String.Concat(strings)
            replacer newTxt needle replace
        else
            line
    
    let writer = System.IO.File.CreateText(filename)                                                            //opens file to write to 
    let w (writer : System.IO.StreamWriter) (replacer : string) =
        writer.WriteLine(replacer)
    
    w writer (replacer line needle replace)
    writer.Close()     
   
  with 
    | :? System.IO.FileNotFoundException -> failwith "Filen finns inte"                         //exception: file doesnt exist 
    | :? System.IO.IOException -> failwith "Gick inte att läsa och/eller skriva till filen"     // exception: cant read or write to file 
    | :? System.ArgumentException -> failwith "Vänligen ange giltigt needle-argument"            //exception: invalid needle argument
    | _ -> failwith "Något gick fel!"                                                           // other exceptions 

//Test example
fileReplace "filen.txt" "pannkakor" "pancakes" 

//Other tests that can be done (that I have done successfully)
//needle > replace
// fileReplace "filen.txt" "pannkakor" "pancakes"  
//needle < replace 
// fileReplace "filen.txt" "ägg" "äggskal" 
//needle = replace
// fileReplace "filen.txt" "vispa" "vispa" 
//needle is not in file
//  fileReplace "filen.txt" "ragna" "Ragna" 
//needle is more than one word 
// fileReplace "filen.txt" "steka tunna pannkakor" "genomsteka pannkakor"

//Tests that will cause an exception 
// filename for a file that doesnt exist
// fileReplace "filen.t" "pannkakor" "pancakes"
// needle is an empty string 
// filereplace "filen.txt" "" "replace"



