Title: TuringMachine.fs 
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

// CODING BEGINS HERE 

open System
 open System.Collections.Generic // Contains interfaces and classes that define generic collections, which allow to create strongly typed collections
 exception Error of string  // To print the error message

 let turing_M (state,blank,rules:list<list<string>>,tape:list<string>,final,pos) =
     //variables que cambian su valor
     let mutable state=state // turing machine states
     let mutable pos=pos // next position of the machine
     let mutable tape=tape //
     
     if tape.IsEmpty then //if the tape is empty we set it in blank
         tape<-[blank]     
     if pos<0 then // if position is less than 0 we add the size of the tape
         pos<-pos+tape.Length     
     if pos>=tape.Length || pos<0 then //it cant be more than the size of the tape
         raise(Error("Se inicializa mal la posición")) // so we print an error
 
     //rules = dict(((s0, v0), (v1, dr, s1)) for  (s0, v0, v1, dr, s1) in rules)

     let mutable aux=true
     while aux do
         let mutable direc=""
         let mutable s1=""
         let mutable v1=""
 
         printf"%A\t"state //print the state
         for i=0 to tape.Length-1 do //loop to print the tape
             if i.Equals(pos) then
                 printf "[%A] " tape.[i]
             else
                 printf " %A  " tape.[i]
         printfn " "
         if state.Equals(final)then
             aux<-false
         let mutable NO:bool=true  //to verify if theres actually an element
         for r in rules do
             if state.Equals(r.[0]) && tape.[pos].Equals(r.[1])then
                 NO<-false
                 direc<-r.[3]
                 s1<-r.[4]
                 v1<-r.[2]

         if NO then
             aux<-false
         let mutable cintaxu=[] //auxiliary tape

         for i=0 to tape.Length-1 do  //go through the tape so we can rewrite it
             if i.Equals(pos)then
                 cintaxu<-cintaxu @ [v1] //coloca el nuevo valor
             else
                 cintaxu<-cintaxu @ [tape.[i]]//si no es igual a la posición se coloca el que ya estaba
         tape<-cintaxu//lo agrega a la cinta ya existente
         
         if direc.Equals("left")then
             if pos>0 then // if position is more than 0
                 pos<-pos-1 //we reduce it in 1
             else //if is less than 0
                  tape <- [blank] @ tape // we set it a blank at the begining
         if direc.Equals("right")then
             pos<-pos+1
             if pos >= tape.Length then
                 tape <- tape @ [blank] // we set it a blank at the end
         state<-s1
 
 
 
 [<EntryPoint>]
 let main argv =
     // transicion rules
     let rules = [   
                 ["s1";"1";"b";"right";"s2"];
                 ["s2";"1";"1";"right";"s2"];
                 ["s2";"b";"b";"right";"s3"];
                 ["s3";"1";"1";"right";"s3"];
                 ["s3";"b";"1";"left";"s4"];
                 ["s4";"1";"1";"left";"s4"];
                 ["s4";"b";"b";"left";"s5"];
                 ["s5";"1";"1";"left";"s5"];
                 ["s5";"b";"1";"right";"s6"];
                  ]
 
     printfn "machine turing test"
     turing_M ("s1","b",rules,["1";"1";"1";"/";"1";"1"],"s12",0) // Call to the function in order to execute the coding
     0 // return an integer exit code


//CODING ENDS HERE
