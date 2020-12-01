// 170302-TuringMachine.fs
// Programming language: F#

(* Student: Edna Paola Castillo Jara 170302
  Universidad Politecnica de San Luis Potosi*)

(* Subject: Theory of Computation
  Professor: Juan Carlos Gónzalez Ibarra
 *)

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