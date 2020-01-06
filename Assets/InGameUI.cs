using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject inventoryUI;
    public GameObject levelUpUI;
    //public Text nameText, raceText, classText, genderText;
    //public Text strValue, dexValue, conValue, chaValue, wisValue, intValue;
    //public Text strModValue, dexModValue, conModValue, intModValue, wisModValue, chaModValue;

    // Assign these in the inspector
    public PlayerStatistics localPlayerData = new PlayerStatistics();
    //public bool isMale;
    public int activeScene;
    void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        inventoryUI.SetActive(false);
        menuUI.SetActive(false);
        levelUpUI.SetActive(false);
    }
    void UpdateUI()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            InventoryBtnClicked();
        }

        if (Input.GetKeyDown("escape"))
        {            
            MenuBtnClicked();
        }
        // If File is being loaded, we remember character's in-game position
        //if (GlobalControl.Instance.IsSceneLoaded)
        //{
        //    PlayerState.Instance.localPlayerData = GlobalControl.Instance.LocalCopyOfData;

        //    transform.position = new Vector3(
        //      GlobalControl.Instance.LocalCopyOfData.PositionX,
        //      GlobalControl.Instance.LocalCopyOfData.PositionY,
        //      GlobalControl.Instance.LocalCopyOfData.PositionZ);

        //    GlobalControl.Instance.IsSceneLoaded = false;
        //}
        // Save to Local Player Data
        if (Input.GetKey(KeyCode.F5))
        {
            SaveBtnClicked();
        }
        // Load from Local Copy Of Data
        if (Input.GetKey(KeyCode.F8))
        {
            GlobalControl.Instance.LoadData();
            GlobalControl.Instance.IsSceneLoaded = true;

            int whichScene = GlobalControl.Instance.LocalCopyOfData.SceneID;

            SceneManager.LoadScene(whichScene);
        }
    }
    public void SaveBtnClicked()
    {        
        GlobalControl.Instance.LocalCopyOfData = localPlayerData;
        GlobalControl.Instance.SaveData();
    }

    public void LoadBtnCLicked()
    {

    }

    public void MenuBtnClicked()
    {
        inventoryUI.SetActive(false);

        if (menuUI.activeSelf)
        {
            menuUI.SetActive(false);
        }
        else if (menuUI.activeSelf == false)
        {
            menuUI.SetActive(true);
        }
    }

    public void InventoryBtnClicked()
    {
        if (inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(false);
        }
        else if (inventoryUI.activeSelf == false && menuUI.activeSelf == false)
        {
            inventoryUI.SetActive(true);
        }
    }   
}