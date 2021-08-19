module DndCharacter

open System

type Character =
    {
        Strength     : int
        Dexterity    : int
        Constitution : int
        Intelligence : int
        Wisdom       : int
        Charisma     : int
        Hitpoints    : int
    }

let modifier (constitution: int) =
    constitution - 10
    |> float
    |> fun value -> Math.Round(value / float 2, MidpointRounding.ToNegativeInfinity)
    |> int

let private random = Random ()

let ability () = random.Next(3, 18)

let createCharacter () : Character =
    let constitution = ability ()

    {
        Strength     = ability ()
        Dexterity    = ability ()
        Constitution = constitution
        Intelligence = ability ()
        Wisdom       = ability ()
        Charisma     = ability ()
        Hitpoints    = 10 + modifier constitution
    }
