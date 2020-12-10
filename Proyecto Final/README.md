File name: TicTacToe.fs
Author: Edna Paola Castillo Jara
Programming language: F#
Universidad Politecnica de San Luis Potosi
Subject: Theory of Computation
Professor: Juan Carlos Gónzalez Ibarra

To begin with: Be sure to install Visual Studio, in order to be able to install it in your PC, you must be a Windows OS user, since Visual Studio is developed by Microsoft. Otherwise, you can use anothe IDE to run the file. Continuing with Visual Studio, go to the next link: https://visualstudio.microsoft.com/es/ and you shoul download the community 2019 package so it would be easier to access when it comes to licenses and permissions. You must have a Microsoft account to log in, on the contrary, you can register at the moment. Once you are done, you can open the file.


Code section:

// Coding begins here 
open System
type Letter = | X | O // Characters that can be in the cells of the board

type Value =
  | Unspecified // To set it to the cells of the empty board
  | Letter of Letter  // To fill in the cells once they have been selected 

type OneThroughThree = | One | Two | Three
type Row = Value*Value*Value
type Board = Row*Row*Row

let emptyBoard = //For the empty board
  (Unspecified, Unspecified, Unspecified), //This is the default behavior and is backward compatible. 
  (Unspecified, Unspecified, Unspecified),
  (Unspecified, Unspecified, Unspecified)

type Position = { //To convert the player input
  Column: OneThroughThree
  Row: OneThroughThree
}

type Move = {
  At: Position  // Player input that has to be converted 
  Place: Letter // Correspons to WhoseTurn
}

let select (board: Board) (position: Position) =  //to verify if the positition is empty
  match board, position with
    | ((x, _, _), _, _), { Row=One; Column=One } -> x
    | ((_, x, _), _, _), { Row=One; Column=Two } -> x
    | ((_, _, x), _, _), { Row=One; Column=Three } -> x
    | (_, (x, _, _), _), { Row=Two; Column=One } -> x
    | (_, (_, x, _), _), { Row=Two; Column=Two } -> x
    | (_, (_, _, x), _), { Row=Two; Column=Three } -> x
    | (_, _, (x, _, _)), { Row=Three; Column=One } -> x
    | (_, _, (_, x, _)), { Row=Three; Column=Two } -> x
    | (_, _, (_, _, x)), { Row=Three; Column=Three } -> x

let set value (board: Board) (position: Position) =
  match board, position with
   | ((_, v2, v3), r2, r3), { Row=One; Column=One } -> (value, v2, v3), r2, r3 // To assign the input once it has been verified
   | ((v1, _, v3), r2, r3), { Row=One; Column=Two } -> (v1, value, v3), r2, r3
   | ((v1, v2, _), r2, r3), { Row=One; Column=Three } -> (v1, v2, value), r2, r3
   | (r1, (_, v2, v3), r3), { Row=Two; Column=One } -> r1, (value, v2, v3), r3
   | (r1, (v1, _, v3), r3), { Row=Two; Column=Two } -> r1, (v1, value, v3), r3
   | (r1, (v1, v2, _), r3), { Row=Two; Column=Three } -> r1, (v1, v2, value), r3
   | (r1, r2, (_, v2, v3)), { Row=Three; Column=One } -> r1, r2, (value, v2, v3)
   | (r1, r2, (v1, _, v3)), { Row=Three; Column=Two } -> r1, r2, (v1, value, v3)
   | (r1, r2, (v1, v2, _)), { Row=Three; Column=Three } -> r1, r2, (v1, v2, value)

let modify f (board: Board) (position: Position) = // Function were the board is modified according to the two previous functions
  set (f (select board position)) board position

let placePieceIfCan piece = modify (function | Unspecified -> Letter piece | x -> x) // Modifies the "Unspecified" value to the cell if its possible (not occupied)

let makeMove (board: Board) (move: Move) = // Allows to make the move according to the previous function
  if select board move.At = Unspecified
  then Some <| placePieceIfCan move.Place board move.At
  else None

let waysToWin = // Possible combinations in which a player can win
  [
    { Row=One; Column=One }, { Row=One; Column=Two }, { Row=One; Column=Three } //  1, 2 and 3rd position.
    { Row=Two; Column=One }, { Row=Two; Column=Two }, { Row=Two; Column=Three }  //  4, 5 and 6th position.
    { Row=Three; Column=One }, { Row=Three; Column=Two }, { Row=Three; Column=Three } //  7, 8 and 9th position.

    { Row=One; Column=One }, { Row=Two; Column=One }, { Row=Three; Column=One } //  1, 4 and 7th position.
    { Row=One; Column=Two }, { Row=Two; Column=Two }, { Row=Three; Column=Two } //  2, 5 and 8th position.
    { Row=One; Column=Three }, { Row=Two; Column=Three }, { Row=Three; Column=Three }  //  3, 6 and 9th position

    { Row=One; Column=One }, { Row=Two; Column=Two }, { Row=Three; Column=Three }  //  1, 5 and 9rd position.
    { Row=One; Column=Three }, { Row=Two; Column=Two }, { Row=Three; Column=One }  //  3, 5 and 7th position.
  ]

let cells =
  List.ofSeq <|
    seq {
      for row in [One; Two; Three] do // Goes thorugh the row
      for column in [One; Two; Three] do // Goes through the column
      yield { Row=row; Column=column }  //yield adds a single item into the sequence being built (similar to the "return" statement).
    }

let ``map 3`` f (a, b, c) = f a, f b, f c // To verify if the 3-in-line characters matches to the "X" or the "O" in one of the 8 combinations above

let winner (board: Board) = //when the winner is determined
  let winPaths = List.map (``map 3`` (select board)) waysToWin //it is compared with one of the ways to win

  if List.contains (Letter X, Letter X, Letter X) winPaths // If the winning path contains only "X" then the winner is the machine
  then Some X
  else if List.contains (Letter O, Letter O, Letter O) winPaths  // // If the winning path contains only "O" then the winner is the user
  then Some O
  else None // Otherwise, if all the cells are ocuppied, then it is called a Draw

let slotsRemaining (board: Board) = //if there are cells left
  List.exists ((=) Unspecified << select board) cells // Unespecified is assigned to every cell left

type Outcome = // Function to determine the result
  | NoneYet //Not a winner yet
  | Winner of Letter //Winner and the letter of the winner
  | Draw // Not a winner at all

let outcome (board: Board) = // For the board
  match winner board, slotsRemaining board with
    | Some winningLetter, _ -> Winner winningLetter
    | None, false -> Draw  //previous yield result
    | _ -> NoneYet

let renderValue = function // Sets the player's turn
  | Unspecified -> " "
  | Letter X -> "X"
  | Letter O -> "O"

let otherPlayer = function // Goes from one player's turn to another
  | X -> O
  | O -> X

let render ((a, b, c), (d, e, f), (g, h, i)) =  // Every cell is a letter
  Console.ForegroundColor<-ConsoleColor.Blue  //cambia el color a azul
  sprintf
    """
   %s | %s | %s
  -----------
   %s | %s | %s
  -----------
   %s | %s | %s"""
    (renderValue a) (renderValue b) (renderValue c) //Prints the X or O in its cell
    (renderValue d) (renderValue e) (renderValue f)
    (renderValue g) (renderValue h) (renderValue i)

type GameState = { Board: Board; WhoseTurn: Letter }

// GAME START
let initialGameState = { Board=emptyBoard; WhoseTurn=X } //Prints the empty board and gives the first turn to the X (computer)

let parseOneThroughThree = function // Converts the numeric input to a letter in order to make the cell selection
  | "1" -> Some One
  | "2" -> Some Two
  | "3" -> Some Three
  | _ -> None

let parseMove (raw: string) =
  match raw.Split [|' '|] with // omitts the blank space in the input and cuts the string
    | [|r; c|] -> //Receives row and then column
      match parseOneThroughThree r, parseOneThroughThree c with // Parses the 1, 2 or 3
        | Some row, Some column -> Some { Row=row; Column=column } // Assings the number to each variable (row and column)
        | _ -> None
    | _ -> None

type Effects = { // Complement to the parse function
  PlaceLetter: Letter -> string
  PrintLine: string -> unit
}


// FOR THE MINIMAX ALGORITHM APPLICATION
//Minimax is a kind of backtracking algorithm that is used in decision making and game theory to find the optimal
//move for a player, assuming that your opponent also plays optimally.

type Io<'a> = Effects -> 'a // 'a and 'b are pointers

let (>>=) (io: Io<'a>) (f: 'a -> Io<'b>): Io<'b> =
  fun eff -> f (io eff) eff

let placeLetter letter eff = eff.PlaceLetter letter

let printLine text eff = eff.PrintLine text

let pureIo v _ = v

        // Execution of all of the functions showed above
let rec readMoveIo letter =
  placeLetter letter >>= fun line ->
  match parseMove line with
    | Some position ->
      pureIo { At=position; Place=letter }
    | None ->
      printLine "Por favor, ingresa el número de fila y columna correctamente" >>= fun () ->
      readMoveIo letter

let rec nextMoveIo board letter =
  readMoveIo letter >>= fun move ->
  match makeMove board move with
    | Some newBoard -> pureIo newBoard
    | _ ->
      printLine "Casilla ocupada, ingresa otra posición" >>= fun () ->
      nextMoveIo board letter

let rec playIo { Board=board; WhoseTurn=currentPlayer } =
  printLine (sprintf "%A turn" currentPlayer) >>= fun () ->
  printLine (sprintf "%s" (render board)) >>= fun () ->

  printLine "" >>= fun () ->
  nextMoveIo board currentPlayer >>= fun newBoard ->
  printLine "" >>= fun () ->

  match outcome newBoard with
    | Winner letter ->
      printLine (sprintf "%A h ganado" letter) >>= fun () ->
      printLine (sprintf "%s" (render newBoard))
    | Draw ->
      printLine "Es un empate"
    | NoneYet ->
      playIo { Board=newBoard; WhoseTurn=otherPlayer currentPlayer }

let rand s e =
  System.Random(System.DateTime.Now.Millisecond).Next(s, e)  // Establishes the time the computer will take to make a move

let easyAiVHuman = function
  | X -> sprintf "%d %d" (rand 1 4) (rand 1 4)  // Generates random position between 1 and 3 for rows and columns
  | O -> System.Console.ReadLine ()  // Gets the player input for row and column

let consoleAi = { PlaceLetter=easyAiVHuman; PrintLine=printfn "%s" }

playIo initialGameState consoleAi // Call to the function of the GAME START


//CODING ENDS HERE
