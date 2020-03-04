// Learn more about F# at http://fsharp.org

open System
open Busqueda
open Busqueda.Ejemplos

(*let rec fact = function
    | 0 -> 1
    | n -> n * fact(n-1)

let rec power = function
    | (_, 0) -> 1.0
    | (x, n) -> x * power(x, n - 1)
*)

[<EntryPoint>]
let main argv =
    //printfn "3!: %i" (fact 3)
    //printfn "power (3,2): %f" (power (3.0, 2))
    //printfn "length: %i" (List.length [1;2;3;4;5])
    //printfn "map: %A" (List.map (fun x -> x * x) [1;2;3;4;5])
    //printfn "map: %A" (List.map (fun x -> string x) [1;2;3;4;5])
    //printfn "fold: %A" (List.fold (fun x y -> x + y) 0 [1;2;3;4;5])
    //printfn "fold: %A" (List.fold ( + ) 0 [1;2;3;4;5])
    
    //let res = Aspiradora.prueba BFS.estrategia
    //printfn "Resultado %A" res
    
    (*match Aspiradora.prueba BFS.estrategia with
        | Some n -> printfn "Resultado %A" (Capitulo3.acciones n)
        | None -> printfn "No op"*)

    match Puzzle.prueba BFS.estrategia with
        | Some n -> printfn "Resultado %A" (Capitulo3.acciones n)
        | None -> printfn "No op"

    0 // return an integer exit code
