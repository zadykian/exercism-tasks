module BinarySearchTree

/// Representation of binary search tree.
type Tree<'T> when 'T :> System.IComparable<'T> =
    {
        Data: 'T
        Left:  Tree<'T> option
        Right: Tree<'T> option
    }

let left (node: Tree<'T>): Tree<'T> option = node.Left

let right (node: Tree<'T>): Tree<'T> option = node.Right

let data (node: Tree<'T>): 'T = node.Data

/// Add item to tree
let private add (tree: Tree<'T>) (item: 'T) : Tree<'T> = failwith "not implemented!"

let create (items: 'T list): Tree<'T> =
    match items with
    | head :: tail -> tail |> Seq.fold add { Data = head; Left = None; Right = None }
    | _            -> invalidArg (nameof items) "list cannot be empty!"

let sortedData (node: Tree<'T>): 'T list = failwith "You need to implement this function."