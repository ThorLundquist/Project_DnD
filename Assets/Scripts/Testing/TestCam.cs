using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    Transform character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(character.position.x, character.position.y, -10f);
    }
}
