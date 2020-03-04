namespace Busqueda

module IDFS =
    open DFSL

    let rec IDFS l problema =
        match Capitulo3.busquedaArbol problema (DFSL.estrategia l) with
        | Some n -> Some n
        | None -> IDFS (l-1) problema