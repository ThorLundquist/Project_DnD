using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject inventoryUI;
    public GameObject levelUpUI; 
    // Assign these in the inspector

    void Start()
    {
        inventoryUI.SetActive(false);
        menuUI.SetActive(false);
        levelUpUI.SetActive(false);
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