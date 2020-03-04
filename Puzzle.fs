namespace Busqueda.Ejemplos

module Puzzle =
    open Busqueda
    type estado = int * int * int * int * int * int * int * int * int
    type action =
        | Left
        | Right
        | Up
        | Down

    let inicio = (7, 2, 4,
                  5, 0, 6,
                  8, 3, 1)

(*    let inicio = (1, 2, 3,
                  4, 0, 6,
                  7, 5, 8) *)

    let meta estado =
        estado = (1, 2, 3,
                  4, 5, 6,
                  7, 8, 0)

    let costo _ _ _ = 1.0

    let sucesores = function
        | (0,x2,x3,x4,x5,x6,x7,x8,x9) ->
            [Right, (x2,0,x3,x4,x5,x6,x7,x8,x9)
             Down, (x4,x2,x3,0,x5,x6,x7,x8,x9)]
        | (x1,0,x3,x4,x5,x6,x7,x8,x9) ->
            [Left, (0,x1,x3,x4,x5,x6,x7,x8,x9)
             Right, (x1,x3,0,x4,x5,x6,x7,x8,x9)
             Down, (x1,x5,x3,x4,0,x6,x7,x8,x9)]
        | (x1,x2,0,x4,x5,x6,x7,x8,x9) ->
            [Left, (x1,0,x2,x4,x5,x6,x7,x8,x9)
             Down, (x1,x2,x6,x4,x5,0,x7,x8,x9)]
        | (x1,x2,x3,0,x5,x6,x7,x8,x9) ->
            [Right, (x1,x2,x3,x5,0,x6,x7,x8,x9)
             Down, (x1,x2,x3,x7,x5,x6,0,x8,x9)
             Up, (0,x2,x3,x1,x5,x6,x7,x8,x9)]
        | (x1,x2,x3,x4,0,x6,x7,x8,x9) ->
            [Right, (x1,x2,x3,x4,x6,0,x7,x8,x9)
             Left, (x1,x2,x3,0,x4,x6,x7,x8,x9)
             Down, (x1,x2,x3,x4,x8,x6,x7,0,x9)
             Up, (x1,0,x3,x4,x2,x6,x7,x8,x9)]
        | (x1,x2,x3,x4,x5,0,x7,x8,x9) ->
            [Left, (x1,x2,x3,x4,0,x5,x7,x8,x9)
             Down, (x1,x2,x3,x4,x5,x9,x7,x8,0)
             Up, (x1,x2,0,x4,x5,x3,x7,x8,x9)]
        | (x1,x2,x3,x4,x5,x6,0,x8,x9) ->
            [Right, (x1,x2,x3,x4,x5,x6,x8,0,x9)
             Up, (x1,x2,x3,0,x5,x6,x4,x8,x9)]
        | (x1,x2,x3,x4,x5,x6,x7,0,x9) ->
            [Right, (x1,x2,x3,x4,x5,x6,x7,x9,0)
             Left, (x1,x2,x3,x4,x5,x6,0,x7,x9)
             Up, (x1,x2,x3,x4,0,x6,x7,x5,x9)]
        | (x1,x2,x3,x4,x5,x6,x7,x8,0) ->
            [Left, (x1,x2,x3,x4,x5,x6,x7,0,x8)
             Up, (x1,x2,x3,x4,x5,0,x7,x8,x6)]
        | _ -> failwith "Error imposible!"

    let prueba estrategia =
        let problema =
            {
                Inicio = inicio
                Meta = meta
                Sucesores = sucesores
                Costo = costo
            }
        //Busqueda.Capitulo3.busquedaArbol problema estrategia
        Busqueda.Capitulo3.busquedaGrafo (fun n -> n.Estado) problema estrategia
