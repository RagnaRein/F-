
//XMLdoc header for countLinks 
///<summary> 
///The program counts the number of links on a webpage (in the wepage'. 
///<\summary>
/// <param name= "url"> A string <\param>
///<remarks> Please note that the number of links vary on some websites from day to day, therefore I haven't done a test testing for true for more than dtu.dk, because that has been consistent over time.
///My counter is quite lenghty and could've been shortened, but as the assignment wasn't about the counter itself I figured it would be alright 
///(since it's working as it should). 
///A more extensive work on handling exceptions could've been done. I have focused on the more common exceptions. 
///My exception messages are in Swedish as I was told it should not be in English to make it clearer what is coming from me and what is just from the system.<\remarks> 
///<returns> An integer <\returns>
///<example> The following function call <code> countLinks "http://www.dtu.dk/" <\code> returns <c> 242 <\c> <\example>

open System.Net
open System 
open System.IO
open System.Text.RegularExpressions

//help function 
//val getUrl: url:string -> string                                      //signature 
let getUrl (url : string) : string =                                    //definition 
  try                                 
    let rqst = WebRequest.Create(Uri(url)) 
    use rspn = rqst.GetResponse()
    use stream = rspn.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    in reader.ReadToEnd()
  with 
    | :? System.Net.WebException -> failwith "Ingen internetuppkoppling!"     //exception: no internet access 
    | :? System.UriFormatException -> failwith "URI-adressen är inte giltig"  // exception: invalid uri address 
    | _ -> failwith "Något gick fel!"                                         //other exceptions 

//val countLinks: url:string -> int                                   //signature 
let countLinks (url : string) : int =                                 //definition 
    let regExp = "<a href"
    let regExpLen = regExp.Length
    let regex = Text.RegularExpressions.Regex(regExp)
    let mutable counter = 0 
    let mutable source = getUrl(url)                                  //saves the source code as string in site
    let mutable flag = regex.IsMatch(source)                          //mutable boolean value to indicate if the while loop should stop or not 
    while flag do                                                     // while flag = true the while loop runs 
        let matchFlag = regex.Match(source)                           
        let pos = matchFlag.Index                                     //get position of match
        counter <- counter + 1                                        // number of links = number of loops
        source <- source.[(pos + regExpLen)..(source.Length-1)]       //remove everything up until the index position (also remove the match from the string)
        if not(regex.IsMatch(source)) then                            //if there are no more matches flag will be false and the while loop stops 
            flag <- false
        else 
            flag <- true
    counter    

//Testing for true 
((countLinks "http://www.dtu.dk/") = 287)

//Test printed to console    
printfn "Number of links: %A" (countLinks "http://www.dtu.dk/") ;;      //without security socket layer 
printfn "Number of links: %A" (countLinks "https://www.reddit.com/") ;; //with security socket layer 
printfn "Number of links: %A" (countLinks "https://www.google.com") ;;  //with security socket layer 
printfn "Number of links: %A" (countLinks "https:www.google.com") ;;    //incorrect uri 

