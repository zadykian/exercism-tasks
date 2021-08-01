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

/// Create single-node tree from item.
let private fromItem (item: 'T): Tree<'T> = { Data = item; Left = None; Right = None }

/// Add item to tree.
let rec private add (tree: Tree<'T>) (item: 'T) : Tree<'T> =

    /// Handle tree's subtree by either calling add function recursively
    /// or creating new node. 
    let handleSubtree (subtreeOption: Tree<'T> option): Tree<'T> option =
        match subtreeOption with
        | Some subtree -> Some (add subtree item)
        | None         -> Some (fromItem item)

    if tree.Data.CompareTo item >= 0
    then { tree with Left  = handleSubtree tree.Left  }
    else { tree with Right = handleSubtree tree.Right }

/// Create tree from list of elements.
let create (items: 'T list): Tree<'T> =
    match items with
    | head :: tail -> tail |> Seq.fold add (fromItem head)
    | _            -> invalidArg (nameof items) "list cannot be empty!"

let sortedData (node: Tree<'T>): 'T list = failwith "You need to implement this function."