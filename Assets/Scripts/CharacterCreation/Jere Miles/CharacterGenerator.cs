using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public List<Sprite> portraitList;
    public Sprite myPortrait;

    public CharacterAttributes.Races myRace;
    public CharacterAttributes.Classes myClass;

    public Dictionary<CharacterAttributes.BaseAttributes, int> myAttributes;
    public Dictionary<CharacterAttributes.BaseRacials, int> myRacials;
    public Dictionary<CharacterAttributes.BaseModifiers, int> myMods;

    public bool isMale = true;

    int myHP;
    readonly int baseValue = 10;
    readonly int baseRacial = 0;



    public void InitializeCharacterGenerator()
    {
        Debug.Log("InitializeCharacterGenerator() called");

        myAttributes = new Dictionary<CharacterAttributes.BaseAttributes, int>();
        myRacials = new Dictionary<CharacterAttributes.BaseRacials, int>();
        myMods = new Dictionary<CharacterAttributes.BaseModifiers, int>();
        //Initialitisere all vores Attributter til en start værdi
        InitializeAttributes();

        //Sæt initial race
        myRace = CharacterAttributes.Races.Human;

        //Sæt initial class
        myClass = CharacterAttributes.Classes.Fighter;

        //Sæt default portræt
        portraitList = GetComponent<PortraitScriptable>().mHuman;
        myPortrait = portraitList[0];
    }

    void InitializeAttributes()
    {
        foreach (CharacterAttributes.BaseAttributes thisAttribute in System.Enum.GetValues(typeof(CharacterAttributes.BaseAttributes)))
        {
            if (myAttributes.ContainsKey(thisAttribute))
            {
                myAttributes[thisAttribute] = baseValue;
            }
            else
            {
                myAttributes.Add(thisAttribute, baseValue);
            }
        }

        foreach (CharacterAttributes.BaseRacials thisRacial in System.Enum.GetValues(typeof(CharacterAttributes.BaseRacials)))
        {
            if (myRacials.ContainsKey(thisRacial))
            {
                myRacials[thisRacial] = baseRacial;
            }
            else
            {
                myRacials.Add(thisRacial, baseRacial);
            }
        }
    }

    public void CheckRace()
    {
        Debug.Log("CheckRace called");
        InitializeAttributes();
        switch (myRace)
        {
            case CharacterAttributes.Races.Dwarf:
                Debug.Log("Case Dwarf");
                myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 2;
                myRacials[CharacterAttributes.BaseRacials.Constitution] += 2;

                portraitList = GetComponent<PortraitScriptable>().mDwarf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fDwarf;
                }
                break;
            case CharacterAttributes.Races.Elf:
                Debug.Log("Case elf");
                myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 2;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] += 2;

                portraitList = GetComponent<PortraitScriptable>().mElf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fElf;
                }
                break;
            case CharacterAttributes.Races.Halfling:
                Debug.Log("Case Halfling");
                myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 2;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] += 2;

                portraitList = GetComponent<PortraitScriptable>().mHalfling;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalfling;
                }
                break;
            case CharacterAttributes.Races.Human:
                Debug.Log("Case Human");
                myAttributes[CharacterAttributes.BaseAttributes.Strength] += 1;
                myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;
                myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;
                myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
                myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += 1;
                myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;

                myRacials[CharacterAttributes.BaseRacials.Strength] += 1;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] += 1;
                myRacials[CharacterAttributes.BaseRacials.Constitution] += 1;
                myRacials[CharacterAttributes.BaseRacials.Intelligence] += 1;
                myRacials[CharacterAttributes.BaseRacials.Wisdom] += 1;
                myRacials[CharacterAttributes.BaseRacials.Charisma] += 1;


                portraitList = GetComponent<PortraitScriptable>().mHuman;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHuman;
                }
                break;
            case CharacterAttributes.Races.Dragonborn:
                Debug.Log("Case Dragonborn");
                myAttributes[CharacterAttributes.BaseAttributes.Strength] += 2;
                myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;

                myRacials[CharacterAttributes.BaseRacials.Strength] += 2;
                myRacials[CharacterAttributes.BaseRacials.Charisma] += 1;

                portraitList = GetComponent<PortraitScriptable>().mDragonborn;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fDragonborn;
                }
                break;
            case CharacterAttributes.Races.Gnome:
                Debug.Log("Case Gnome");
                myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 2;

                myRacials[CharacterAttributes.BaseRacials.Intelligence] += 2;

                portraitList = GetComponent<PortraitScriptable>().mGnome;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fGnome;
                }
                break;
            case CharacterAttributes.Races.Half_Elf:
                Debug.Log("Half Elf");
                myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 2;
                myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
                myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;

                myRacials[CharacterAttributes.BaseRacials.Charisma] += 2;
                myRacials[CharacterAttributes.BaseRacials.Intelligence] += 1;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] += 1;

                portraitList = GetComponent<PortraitScriptable>().mHalf_Elf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalf_Elf;
                }
                break;
            case CharacterAttributes.Races.Half_Orc:
                Debug.Log("Case Half Orc");
                myAttributes[CharacterAttributes.BaseAttributes.Strength] += 2;
                myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;

                myRacials[CharacterAttributes.BaseRacials.Strength] += 2;
                myRacials[CharacterAttributes.BaseRacials.Constitution] += 1;

                portraitList = GetComponent<PortraitScriptable>().mHalf_Orc;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalf_Orc;
                }
                break;
            case CharacterAttributes.Races.Tiefling:
                Debug.Log("Tiefling");
                myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
                myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 2;

                myRacials[CharacterAttributes.BaseRacials.Intelligence] += 1;
                myRacials[CharacterAttributes.BaseRacials.Charisma] += 2;
                portraitList = GetComponent<PortraitScriptable>().mTiefling;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fTiefling;
                }
                break;
            default:
                Debug.Log("Error - Race not found");
                break;
        }

        //Opdater portræt til default i den nye List
        myPortrait = portraitList[0];
    }

    public void ChangeRace(bool goNext)
    {
        Debug.Log("ChangeRace() called");
        bool foundIt = false;
        if (goNext)
        {
            Debug.Log("ChangeRace() if");
            foreach (CharacterAttributes.Races thisRace in System.Enum.GetValues(typeof(CharacterAttributes.Races)))
            {
                if (foundIt)
                {
                    myRace = thisRace;
                    foundIt = false;
                    break;
                }
                else if (myRace == thisRace)
                {
                    foundIt = true;
                }
            }
            if (foundIt)
            {
                myRace = 0;
            }

        }

        else
        {
            Debug.Log("ChangeRace() Else");
            int lastValue = System.Enum.GetValues(typeof(CharacterAttributes.Races)).Length - 1;
            CharacterAttributes.Races lastRace = (CharacterAttributes.Races)lastValue;

            foreach (CharacterAttributes.Races thisRace in System.Enum.GetValues(typeof(CharacterAttributes.Races)))
            {
                if (myRace == thisRace)
                {
                    myRace = lastRace;
                    break;
                }
                lastRace = thisRace;
            }

        }
    }

    public void ChangeClass(bool goNext)
    {
        Debug.Log("ChangeClass() called");
        bool foundIt = false;
        if (goNext)
        {

            foreach (CharacterAttributes.Classes thisClass in System.Enum.GetValues(typeof(CharacterAttributes.Classes)))
            {
                if (foundIt)
                {
                    foundIt = false;
                    myClass = thisClass;
                    break;
                }
                else if (myClass == thisClass)
                {
                    foundIt = true;
                }
            }
            if (foundIt)
            {
                myClass = 0;
            }
        }

        else
        {
            int lastValue = System.Enum.GetValues(typeof(CharacterAttributes.Classes)).Length - 1;
            CharacterAttributes.Classes lastClass = (CharacterAttributes.Classes)lastValue;

            foreach (CharacterAttributes.Classes thisClass in System.Enum.GetValues(typeof(CharacterAttributes.Classes)))
            {
                if (myClass == thisClass)
                {
                    myClass = lastClass;
                    break;
                }
                lastClass = thisClass;
            }

        }
    }

    public void ChangePortrait(bool goNext)
    {
        Debug.Log("ChangePortrait() called");
        if (goNext)
        {

            int maxIndex = portraitList.Count;
            int currentIndex = portraitList.IndexOf(myPortrait);

            currentIndex++;
            if (currentIndex == maxIndex)
            {
                currentIndex = 0;
            }
            myPortrait = portraitList[currentIndex];

        }
        else
        {
            int maxIndex = portraitList.Count;
            int currentIndex = portraitList.IndexOf(myPortrait);

            currentIndex--;
            if (currentIndex == -1)
            {
                currentIndex = maxIndex - 1;
            }
            myPortrait = portraitList[currentIndex];

        }
    }

    public void ChangeGender()
    {
        Debug.Log("ChangeGender() called");
        isMale = !isMale;
    }

    public void AddToStrength()
    {
        int myStr = myAttributes[CharacterAttributes.BaseAttributes.Strength];

        if (myStr < 18)
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] += 1;
            myStr++;
        }
    }
}
