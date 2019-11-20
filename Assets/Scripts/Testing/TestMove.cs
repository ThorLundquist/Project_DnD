using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{

    public float moveSpeed = 4f;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += move;
    }
}
