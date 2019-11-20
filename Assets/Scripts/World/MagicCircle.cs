using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public bool move = false;
    public Vector2 mcPos;
    public Vector2 cPos;
    public Vector2 cenPos;
    Animator anim;

    /*
        I've found two ways to go about getting the position of any object in Unity. First is to tag it in the editor. 
        The other is to reference it as an object in a script, like I've done here
    */
    public GameObject center;
    public GameObject character; // You will need to drag the character object in the Unity editor's Hierarchy onto the Script in the Character field


    private void Start()
    {
        cenPos = center.transform.position;
        // mcPos = GameObject.FindGameObjectWithTag("MC").transform.position;  
        // Takes the position of any object with the tag "MC" and stores it in the variable "mcPos"

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cPos = character.transform.position; //Catches Character's position and puts it in the variable "cPos"
        if (move)
        {
            // If Character's collider triggers MagicCircle's collider, character moves into the middle of MagicCircle
            transform.position = Vector2.MoveTowards(transform.position, cenPos, 2 * Time.deltaTime); 

            if (cenPos == cPos)
            {
                move = false;
                Debug.Log("it should work");  

              //  if (Input.GetButtonDown("Test"))
               // {
                    Debug.Log("Press space to teleport!");
                    anim.SetTrigger("isTeleport");
              //  }
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