namespace Busqueda

module Astar =
    open ColaPrioritaria

    let key h = fun n -> (n.Costo_Ruta + h n, n.Estado)

    let estrategia<'s, 'a when 's : comparison> h =
        {
            Siguiente   = dequeue
            Agregar     = enqueue (key h)
            Inicializar = enqueue (key h) empty
        } : Estrategia<'s, 'a, Map<float * 's, Nodo<'s, 'a>>>
