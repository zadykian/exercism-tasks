module Allergies

open System

[<Flags>]
type Allergen =
    | Eggs = 1
    | Peanuts = 2
    | Shellfish = 4
    | Strawberries = 8
    | Tomatoes = 16
    | Chocolate = 32
    | Pollen = 64
    | Cats = 128

let allergicTo (codedAllergies: int) (allergen: Allergen): bool = failwith "You need to implement this function."

let list (codedAllergies: int): Allergen list = failwith "You need to implement this function."