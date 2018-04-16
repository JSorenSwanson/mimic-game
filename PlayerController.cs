using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //How fast the player moves
    public float topSpeed = 10f;

    //Tells sprite which direction it is facing
    bool facingRight = true;

    //Get reference to animator
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Physics in Fixed Update
    private void FixedUpdate()
    {
        //Get moving direction
        float move = Input.GetAxis("Horizontal");

        //Add velocity to rigidboy in the move direction * our speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        //If we're facing the negative direction and not facing right, then flip
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }

    void Flip()
    {
        //Say we are facing the opposite direction
        facingRight = !facingRight;

        //Get local scale
        Vector3 theScale = transform.localScale;

        //Flip on x axis
        theScale.x *= -1;

        //Apply the that to the local scale
        transform.localScale = theScale;
    }
}


	/* Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
*/