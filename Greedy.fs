namespace Busqueda

module Greedy =
    open ColaPrioritaria

    let key h = fun n -> (h n, n.Estado)

    let estrategia<'s, 'a when 's : comparison> h =
        {
            Siguiente   = dequeue
            Agregar     = enqueue (key h)
            Inicializar = enqueue (key h) empty
        } : Estrategia<'s, 'a, Map<float * 's, Nodo<'s, 'a>>>
