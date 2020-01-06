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
    public bool isMale;
    // Start is called before the first frame update
    void Start()
    {
        //GlobalControl.Instance.LoadData();

        localPlayerData = GlobalControl.Instance.LocalCopyOfData;
        activeScene = SceneManager.GetActiveScene().buildIndex;

        nameText.text = localPlayerData.myName;
        raceText.text = localPlayerData.myRace;
        classText.text = localPlayerData.myClass;

        //portraitString = localPlayerData.portraitString;
        if (localPlayerData.isMale)
        {
            genderText.text = "Male";
            isMale = true;
        }
        else if (!localPlayerData.isMale)
        {
            genderText.text = "Female";
            isMale = false;
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

    public void SaveGame()
    {
        Debug.Log("Saving");
        localPlayerData.SceneID = activeScene;
        localPlayerData.myName = nameText.text;
        localPlayerData.myRace = raceText.text;
        localPlayerData.myClass = classText.text;
        localPlayerData.isMale = isMale;
        //localPlayerData.portraitString = portraitString;
        //localPlayerData.points = points;
        localPlayerData.Strength = int.Parse(strValue.text);//myAttributes[CharacterAttributes.BaseAttributes.Strength];
        localPlayerData.Dexterity = int.Parse(dexValue.text);//myAttributes[CharacterAttributes.BaseAttributes.Dexterity];
        localPlayerData.Constitution = int.Parse(conValue.text);//myAttributes[CharacterAttributes.BaseAttributes.Constitution];
        localPlayerData.Intelligence = int.Parse(intValue.text);//myAttributes[CharacterAttributes.BaseAttributes.Intelligence];
        localPlayerData.Wisdom = int.Parse(wisValue.text);//myAttributes[CharacterAttributes.BaseAttributes.Wisdom];
        localPlayerData.Charisma = int.Parse(chaValue.text);//myAttributes[CharacterAttributes.BaseAttributes.Charisma];
        localPlayerData.SceneID = SceneManager.GetActiveScene().buildIndex;
        localPlayerData.PositionX = transform.position.x;
        localPlayerData.PositionY = transform.position.y;
        localPlayerData.PositionZ = transform.position.z;
        GlobalControl.Instance.LocalCopyOfData = localPlayerData;
        GlobalControl.Instance.SaveData();
    }
    public void LoadGame()
    {
        GlobalControl.Instance.LoadData();
        localPlayerData = GlobalControl.Instance.LocalCopyOfData;
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
