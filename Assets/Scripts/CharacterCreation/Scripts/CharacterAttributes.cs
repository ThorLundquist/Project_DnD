using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public enum BaseAttributes
    {
        Strength,
        Constitution,
        Dexterity,
        Intelligence,
        Wisdom,
        Charisma
    };

    public enum BaseModifiers
    {
        Strength,
        Constitution,
        Dexterity,
        Intelligence,
        Wisdom,
        Charisma
    }

    public enum BaseRacials
    {
        Strength,
        Constitution,
        Dexterity,
        Intelligence,
        Wisdom,
        Charisma
    }

    public enum Races
    {
        Dwarf,
        Elf,
        Halfling,
        Human,
        Dragonborn,
        Gnome,
        Half_Elf,
        Half_Orc,
        Tiefling
    };

    public enum Classes
    {
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    };
}
