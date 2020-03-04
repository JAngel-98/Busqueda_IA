namespace  Busqueda.Ejemplos

module Aspiradora =
    open Busqueda
    
    type Lugar = | A | B
    type Casillas = bool * bool
    type estado = Casillas * Lugar

    type acciones =
        | Left
        | Right
        | Suck
        | NoOp
    
    let inicio = (true, true), A

    let meta = function
        | (false, false), _ -> true
        | _ -> false

    let sucesores = function
        | (a, b), A -> [(Left, ((a, b), A))
                        (Right, ((a, b), B))
                        (NoOp, ((a, b), A))
                        (Suck, ((false, b), A))]
        | (a, b), B -> [(Left, ((a, b), A))
                        (Right, ((a, b), B))
                        (NoOp, ((a, b), B))
                        (Suck, ((a, false), B))]

    let costo _ a _ =
        match a with
            | NoOp -> 0.0
            | _ -> 1.0
    
    let prueba estrategia =
        let problema =
            {
                Inicio = inicio
                Meta = meta
                Sucesores = sucesores
                Costo = costo
            }
        Busqueda.Capitulo3.busquedaArbol problema estrategia