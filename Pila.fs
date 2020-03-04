namespace Busqueda

type Pila<'a> = list<'a>

module Pila =
    let empty = []

    let push pila x = x :: pila

    let pop pila =
        match pila with
        | x :: xs -> Some(x, xs)
        | [] -> None
        