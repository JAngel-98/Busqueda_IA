namespace Busqueda

type ColaPrioritaria<'d,'c when 'd : comparison> = 
    Map<'d, 'c>

module ColaPrioritaria =
    let empty = Map.empty

    let enqueue key cola x = Map.add (key x) x cola
    
    let dequeue cola = 
        match Map.tryFindKey (fun _ _  -> true) cola with
        | Some k -> Some(Map.find k cola, Map.remove k cola)
        | None -> None