module Allergies

open System
open System.Reflection

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

let allergicTo (codedAllergies: int) (allergen: Allergen): bool =
     enum<Allergen>(codedAllergies).HasFlag(allergen)

let list (codedAllergies: int): Allergen list =    
    typeof<Allergen>
        .GetFields(BindingFlags.Public ||| BindingFlags.Static)
        |> Seq.map (fun fieldInfo -> fieldInfo.GetValue())
        |> Seq.cast<Allergen>
        |> Seq.filter (enum<Allergen>(codedAllergies).HasFlag)
        |> Seq.toList