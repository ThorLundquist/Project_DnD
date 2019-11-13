using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example2 : MonoBehaviour
{
    private float spriteMove;

    void Awake()
    {
        Debug.Log("Example 2");
        //SpriteRenderer sprRend;
        //sprRend = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        //sprRend.color = new Color(0.9f, 0.9f, 0.9f, 1.0f);

        BoxCollider2D bc;
        bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        bc.size = new Vector2(1.3f, 1.3f);
        bc.isTrigger = true;
    }

    void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("beach_49");
        //gameObject.transform.Translate(-4.0f, 0.0f, 0.0f);
        spriteMove = 1f;
    }

    void FixedUpdate()
    {
        gameObject.transform.Translate(spriteMove, 0.0f, 0.0f);

        if (gameObject.transform.position.x < -4.0f)
        {
            // move GameObject2 to the right
            spriteMove = 1f;
        }
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Triggered");
        if (spriteMove >= 1)
        {
            spriteMove = -1f;
        }
        else
        {
            spriteMove = 1f;
        }
    }
}