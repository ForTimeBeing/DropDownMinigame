using UnityEngine;

public class myPlayer : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
                                     // Use this for initialization
    private float moveHorizontal;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown == false)
        {
            Vector2 v = rb2d.velocity;
            v.x = 0f;
            rb2d.velocity = v;
        }
        moveHorizontal = Input.GetAxis("Horizontal");
        //Store the current horizontal input in the float moveHorizontal.

        //Store the current vertical input in the float moveVertical.

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
    }
}
