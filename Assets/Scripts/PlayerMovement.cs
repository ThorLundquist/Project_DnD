using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public GameObject magicCircle;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // <Comment>> Added by Thor <Comment>> 
        //PlayerState.Instance.localPlayerData = GlobalControl.Instance.LocalCopyOfData;

        //transform.position = new Vector3(
        //    GlobalControl.Instance.LocalCopyOfData.PositionX,
        //    GlobalControl.Instance.LocalCopyOfData.PositionY,
        //    GlobalControl.Instance.LocalCopyOfData.PositionZ);

        //GlobalControl.Instance.IsSceneLoaded = false;
        // Here we copy the Data from the GlobalControl instance, 
        // then set our player character's position to the stored variables
        // </Comment>> Added by Thor </Comment>> 
    }
    // Update is called once per frame
    void Update()
    {
        //Opretter en vector regning der sørger for at der ingen "acceleration" er når karakteren bevæger sig.
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); //Ved at bruge "GetAxixRaw" i stedet for "GetAxis" eliminere man, accelerationen, og tager direkte værdig, så man får nitendo følelsen.
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        //Debug.Log(change); //--> En lille tekst debugger, så jeg kan være sikker på at få de rigtige værdiger printet ud.

        // <Comment> Added by Thor <Comment>
        // Save to Local Player Data
        if (Input.GetKey(KeyCode.F5))
        {
            PlayerState.Instance.localPlayerData.SceneID = Convert.ToInt32(SceneManager.GetActiveScene());
            PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
            PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
            PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;

            GlobalControl.Instance.SaveData();
        }
        // Load from Local Copy Of Player Data
        if (Input.GetKey(KeyCode.F8))
        {
            GlobalControl.Instance.LoadData();
            GlobalControl.Instance.IsSceneLoaded = true;

            int whichScene = GlobalControl.Instance.LocalCopyOfData.SceneID;

            SceneManager.LoadScene(whichScene);
        }

        // </Comment> Added by Thor </Comment>
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
            //animator.SetFloat("MoveX", change.x);
            //animator.SetFloat("MoveY", change.y);
            //animator.SetBool("Moving", true);
        }
        else
        {
          //  animator.SetBool("Moving", false);
        }
    }
    
}
