Title: 170302-palindromo.fs 
Programming Language: F# 
Authors: Edna Paola
Castillo Jara 170302 
Subject: Theory of Computation 
Professor: Juan Carlos Gónzalez Ibarra 
Universidad Politecnica de San Luis Potosi

To begin with: Be sure to install Visual Studio, in order to be able to
install it in your PC, you must be a Windows OS user, since Visual
Studio is developed by Microsoft. Otherwise, you can use anothe IDE to
run the file. Continuing with Visual Studio, go to the next link:
https://visualstudio.microsoft.com/es/ and you shoul download the
community 2019 package so it would be easier to acces when it comes to
licenses and permissions. You must have a Microsoft account to log in,
on the contrary, you can register at the moment. Once you are done, you
can open the file.

A palindrome is a word or phrase that reads the same in one sense as in another. 
If it is numbers instead of letters, it is called capicúa . Typically, palindromic 
phrases suffer in meaning the longer they are. In this case the phrase is "anitalavalatina" as
showed below.

Code section:

// CODIGN BEGINS HERE

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

// CODING ENDS HERE
