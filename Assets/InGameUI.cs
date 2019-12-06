using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject inventoryUI; // Assign in inspector
    private bool isShowing;

    void Start()
    {
        inventoryUI.SetActive(false);
        isShowing = false;
    }
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            isShowing = !isShowing;
            inventoryUI.SetActive(isShowing);
        }
    }

    public void CloseButtonCalled()
    {
        isShowing = false;
        inventoryUI.SetActive(false);
    }
}