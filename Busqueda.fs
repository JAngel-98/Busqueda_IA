namespace Busqueda

(*
type Option <'a> = 
    | Some of 'a
    | None
*)

type Nodo<'s,'a> = 
    {
        Profundidad : int
        Costo_Ruta  : float
        Estado      : 's
        Padre       : Nodo<'s,'a> option
        Accion      : 'a option
    }

type Problema<'s,'a> =
    {
        Inicio      : 's
        Meta        : 's -> bool
        Sucesores   : 's -> list<'a * 's>
        Costo       : 's -> 'a -> 's -> float
    }

type Estrategia<'s,'a,'b> =
    {
        Siguiente   : 'b -> (Nodo<'s,'a> * 'b) option
        Agregar     : 'b -> Nodo<'s,'a> -> 'b
        Inicializar : Nodo<'s,'a> -> 'b
    }

type Estadistica =
    {
        Nodos_Generados     : uint64
        Nodos_Procesados    : uint64
    }

module Capitulo3 =
    let expand padre problema =
        problema.Sucesores padre.Estado
        |> List.map (fun (accion, estado) ->
        {
            Estado = estado
            Padre = Some padre
            Profundidad = padre.Profundidad + 1
            Accion = Some accion
            Costo_Ruta = padre.Costo_Ruta + problema.Costo padre.Estado accion estado
        })
    
    let busquedaArbol problema estrategia =
        let nodo_inicial =
            {
                Estado      = problema.Inicio
                Padre       = None
                Profundidad = 0
                Costo_Ruta  = 0.0
                Accion      = None
            }
        let bolsa = estrategia.Inicializar nodo_inicial
        let rec loop bolsa =
            match estrategia.Siguiente bolsa with
            | Some (s, bolsa) ->
                if problema.Meta s.Estado
                    then Some s
                else expand s problema
                    |> List.fold estrategia.Agregar bolsa
                    |> loop
            | None -> None
        loop bolsa

    let busquedaGrafo id problema estrategia =
        let nodo_inicial =
            {
                Estado      = problema.Inicio
                Padre       = None
                Profundidad = 0
                Costo_Ruta  = 0.0
                Accion      = None
            }
        let bolsa = estrategia.Inicializar nodo_inicial
        let rec loop (procesados, bolsa) =
            match estrategia.Siguiente bolsa with
            | Some (s, bolsa) ->
                if problema.Meta s.Estado
                then Some s
                else if Set.contains (id s) procesados
                     then loop (procesados, bolsa)
                     else expand s problema
                          |> List.fold estrategia.Agregar bolsa
                          |> (fun bolsa -> loop (Set.add (id s) procesados, bolsa)) //loop (Set.add (id s) procesados)
            | None -> None
        loop (Set.empty, bolsa)


    let rec acciones nodo =
        match nodo.Padre with
            | Some padre -> acciones padre @ [Option.get nodo.Accion]
            | None _ -> []