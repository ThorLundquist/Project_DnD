using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOfTeleport : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggered");
        int count = 0;

        if (count <= 0)
        {
            count++;
            Debug.Log(count);
        }
    }
}
