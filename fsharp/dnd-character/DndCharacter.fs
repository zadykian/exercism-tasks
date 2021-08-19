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

let modifier x =
    failwith "You need to implement this function."

let ability () = 
    failwith "You need to implement this function."

let createCharacter () : Character =
    failwith "You need to implement this function."
