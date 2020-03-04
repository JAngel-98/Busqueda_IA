namespace Busqueda

module BFS =
    open Cola

    let estrategia<'s, 'a> =
        {
            Siguiente   = dequeue
            Agregar     = enqueue
            Inicializar = enqueue empty
        } : Estrategia<'s, 'a, Cola<Nodo<'s, 'a>>>
