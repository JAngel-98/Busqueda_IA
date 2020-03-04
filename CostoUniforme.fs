namespace Busqueda

module CotoUniforme =
    open ColaPrioritaria

    let key = (fun n -> n.Costo_Ruta, n.Estado)
    let estrategia<'s, 'a when 's : comparison> =
        {
            Siguiente   = dequeue
            Agregar     = enqueue key
            Inicializar = enqueue key empty
        } : Estrategia<'s, 'a, Map<float * 's, Nodo<'s, 'a>>>
