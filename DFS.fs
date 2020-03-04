namespace Busqueda

module DFS =
    open Pila

    let estrategia<'s, 'a> =
        {
            Siguiente   = pop
            Agregar     = push
            Inicializar = push empty
        } : Estrategia<'s, 'a, Pila<Nodo<'s, 'a>>>
