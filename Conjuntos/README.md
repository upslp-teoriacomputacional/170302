Title: 170302-conjuntos.fs
Programming Language: F#
Authors: Edna Paola Castillo Jara 170302
Subject: Theory of Computation
Professor: Juan Carlos Gónzalez Ibarra
Universidad Politecnica de San Luis Potosi

The coding presented below consists on a demonstration and examples of the use of set functions and operations in the already mentioned
programming language, F#.

To begin with:
Be sure to install Visual Studio, in order to be able to install it in your PC, you must be a Windows OS user, since Visual Studio is
developed by Microsoft. Otherwise, you can use anothe IDE to run the file.
Continuing with Visual Studio, go to the next link:
https://visualstudio.microsoft.com/es/ and you shoul download the community 2019 package so it would be easier to acces when it comes to licenses and permissions.
You must have a Microsoft account to log in, on the contrary, you can register at the moment. 
Once you are done, you can open the file.



Code section:

// Coding begins here

open System

[<EntryPoint>]
let main argv =

    // Define three sets with 5 elements each
    let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
    let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
    // Define an empty set
    let C = Set.empty

    // Print the sets defined above
    printfn "Set A: %A" A   //We print the three sets to make sure we have defined them as they are suposed to be
    printfn "Set B: %A" B
    printfn "Set C: %A\n" C

    // Membership function
    let pertenencia x=
        let p = Set.contains 1 A    //We define the containing variables to observe the function applied
        let p1 = not(Set.contains 1 A)
        let p2 = Set.contains 10 A
        let p3 = not(Set.contains 10 A)
        // Print the results
        printfn "MEMBERSHIP FUNCTION"
        printfn "%A" A
        printfn "%A" p
        printfn "%A" p1
        printfn "%A" p2
        printfn "%A\n" p3

    // Set convertion function
    let transformaConjunto x=
        printfn "SET CONVERTION"
        let a = [1; 2; 3]
        let cA = Set.ofList a //We convert the set "a" and assign it to a different variable
        printfn "The set A is: %A" cA
        let b = seq{1..5}
        let cB = Set.ofSeq b
        printfn "The set B is: %A\n" cB

    // Delete an element in the set
    let quitar x= 
        printfn "DELETE AN ELEMENT"
        let A = Set.empty.Add(0).Add(1).Add(2).Add(3).Add(4).Add(5)
        printfn "The set: %A" A
        let A = A.Remove 2  //We indicate that the element to remove is 2
        printfn "The set after deleting an element: %A\n" A
        
    // Remove all the elements
    let clearSet x=
         printfn"REMOVE ALL THE ELEMENTS"
         let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
         printfn "Set A = %A" A
         let A =Set.empty  // We refine the set adding no elements
         printfn "Set A al quitar los elementos:  %A\n" A


    // Copy a set
    let copiar x=
        printfn "COPY"
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(A) //Add set A to set B
        printfn "Set A= %A" A
        printfn "Set B= %A" B
        printfn "Comparar set B= %A\n" A
    
    // Add an element to the set
    let agregar x=
        let B = B.Add 987
        printfn"ADD AN ELEMENT"
        printfn "Set B= %A \n" B

    // SET OPERATIONS

    // Union
    let union x=
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        let AuB = Set.union A B
        printfn "UNION"
        printfn "Union between A and B: %A \n" AuB

    // Intersection
    let interseccion x=
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        let AnB = Set.intersect A B
        printfn"INTERSECTION"
        printfn "Intersection between A and B: %A \n" AnB

    // Difference
    let diferencia x=
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        let AdB = Set.difference A B
        let BdA = Set.difference B A
        printfn"DIFFERENCE"
        printfn "The differences between A and B: %A" AdB
        printfn "The differences between A and B: %A \n" BdA

    // Symetric difference
    let simetrica x=
        let A = Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let B = Set.empty.Add(3).Add(4).Add(5).Add(6).Add(7)
        let C = Set.empty
        let AdB = Set.difference A B + Set.difference B A // We add two differences to Adb set
        let BdA = Set.difference B A + Set.difference A B //And so we do for the next cases...
        let AdC = Set.difference A C + Set.difference C A
        let BdC = Set.difference B C + Set.difference B C
        printfn "SYMETRIC DIFFERENCE"
        printfn "La diferencia entre A y B es: %A" AdB
        printfn "La diferencia entre B y A es: %A" BdA
        printfn "La diferencia entre A y C es: %A" AdC
        printfn "La diferencia entre B y C es: %A \n" BdC

    // Subset
    let subconjunto x=
        let B = Set.empty.Add(0).Add(1).Add(2).Add(3).Add(4).Add(5).Add(6).Add(7).Add(8).Add(9)
        let A =Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let AsB = Set.isSubset A B      // Set.isSubset function returns a boolean value
        let BsA = Set.isSubset B A
        printfn "SUBSET"
        printfn "The A B subset %A" AsB
        printfn "The B A subset %A\n" BsA

    // Superset
    let superconjunto x=
        let B=Set.empty.Add(0).Add(1).Add(2).Add(3).Add(4).Add(5).Add(6).Add(7).Add(8).Add(9)
        let A=Set.empty.Add(1).Add(2).Add(3).Add(4).Add(5)
        let AsB=Set.isSuperset A B      // Set.isSuperset function returns a boolean value
        let BsA= Set.isSuperset B A
        printfn "SUPERSET"
        printfn "The A B superset %A" AsB
        printfn "The B A superset %A" BsA
    
    // To show the results to the functions above
    pertenencia()
    transformaConjunto()
    quitar()
    clearSet()
    copiar()
    agregar()
    union()
    interseccion()
    diferencia()
    simetrica()
    subconjunto()
    superconjunto() 
      
    0


// Coding ends here
