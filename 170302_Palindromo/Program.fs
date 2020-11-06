// Learn more about F# at http://fsharp.org
// 170302-palindromo.fs
// Programming language: F#

(* Student: Edna Paola Castillo Jara 170302
  Universidad Politecnica de San Luis Potosi*)

(* Subject: Theory of Computation
  Professor: Juan Carlos Gónzalez Ibarra
 *)

open System

   
    [<EntryPoint>]
    let main argv =
        let palindrome = "anitalavalatina".ToCharArray()  // Define the palindrome as an array containing "anitalavalatina"        
        let AuxArray = Array.zeroCreate ((palindrome.Length/2)+1) // To create an array in order to add every character of palindrome array. palindrome.Length/2)+1 represents the "v" in the string
        let mutable aux = 0     // Auxiliary variable to increment in the for loop, declared as mutable in order to be able to change its value as needed
    
        for i=0 to (palindrome.Length/2) do   //loop that adds elements in auxiliary "AuxArray" but only half elements of palindrome variable "(palindrome.Length/2)"
            Array.set AuxArray i (palindrome.[i])    //Array.set sets an element to a specified value. Sets value i in "palindrome" to position i in "AuxArray"
            printfn "%A" AuxArray.[0..aux]    // Prints the array in the form "anitalav"
            aux <- aux+1
    
         // Now, with the next loop we print the array in the form "anitalav" backwards
        aux <- aux-2    // To reset its value and avoid printing the array two extra times
        for i=0 to (palindrome.Length/2)-1 do // We add "-1" in order to decrement in the loop and print the array backwards
            printfn "%A" AuxArray.[0..aux]  // This should give us an output like "anitala"
            aux <- aux-1 // Since "aux" is mutable we use "->" to change its value according to the loop to get the wished output
        
        0 // return an integer exit code