namespace Busqueda

type Cola<'a> = list<'a> * list<'a>

module Cola =
    let empty = [], []

    let enqueue (entrada, salida) x = (x::entrada, salida)
    
    let rec dequeue (entrada, salida) = 
        match salida with
        | x :: salida -> Some(x, (entrada, salida))
        | _ -> match entrada with
               | _::_ -> dequeue ([], List.rev entrada)
               | _ -> None