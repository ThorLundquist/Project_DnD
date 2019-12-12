﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    CharacterGenerator myCharGen;

    public Text raceText, classText, genderText;
    public Text strValue, dexValue, conValue, chaValue, wisValue, intValue;
    public Text hpValue, pointsValue;
    public Text strRacial, dexRacial, conRacial, intRacial, wisRacial, chaRacial;
    public Image portrait;
    public Text strModValue, dexModValue, conModValue, intModValue, wisModValue, chaModValue;
    public Text nameValue;
    public List<GameObject> attributeValuesList;

    // Start is called before the first frame update
    void Start()
    {
        myCharGen = GetComponent<CharacterGenerator>();
        myCharGen.InitializeCharacterGenerator();
        myCharGen.CheckRace();
        raceText.text = myCharGen.myRace.ToString();
        classText.text = myCharGen.myClass.ToString();

        //Updates default gender text 
        genderText.text = "Male";
        if (!myCharGen.isMale)
        {
            genderText.text = "Female";
        }

        //Updates the portrait
        portrait.sprite = myCharGen.myPortrait;
        pointsValue.text = myCharGen.points.ToString();

        //UpdateUI(true) sets the default view
        UpdateUI(true);
    }

    public void UpdateUI(bool changeRace)
    {
        if (changeRace == true)
        {
            myCharGen.CheckRace();
        }

        portrait.sprite = myCharGen.myPortrait;
        pointsValue.text = myCharGen.points.ToString();

        // Opdatere Score kolonnen
        strValue.text = myCharGen.myAttributes[CharacterAttributes.BaseAttributes.Strength].ToString();
        conValue.text = myCharGen.myAttributes[CharacterAttributes.BaseAttributes.Constitution].ToString();
        dexValue.text = myCharGen.myAttributes[CharacterAttributes.BaseAttributes.Dexterity].ToString();
        intValue.text = myCharGen.myAttributes[CharacterAttributes.BaseAttributes.Intelligence].ToString();
        wisValue.text = myCharGen.myAttributes[CharacterAttributes.BaseAttributes.Wisdom].ToString();
        chaValue.text = myCharGen.myAttributes[CharacterAttributes.BaseAttributes.Charisma].ToString();

        //Opdatere Racial kolonnen
        strRacial.text = myCharGen.myRacials[CharacterAttributes.BaseRacials.Strength].ToString();
        dexRacial.text = myCharGen.myRacials[CharacterAttributes.BaseRacials.Dexterity].ToString();
        conRacial.text = myCharGen.myRacials[CharacterAttributes.BaseRacials.Constitution].ToString();
        intRacial.text = myCharGen.myRacials[CharacterAttributes.BaseRacials.Intelligence].ToString();
        wisRacial.text = myCharGen.myRacials[CharacterAttributes.BaseRacials.Wisdom].ToString();
        chaRacial.text = myCharGen.myRacials[CharacterAttributes.BaseRacials.Charisma].ToString();

        CalcMods();

        //Opdatere Mod kolonnen
        //strModValue.text = myCharGen.myMods[CharacterAttributes.BaseModifiers.Strength].ToString();
        //dexModValue.text = myCharGen.myMods[CharacterAttributes.BaseModifiers.Dexterity].ToString();
        //conModValue.text = myCharGen.myMods[CharacterAttributes.BaseModifiers.Constitution].ToString();
        //intModValue.text = myCharGen.myMods[CharacterAttributes.BaseModifiers.Intelligence].ToString();
        //wisModValue.text = myCharGen.myMods[CharacterAttributes.BaseModifiers.Wisdom].ToString();
        //chaModValue.text = myCharGen.myMods[CharacterAttributes.BaseModifiers.Charisma].ToString();        
    }

    /*
    En række metoder der bliver kaldt når der klikkes på de knapper 
    som de er sat sammen med i Unity via objektet "Character".     
    */
    public void NextRaceClicked()
    {
        myCharGen.ChangeRace(true);
        raceText.text = myCharGen.myRace.ToString();
        UpdateUI(true);
    }

    public void PrevRaceClicked()
    {
        myCharGen.ChangeRace(false);
        raceText.text = myCharGen.myRace.ToString();
        UpdateUI(true);
    }
    public void NextClassClicked()
    {
        myCharGen.ChangeClass(true);
        classText.text = myCharGen.myClass.ToString();
        UpdateUI(false);
    }

    public void PrevClassClicked()
    {
        myCharGen.ChangeClass(false);
        classText.text = myCharGen.myClass.ToString();
        UpdateUI(false);
    }

    public void NextPortraitClicked()
    {
        myCharGen.ChangePortrait(true);
        portrait.sprite = myCharGen.myPortrait;
    }

    public void PrevPortraitClicked()
    {
        myCharGen.ChangePortrait(false);
        portrait.sprite = myCharGen.myPortrait;
    }

    public void GenderButtonClicked()
    {
        myCharGen.ChangeGender();
        if (myCharGen.isMale)
        {
            genderText.text = "Male";
        }
        else
        {
            genderText.text = "Female";
        }
        UpdateUI(true);
    }

    public void SaveBtnClicked()
    {
        if (nameValue.text == "")
        {
            Debug.Log("No name entered");
            return;
        }

        GetComponent<FileIO>().SaveCharacter(nameValue.text);
    }

    public void ContBtnClicked()
    {
        if (nameValue.text == "")
        {
            Debug.Log("No name entered");
            return;
        }

        GetComponent<FileIO>().SaveCharacter(nameValue.text);
        SceneManager.LoadScene(2);
    }

    public void AddStrBtnClicked()
    {
        myCharGen.AddToStr();
        UpdateUI(false);
    }
    public void AddDexBtnClicked()
    {
        myCharGen.AddToDex();
        UpdateUI(false);
    }
    public void AddConBtnClicked()
    {
        myCharGen.AddToCon();
        UpdateUI(false);
    }
    public void AddIntBtnClicked()
    {
        myCharGen.AddToInt();
        UpdateUI(false);
    }
    public void AddWisBtnClicked()
    {
        myCharGen.AddToWis();
        UpdateUI(false);
    }
    public void AddChaBtnClicked()
    {
        myCharGen.AddToCha();
        UpdateUI(false);
    }

    public void SubStrBtnClicked()
    {
        myCharGen.SubFromStr();
        UpdateUI(false);
    }
    public void SubDexBtnClicked()
    {
        myCharGen.SubFromDex();
        UpdateUI(false);
    }
    public void SubConBtnClicked()
    {
        myCharGen.SubFromCon();
        UpdateUI(false);
    }
    public void SubIntBtnClicked()
    {
        myCharGen.SubFromInt();
        UpdateUI(false);
    }
    public void SubWisBtnClicked()
    {
        myCharGen.SubFromWis();
        UpdateUI(false);
    }
    public void SubChaBtnClicked()
    {
        myCharGen.SubFromCha();
        UpdateUI(false);
    }

    public void LoadBtnClicked()
    {
        if (nameValue.text == "")
        {
            Debug.Log("Need a name");
            return;
        }

        GetComponent<FileIO>().LoadCharacter(nameValue.text);
        UpdateUI(false);

        raceText.text = myCharGen.myRace.ToString();
        classText.text = myCharGen.myClass.ToString();

        if (myCharGen.isMale)
        {
            genderText.text = "Male";
        }
        else
        {
            genderText.text = "Female";
        }
    }

    /*
    Metode der udregner karakterens Mod values, som er de tal 
    der skal bruges til de fleste rolls i spillet
    */
    void CalcMods()
    {
        int div = 2;
        int min = 5;

        int myStrMod = int.Parse(strValue.text);
        int myDexMod = int.Parse(dexValue.text);
        int myConMod = int.Parse(conValue.text);
        int myIntMod = int.Parse(intValue.text);
        int myWisMod = int.Parse(wisValue.text);
        int myChaMod = int.Parse(chaValue.text);

        int strMod = (myStrMod / div) - min;
        strModValue.text = strMod.ToString();

        int dexMod = (myDexMod / div) - min;
        dexModValue.text = dexMod.ToString();

        int conMod = (myConMod / div) - min;
        conModValue.text = conMod.ToString();

        int intMod = (myIntMod / div) - min;
        intModValue.text = intMod.ToString();

        int wisMod = (myWisMod / div) - min;
        wisModValue.text = wisMod.ToString();

        int chaMod = (myChaMod / div) - min;
        chaModValue.text = chaMod.ToString();
    }



}
