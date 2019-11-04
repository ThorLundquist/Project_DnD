using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Opretter en vector regning der sørger for at der ingen "acceleration" er når karakteren bevæger sig.
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); //Ved at bruge "GetAxixRaw" i stedet for "GetAxis" eliminere man, accelerationen, og tager direkte værdig, så man får nitendo følelsen.
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        Debug.Log(change); //--> En lille tekst debugger, så jeg kan være sikker på at få de rigtige værdiger printet ud.

    }
    void MoveCharacter()
    {
        //Denne funktion sørger for at bevæge sig færre frames.
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
