﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public List<Sprite> portraitList;
    public Sprite myPortrait;
    public string portraitString = "";

    public CharacterAttributes.Races myRace;
    public CharacterAttributes.Classes myClass;
    public string myName;

    public Dictionary<CharacterAttributes.BaseAttributes, int> myAttributes;
    public Dictionary<CharacterAttributes.BaseRacials, int> myRacials;
    public Dictionary<CharacterAttributes.BaseModifiers, int> myMods;

    public bool isMale = true;

    int myHP;
    readonly int baseValue = 10;
    readonly int baseRacial = 0;
    public int points;
    public int cost;

    public void InitializeCharacterGenerator()
    {
        myAttributes = new Dictionary<CharacterAttributes.BaseAttributes, int>();
        myRacials = new Dictionary<CharacterAttributes.BaseRacials, int>();
        myMods = new Dictionary<CharacterAttributes.BaseModifiers, int>();

        //Set initial race
        myRace = CharacterAttributes.Races.Human;

        //Set initial class
        myClass = CharacterAttributes.Classes.Fighter;

        //Set default portrait
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

    public void CheckRace(bool isNew)
    {
        if (isNew)
        {
            points = 27;
            cost = 1;
            InitializeAttributes();
            portraitString = "";
        }

        switch (myRace)
        {
            case CharacterAttributes.Races.Dwarf:
                //myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 2;
                myRacials[CharacterAttributes.BaseRacials.Constitution] = 2;

                portraitList = GetComponent<PortraitScriptable>().mDwarf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fDwarf;
                }
                break;
            case CharacterAttributes.Races.Elf:
                //myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 2;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] = 2;

                portraitList = GetComponent<PortraitScriptable>().mElf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fElf;
                }
                break;
            case CharacterAttributes.Races.Halfling:
                //myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 2;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] = 2;

                portraitList = GetComponent<PortraitScriptable>().mHalfling;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalfling;
                }
                break;
            case CharacterAttributes.Races.Human:
                //myAttributes[CharacterAttributes.BaseAttributes.Strength] += 1;
                //myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;
                //myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;
                //myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
                //myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += 1;
                //myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;

                myRacials[CharacterAttributes.BaseRacials.Strength] = 1;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] = 1;
                myRacials[CharacterAttributes.BaseRacials.Constitution] = 1;
                myRacials[CharacterAttributes.BaseRacials.Intelligence] = 1;
                myRacials[CharacterAttributes.BaseRacials.Wisdom] = 1;
                myRacials[CharacterAttributes.BaseRacials.Charisma] = 1;


                portraitList = GetComponent<PortraitScriptable>().mHuman;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHuman;
                }
                break;
            case CharacterAttributes.Races.Dragonborn:
                //myAttributes[CharacterAttributes.BaseAttributes.Strength] += 2;
                //myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;

                myRacials[CharacterAttributes.BaseRacials.Strength] = 2;
                myRacials[CharacterAttributes.BaseRacials.Charisma] = 1;

                portraitList = GetComponent<PortraitScriptable>().mDragonborn;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fDragonborn;
                }
                break;
            case CharacterAttributes.Races.Gnome:
                //myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 2;

                myRacials[CharacterAttributes.BaseRacials.Intelligence] = 2;

                portraitList = GetComponent<PortraitScriptable>().mGnome;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fGnome;
                }
                break;
            case CharacterAttributes.Races.Half_Elf:
                //myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 2;
                //myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
                //myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;

                myRacials[CharacterAttributes.BaseRacials.Charisma] = 2;
                myRacials[CharacterAttributes.BaseRacials.Intelligence] = 1;
                myRacials[CharacterAttributes.BaseRacials.Dexterity] = 1;

                portraitList = GetComponent<PortraitScriptable>().mHalf_Elf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalf_Elf;
                }
                break;
            case CharacterAttributes.Races.Half_Orc:
                //myAttributes[CharacterAttributes.BaseAttributes.Strength] += 2;
                //myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;

                myRacials[CharacterAttributes.BaseRacials.Strength] = 2;
                myRacials[CharacterAttributes.BaseRacials.Constitution] = 1;

                portraitList = GetComponent<PortraitScriptable>().mHalf_Orc;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalf_Orc;
                }
                break;
            case CharacterAttributes.Races.Tiefling:
                //myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
                //myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 2;

                myRacials[CharacterAttributes.BaseRacials.Intelligence] = 1;
                myRacials[CharacterAttributes.BaseRacials.Charisma] = 2;

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

        if (portraitString == "")
        {
            //Opdates portrait to default 
            myPortrait = portraitList[0];
        }
        else
        {
            foreach (Sprite thisPortrait in portraitList)
            {
                if (thisPortrait.ToString() == portraitString)
                {
                    myPortrait = thisPortrait;
                }
            }
        }
    }

    public void CalcAtt()
    {
        myAttributes[CharacterAttributes.BaseAttributes.Strength] += myRacials[CharacterAttributes.BaseRacials.Strength];
        myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += myRacials[CharacterAttributes.BaseRacials.Dexterity];
        myAttributes[CharacterAttributes.BaseAttributes.Constitution] += myRacials[CharacterAttributes.BaseRacials.Constitution];
        myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += myRacials[CharacterAttributes.BaseRacials.Intelligence];
        myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += myRacials[CharacterAttributes.BaseRacials.Wisdom];
        myAttributes[CharacterAttributes.BaseAttributes.Charisma] += myRacials[CharacterAttributes.BaseRacials.Charisma];
    }

    public void ChangeRace(bool goNext)
    {
        bool foundIt = false;
        if (goNext)
        {
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
            //If we reach the end of the Enum of Races, set the next race to be the first race
            if (foundIt)
            {
                myRace = 0;
            }
        }

        else
        {
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
        isMale = !isMale;
    }

    public void AddAtt(CharacterAttributes.BaseAttributes attribute)
    {
        int myAtt = Convert.ToInt32(myAttributes[attribute]);
        if ((myAtt == 8) && (points >= cost))
        {
            myAttributes[attribute] += 1;
            points--;
            cost++;
        }
        else if ((myAtt == 12) && (points >= cost))
        {
            myAttributes[attribute] += 1;
            cost = cost + 2;
            points = points - cost;
        }
    }

    public void AddToStr()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Strength];

        if ((myAtt < 13) && (points >= 1))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] += 1;
            myAtt++;
            points--;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt >= 13) && (myAtt <= 14) && (points >= 2))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] += 1;
            myAtt++;
            points -= 2;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 15) && (myAtt <= 16) && (points >= 3))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] += 1;
            myAtt++;
            points -= 3;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 17) && (myAtt <= 18) &&(points >= 4))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] += 1;
            myAtt++;
            points -= 4;
            Debug.Log("total points: " + points);
        }
    }
    public void AddToDex()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Dexterity];
        if ((myAtt < 13) && (points >= 1))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;
            myAtt++;
            points--;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt >= 13) && (myAtt <= 14) && (points >= 2))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;
            myAtt++;
            points -= 2;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 15) && (myAtt <= 16) && (points >= 3))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;
            myAtt++;
            points -= 3;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 17) && (myAtt <= 18) && (points >= 4))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += 1;
            myAtt++;
            points -= 4;
            Debug.Log("total points: " + points);
        }
    }
    public void AddToCon()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Constitution];

        if ((myAtt < 13) && (points >= 1))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;
            myAtt++;
            points--;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt >= 13) && (myAtt <= 14) && (points >= 2))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;
            myAtt++;
            points -= 2;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 15) && (myAtt <= 16) && (points >= 3))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;
            myAtt++;
            points -= 3;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 17) && (myAtt <= 18) && (points >= 4))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] += 1;
            myAtt++;
            points -= 4;
            Debug.Log("total points: " + points);
        }
    }
    public void AddToInt()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Intelligence];

        if ((myAtt < 13) && (points >= 1))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
            myAtt++;
            points--;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt >= 13) && (myAtt <= 14) && (points >= 2))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
            myAtt++;
            points -= 2;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 15) && (myAtt <= 16) && (points >= 3))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
            myAtt++;
            points -= 3;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 17) && (myAtt <= 18) && (points >= 4))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += 1;
            myAtt++;
            points -= 4;
            Debug.Log("total points: " + points);
        }
    }
    public void AddToWis()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Wisdom];

        if ((myAtt < 13) && (points >= 1))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += 1;
            myAtt++;
            points--;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt >= 13) && (myAtt <= 14) && (points >= 2))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += 1;
            myAtt++;
            points -= 2;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 15) && (myAtt <= 16) && (points >= 3))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += 1;
            myAtt++;
            points -= 3;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 17) && (myAtt <= 18) && (points >= 4))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += 1;
            myAtt++;
            points -= 4;
            Debug.Log("total points: " + points);
        }
    }
    public void AddToCha()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Charisma];

        if ((myAtt < 13) && (points >= 1))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;
            myAtt++;
            points--;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt >= 13) && (myAtt <= 14) && (points >= 2))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;
            myAtt++;
            points -= 2;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 15) && (myAtt <= 16) && (points >= 3))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;
            myAtt++;
            points -= 3;
            Debug.Log("total points: " + points);
        }

        else if ((myAtt >= 17) && (myAtt <= 18) && (points >= 4))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] += 1;
            myAtt++;
            points -= 4;
            Debug.Log("total points: " + points);
        }
    }

    public void SubFromStr()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Strength];

        if ((myAtt <= 13) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] -= 1;
            myAtt--;
            points++;
            Debug.Log("Attr: " + myAtt);
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 15) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] -= 1;
            myAtt--;
            points += 2;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 17) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] -= 1;
            myAtt--;
            points += 3;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 19) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Strength] -= 1;
            myAtt--;
            points += 4;
            Debug.Log("total points: " + points);
        }
    }
    public void SubFromDex()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Dexterity];

        if ((myAtt <= 13) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] -= 1;
            myAtt--;
            points++;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 15) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] -= 1;
            myAtt--;
            points += 2;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 17) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] -= 1;
            myAtt--;
            points += 3;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 19) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Dexterity] -= 1;
            myAtt--;
            points += 4;
            Debug.Log("total points: " + points);
        }
    }
    public void SubFromCon()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Constitution];

        if ((myAtt <= 13) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] -= 1;
            myAtt--;
            points++;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 15) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] -= 1;
            myAtt--;
            points += 2;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 17) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] -= 1;
            myAtt--;
            points += 3;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 19) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Constitution] -= 1;
            myAtt--;
            points += 4;
            Debug.Log("total points: " + points);
        }
    }
    public void SubFromInt()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Intelligence];

        if ((myAtt <= 13) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] -= 1;
            myAtt--;
            points++;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 15) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] -= 1;
            myAtt--;
            points += 2;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 17) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] -= 1;
            myAtt--;
            points += 3;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 19) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Intelligence] -= 1;
            myAtt--;
            points += 4;
            Debug.Log("total points: " + points);
        }
    }
    public void SubFromWis()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Wisdom];

        if ((myAtt <= 13) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] -= 1;
            myAtt--;
            points++;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 15) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] -= 1;
            myAtt--;
            points += 2;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 17) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] -= 1;
            myAtt--;
            points += 3;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 19) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Wisdom] -= 1;
            myAtt--;
            points += 4;
            Debug.Log("total points: " + points);
        }
    }
    public void SubFromCha()
    {
        int myAtt = myAttributes[CharacterAttributes.BaseAttributes.Charisma];

        if ((myAtt <= 13) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] -= 1;
            myAtt--;
            points++;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 15) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] -= 1;
            myAtt--;
            points += 2;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 17) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] -= 1;
            myAtt--;
            points += 3;
            Debug.Log("total points: " + points);
        }
        else if ((myAtt <= 19) && (myAtt > 8))
        {
            myAttributes[CharacterAttributes.BaseAttributes.Charisma] -= 1;
            myAtt--;
            points += 4;
            Debug.Log("total points: " + points);
        }
    }
}