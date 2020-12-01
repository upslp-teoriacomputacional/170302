Title: TuringMachine.fs Programming Language: F\# Authors: Edna Paola
Castillo Jara 170302 Subject: Theory of Computation Professor: Juan
Carlos Gónzalez Ibarra Universidad Politecnica de San Luis Potosi

To begin with: Be sure to install Visual Studio, in order to be able to
install it in your PC, you must be a Windows OS user, since Visual
Studio is developed by Microsoft. Otherwise, you can use anothe IDE to
run the file. Continuing with Visual Studio, go to the next link:
https://visualstudio.microsoft.com/es/ and you shoul download the
community 2019 package so it would be easier to acces when it comes to
licenses and permissions. You must have a Microsoft account to log in,
on the contrary, you can register at the moment. Once you are done, you
can open the file.

Q = Es un conjunto de estados
    Σ = Alfabeto conjunto de caracteres (codigo utf-8 ="\u03A3")	
    Γ = Simbolos de la cinta
    s = Estado inicial sϵQ
    δ= Reglas nde transicion (Codigo utf-8 = "\u03B4")
    QxΣ->Q Reglas de transicion
    bϵΓ = es un simbolo denominado blanco, que se puede repetir 
          infinitamente en toda la cinta 
    F⊆Q Estado finales o de aceptacion
    
    Q = {s,q1}
    Σ = {a}	
    Γ = {a,b}
    s = Estado inicial q0ϵQ
    δ= Reglas de transicion 
    Reglas de transicion
    Q x Σ -> Q
    ((q0,a)->q1*)
    (estado, valor) -> nuevo estado, nuevo valor, dirección)
    (s,a)->q1,b,right
    (q1,b)->--Valido--
    "si estamos en el estado s leyendo la posición q1, donde hay 
    escrito el símbolo 'a', entonces este símbolo debe ser reemplazado 
    por el símbolo 'b', y pasar a leer la celda siguiente, a la derecha".
    F⊆Q = {q1}
    
    Estructura gafica es un grafo dirigido que se conecta en los vertices 
    con:
        (lee el cabezal/
        símbolo que escribirá el cabezal, 
        movimiento del cabezal.)
        (s,a)->q1,b,right
        ('a',b,right)

// CODING BEGINS HERE open System open System.Text.RegularExpressions //
Library needed to use Regex class

[<EntryPoint>] let main argv =

    let Source_code = "int result = 1;".Split(' ')  // Turning source code "int result = 1;"  into a list of words
    let mutable tokens = []    // For string tokens
      
    for i in Source_code do  // Loop through each source code word, we use "i" as a counter to evaluate in every case below

        // This will check if a token has datatype declaration
        if (i.Equals("str") || i.Equals("int") || i.Equals("bool")) 
        then    //If the "source_code" variable is wether a string, an integer value or a boolean, then 
            tokens <- List.append tokens ["DATATYPE", i] // We can use List.append to combine two lists together
        
        
        
        // This will look for an identifier which would be just a word
        elif (Regex.IsMatch (i, "[a-z]") || Regex.IsMatch (i, "[A-Z]")) // If it matches as a regular expression,
        then
            tokens <- List.append tokens ["IDENTIFIER", i] // We can use List.append to combine two lists together


        // This will look for an operator
        elif (Regex.IsMatch(i, "(\+|\-|\*|\/|\%|\=)" )) // Matches if there is an operator with the "i" parameter
        then 
            tokens <- List.append tokens ["OPERATOR", i] // We can use List.append to combine two lists together


        // This will look for integer items and cast them as a number


    printfn "%A" tokens  // This will print the list named as Tokens in the beginning in which results have been added
    0 // return an integer exit code
