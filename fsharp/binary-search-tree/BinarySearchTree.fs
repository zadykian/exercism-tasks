module BinarySearchTree

/// Representation of binary search tree.
type Tree<'T> when 'T :> System.IComparable<'T> =
    {
        Value: 'T
        Left:  Tree<'T> option
        Right: Tree<'T> option
    }

let left (node: Tree<'T>): Tree<'T> option = failwith "You need to implement this function."

let right (node: Tree<'T>): Tree<'T> option = failwith "You need to implement this function."

let data (node: Tree<'T>): 'T = failwith "You need to implement this function."

let create (items: 'T list): Tree<'T> = failwith "You need to implement this function."

let sortedData (node: Tree<'T>): 'T list = failwith "You need to implement this function."