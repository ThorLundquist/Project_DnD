using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public bool move = false;
    public Vector2 mcPos;
    public Vector2 cPos;
    public GameObject magicCircle;
    public GameObject character;


    private void Start()
    {
        mcPos = GameObject.FindGameObjectWithTag("MC").transform.position;  // Takes the position of any object with the tag "MC" and stores it in the variable "mcPos"
    }

    // Update is called once per frame
    void Update()
    {
        cPos = character.transform.position; //Catches Character's position and puts it in the variable "cPos"
        if (move)
        {
            // If Character's collider triggers MagicCircle's collider, character moves into the middle of MagicCircle
            transform.position = Vector2.MoveTowards(transform.position, mcPos, 2 * Time.deltaTime); 

            if (mcPos == cPos)
            {
                move = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col) // this calls when Character collider box touches MagicCircle Collider box
    {
        if (col.tag == "MC")
        {
            move = true;
        }
    }
}