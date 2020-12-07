//Regex.fs
// Programming language: F#

(* Student: Edna Paola Castillo Jara 170302
  Universidad Politecnica de San Luis Potosi*)

(* Subject: Theory of Computation
  Professor: Juan Carlos Gónzalez Ibarra
 *)

open System
open System.Text.RegularExpressions // Library needed to use Regex class

[<EntryPoint>]
let main argv =

    let Source_code = "int result = 1;".Split(' ')  // Turning source code "int result = 1;"  into a list of words
    let mutable tokens = []    // For string tokens
      
    for i in Source_code do  // Loop through each source code word, we use "i" as a counter to evaluate in every case below

        // This will check if a token has datatype declaration
        if (i.Equals("str") || i.Equals("int") || i.Equals("bool")) 
        then    //If the "source_code" variable is wether a string, an integer value or a boolean, then 
            tokens <- List.append tokens ["DATATYPE", i] // We can use List.append to combine two lists together
        
        
        
        // This will look for an identifier which would be just a word
        if (Regex.IsMatch (i, "[a-z]") || Regex.IsMatch (i, "[A-Z]")) // If it matches as a regular expression,
        then
            tokens <- List.append tokens ["IDENTIFIER", i] // We can use List.append to combine two lists together


        // This will look for an operator
        if (Regex.IsMatch(i, "(\+|\-|\*|\/|\%|\=)" )) // Matches if there is an operator with the "i" parameter
        then 
            tokens <- List.append tokens ["OPERATOR", i] // We can use List.append to combine two lists together


        // This will look for integer items and cast them as a number

    
    printfn "%A" tokens  // This will print the list named as Tokens in the beginning in which results have been added
    0 // return an integer exit code
