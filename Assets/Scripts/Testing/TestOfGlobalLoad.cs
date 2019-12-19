using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestOfGlobalLoad : MonoBehaviour
{
    //public static GlobalControl Instance;
    public PlayerStatistics localPlayerData = new PlayerStatistics();

    public Text nameText, raceText, classText, genderText;
    public Text strValue, dexValue, conValue, chaValue, wisValue, intValue;
    public Text hpValue, pointsValue;
    public Image portrait;
    public Text strModValue, dexModValue, conModValue, intModValue, wisModValue, chaModValue;
    public List<GameObject> attributeValuesList;

    public int activeScene;

    // Start is called before the first frame update
    void Start()
    {
        //GlobalControl.Instance.LoadData();

        localPlayerData = GlobalControl.Instance.savedPlayerData;
        activeScene = SceneManager.GetActiveScene().buildIndex;

        nameText.text = localPlayerData.myName;
        raceText.text = localPlayerData.myRace;
        classText.text = localPlayerData.myClass;

        //portraitString = localPlayerData.portraitString;
        if (localPlayerData.isMale)
        {
            genderText.text = "Male";
        }
        else if (!localPlayerData.isMale)
        {
            genderText.text = "Female";
        }
        //points = localPlayerData.points;
        strValue.text = localPlayerData.Strength.ToString();
        dexValue.text = localPlayerData.Dexterity.ToString();
        conValue.text = localPlayerData.Constitution.ToString();
        intValue.text = localPlayerData.Intelligence.ToString();
        wisValue.text = localPlayerData.Wisdom.ToString();
        chaValue.text = localPlayerData.Charisma.ToString();
        CalcMods();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        GlobalControl.Instance.SaveData();
    }
    public void LoadGame()
    {
        GlobalControl.Instance.LoadData();
    }
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
