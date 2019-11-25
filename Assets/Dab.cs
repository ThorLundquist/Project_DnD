using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dab : MonoBehaviour
{
    private bool isFlipped;
  //  private bool flipstate;
  //  private Vector3 poly;
    // Start is called before the first frame update
    void Start()
    {
        // flipstate = false;
         StartCoroutine("Flip");

    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipped)
        {
            StartCoroutine("Flop");
        }
        else if (!isFlipped)
        {
            StartCoroutine("Flip");
        }
        else
        {
            Debug.Log("Fuck me");
        }
    }
    IEnumerator Flip()
    {
        yield return new WaitForSeconds(1);
        transform.localScale = new Vector3(-1, 1, 1);
        isFlipped = true;
        yield return new WaitForSeconds(1);
    }
    IEnumerator Flop()
    {
        yield return new WaitForSeconds(1);
        transform.localScale = new Vector3(1, 1, 1);
        isFlipped = false;
        yield return new WaitForSeconds(1);
    }
    //IEnumerator Flippy()
    //{

    //    do
    //    {
    //        GetComponent<SpriteRenderer>().flipX = flipstate;
    //        flipstate = !flipstate;


    //        yield return new WaitForSeconds(1f);


    //    } while (true);
    //}
}
