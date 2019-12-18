using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour
{
    public PlayerStatistics localPlayerData = new PlayerStatistics();

    public List<Sprite> portraitList;
    public Sprite myPortrait;
    public string portraitString = "";

    public string myName;
    public int activeScene;
    public bool isMale = true;
    public int myHP;
    readonly int baseValue = 8;
    readonly int baseRacial = 0;
    public int points;

    public CharacterAttributes.Races myRace;
    public CharacterAttributes.Classes myClass;
    public Dictionary<CharacterAttributes.BaseAttributes, int> myAttributes;
    public Dictionary<CharacterAttributes.BaseRacials, int> myRacials;
    public Dictionary<CharacterAttributes.BaseModifiers, int> myMods;

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
            InitializeAttributes();
            portraitString = "";
        }

        switch (myRace)
        {
            case CharacterAttributes.Races.Dwarf:
                myRacials[CharacterAttributes.BaseRacials.Constitution] = 2;

                portraitList = GetComponent<PortraitScriptable>().mDwarf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fDwarf;
                }
                break;
            case CharacterAttributes.Races.Elf:
                myRacials[CharacterAttributes.BaseRacials.Dexterity] = 2;

                portraitList = GetComponent<PortraitScriptable>().mElf;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fElf;
                }
                break;
            case CharacterAttributes.Races.Halfling:
                myRacials[CharacterAttributes.BaseRacials.Dexterity] = 2;

                portraitList = GetComponent<PortraitScriptable>().mHalfling;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalfling;
                }
                break;
            case CharacterAttributes.Races.Human:
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
                myRacials[CharacterAttributes.BaseRacials.Strength] = 2;
                myRacials[CharacterAttributes.BaseRacials.Charisma] = 1;

                portraitList = GetComponent<PortraitScriptable>().mDragonborn;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fDragonborn;
                }
                break;
            case CharacterAttributes.Races.Gnome:
                myRacials[CharacterAttributes.BaseRacials.Intelligence] = 2;

                portraitList = GetComponent<PortraitScriptable>().mGnome;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fGnome;
                }
                break;
            case CharacterAttributes.Races.Half_Elf:
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
                myRacials[CharacterAttributes.BaseRacials.Strength] = 2;
                myRacials[CharacterAttributes.BaseRacials.Constitution] = 1;

                portraitList = GetComponent<PortraitScriptable>().mHalf_Orc;
                if (!isMale)
                {
                    portraitList = GetComponent<PortraitScriptable>().fHalf_Orc;
                }
                break;
            case CharacterAttributes.Races.Tiefling:
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

        if (isNew)
        {
            AddRacialsToAttributes();
        }

        CheckPortraitString();
        
    }
    public Sprite CheckPortraitString()
    {
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
        return myPortrait;
    }
    public void AddRacialsToAttributes()
    {
        myAttributes[CharacterAttributes.BaseAttributes.Strength] += myRacials[CharacterAttributes.BaseRacials.Strength];
        myAttributes[CharacterAttributes.BaseAttributes.Dexterity] += myRacials[CharacterAttributes.BaseRacials.Dexterity];
        myAttributes[CharacterAttributes.BaseAttributes.Constitution] += myRacials[CharacterAttributes.BaseRacials.Constitution];
        myAttributes[CharacterAttributes.BaseAttributes.Intelligence] += myRacials[CharacterAttributes.BaseRacials.Intelligence];
        myAttributes[CharacterAttributes.BaseAttributes.Wisdom] += myRacials[CharacterAttributes.BaseRacials.Wisdom];
        myAttributes[CharacterAttributes.BaseAttributes.Charisma] += myRacials[CharacterAttributes.BaseRacials.Charisma];
    }
    public void SubRacialsFromAttributes()
    {
        myAttributes[CharacterAttributes.BaseAttributes.Strength] -= myRacials[CharacterAttributes.BaseRacials.Strength];
        myAttributes[CharacterAttributes.BaseAttributes.Dexterity] -= myRacials[CharacterAttributes.BaseRacials.Dexterity];
        myAttributes[CharacterAttributes.BaseAttributes.Constitution] -= myRacials[CharacterAttributes.BaseRacials.Constitution];
        myAttributes[CharacterAttributes.BaseAttributes.Intelligence] -= myRacials[CharacterAttributes.BaseRacials.Intelligence];
        myAttributes[CharacterAttributes.BaseAttributes.Wisdom] -= myRacials[CharacterAttributes.BaseRacials.Wisdom];
        myAttributes[CharacterAttributes.BaseAttributes.Charisma] -= myRacials[CharacterAttributes.BaseRacials.Charisma];
    }
    public string CalcPoints()
    {
        points = 27;
        string remainingPoints;

        foreach (CharacterAttributes.BaseAttributes baseAttributes in Enum.GetValues(typeof(CharacterAttributes.BaseAttributes)))
        {
            int myAtt = Convert.ToInt32(myAttributes[baseAttributes]);

            switch (myAtt)
            {
                case 8:
                    break;
                case 9:
                    points -= 1;
                    break;
                case 10:
                    points -= 2;
                    break;
                case 11:
                    points -= 3;
                    break;
                case 12:
                    points -= 4;
                    break;
                case 13:
                    points -= 5;
                    break;
                case 14:
                    points -= 7;
                    break;
                case 15:
                    points -= 9;
                    break;
                case 16:
                    points -= 9;
                    break;
                case 17:
                    points -= 9;
                    break;
                case 18:
                    points -= 9;
                    break;
                default:
                    break;
            }
        }

        remainingPoints = points.ToString();
        return remainingPoints;
    }
    public void ChangeRace(bool goNext)
    {
        bool foundIt = false;
        if (goNext)
        {
            foreach (CharacterAttributes.Races thisRace in Enum.GetValues(typeof(CharacterAttributes.Races)))
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
            int lastValue = Enum.GetValues(typeof(CharacterAttributes.Races)).Length - 1;
            CharacterAttributes.Races lastRace = (CharacterAttributes.Races)lastValue;

            foreach (CharacterAttributes.Races thisRace in Enum.GetValues(typeof(CharacterAttributes.Races)))
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

        if (myAtt >= 8 && myAtt <= 12 && points >= 1)
        {
            points -= 1;
            myAttributes[attribute] += 1;
        }
        else if (myAtt >= 13 && myAtt <= 14 && points >= 2)
        {
            points -= 2;
            myAttributes[attribute] += 1;
        }        
    }
    public void SubAtt(CharacterAttributes.BaseAttributes attribute)
    {
        int myAtt = Convert.ToInt32(myAttributes[attribute]);

        if (myAtt >= 8 && myAtt <= 13)
        {
            points += 1;
            myAttributes[attribute] -= 1;
        }
        else if (myAtt >= 14 && myAtt <= 15)
        {
            points += 2;
            myAttributes[attribute] -= 1;
        }
    }

    public void SaveToGlobal()
    {
        GlobalControl.Instance.savedPlayerData = localPlayerData;
        GlobalControl.Instance.savedPlayerData.SceneID = activeScene;
        GlobalControl.Instance.savedPlayerData.myName = myName;
        GlobalControl.Instance.savedPlayerData.myRace = myRace.ToString();
        GlobalControl.Instance.savedPlayerData.myClass = myClass.ToString();
        GlobalControl.Instance.savedPlayerData.isMale = isMale;
        GlobalControl.Instance.savedPlayerData.portraitString = portraitString;
        GlobalControl.Instance.savedPlayerData.points = points;
        GlobalControl.Instance.savedPlayerData.Strength = myAttributes[CharacterAttributes.BaseAttributes.Strength];
        GlobalControl.Instance.savedPlayerData.Dexterity = myAttributes[CharacterAttributes.BaseAttributes.Dexterity];
        GlobalControl.Instance.savedPlayerData.Constitution = myAttributes[CharacterAttributes.BaseAttributes.Constitution];
        GlobalControl.Instance.savedPlayerData.Intelligence = myAttributes[CharacterAttributes.BaseAttributes.Intelligence];
        GlobalControl.Instance.savedPlayerData.Wisdom = myAttributes[CharacterAttributes.BaseAttributes.Wisdom];
        GlobalControl.Instance.savedPlayerData.Charisma = myAttributes[CharacterAttributes.BaseAttributes.Charisma];
        GlobalControl.Instance.SaveData();
    }
}