using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example3 : MonoBehaviour
{
    private BoxCollider2D bc;
    private Rigidbody2D rb;

    void Awake()
    {
        Debug.Log("Example 3");
        //SpriteRenderer sprRend = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        //sprRend.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);

        //bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        //bc.size = new Vector2(1.3f, 1.3f);
        //bc.isTrigger = true;

        //rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        //rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("beach_49");
        //gameObject.transform.Translate(4.0f, 0.0f, 0.0f);
        //gameObject.transform.localScale = new Vector2(2.0f, 2.0f);
    }
}
