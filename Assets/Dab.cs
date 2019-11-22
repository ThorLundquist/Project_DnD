using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dab : MonoBehaviour
{
    private bool flipstate;
    private Vector3 poly;
    // Start is called before the first frame update
    void Start()
    {
        flipstate = false;
        StartCoroutine("Flippy");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Flippy()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().flipX = flipstate;
            transform.localScale = new Vector3(-1, 1, 1);
            flipstate = !flipstate;
            yield return new WaitForSeconds(1f);
        }
    }
}
