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

let create (items: 'T list): Tree<'T> = failwith "You need to implement this function."

let sortedData (node: Tree<'T>): 'T list = failwith "You need to implement this function."