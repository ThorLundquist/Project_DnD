using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public bool move = false;
    public bool isInside = false;
    public Vector2 cPos;
    public Vector2 cenPos;
    Animator anim;
    /*
        I've found two ways to go about getting the position of any object in Unity. First is to tag it in the editor. 
        The other is to reference it as an object in a script, like I've done here
    */
    public GameObject floatingText;
    public GameObject center;
    public GameObject character; // You will need to drag the objects in the Unity editor's Hierarchy onto the Script in the given field


    private void Start()
    {
        floatingText.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cenPos = center.transform.position;
        cPos = character.transform.position; //Catches Character's position and puts it in the variable "cPos"

        if (move)
        {           
            // isInside = true;
            Debug.Log("moving");
            // If Character's collider triggers MagicCircle's collider, character moves into the middle of MagicCircle
            transform.position = Vector2.MoveTowards(cPos, cenPos, 2 * Time.deltaTime);
            if (cPos == cenPos)
            {
                move = false;
                isInside = true;
                floatingText.SetActive(true);
            }
        }

        if (isInside && Input.GetKeyDown("h"))
        {
            Debug.Log("TP!");
        }
    }

    void OnTriggerEnter2D(Collider2D col) // this calls when Character collider box touches MagicCircle Collider box
    {
        if (col.tag == "MC")
        {
            Debug.Log("In");
            move = true;            
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "MC")
        {
            Debug.Log("Out");
            isInside = false;
            move = false;
            floatingText.SetActive(false);
        }
    }
}