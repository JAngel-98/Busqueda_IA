namespace Busqueda

module DFSL =
    open Pila

    let estrategia<'s, 'a> l =
        {
            Siguiente   = pop
            Agregar     = fun pila x ->
                            if x.Profundidad <= l
                            then push pila x
                            else pila
            Inicializar = push empty
        } : Estrategia<'s, 'a, Pila<Nodo<'s, 'a>>>
