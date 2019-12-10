using UnityEngine;
using System.Collections;

public class myPlayer : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
                                     // Use this for initialization
    private float moveHorizontal;

    public GameObject explosion;

    public static string specialItem;

    public UnityEngine.Experimental.Rendering.LWRP.Light2D m_Light2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myPlayer.specialItem = "Nothing";
    }

    // Update is called once per frame
    void Update()
    {
        //Character movement
        if (Input.anyKeyDown == false)
        {
            Vector2 v = rb2d.velocity;
            v.x = 0f;
            rb2d.velocity = v;
        }
        moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        //End Character movement
    }

    //Used for all collisions
    void OnCollisionEnter2D(Collision2D col)
    {
        //Bomb Explosion
        if (col.gameObject.name == "Bomb" || col.gameObject.name == "Bomb (Clone)")
        {
            m_Light2D.pointLightOuterRadius = m_Light2D.pointLightOuterRadius * .8f;
            Vector3 force = transform.position - col.transform.position;
            PlayerLightController.flashred = true;
            StartCoroutine(ApplyExplosionMove(force));
            GameObject bombExplosion = Instantiate(explosion);
            CameraShake.shakeScreen = true;
            Destroy(bombExplosion, 5);
            bombExplosion.transform.position = col.transform.position;
            Destroy(col.gameObject);
            PlayerLightController.hasspecial = true;
        }
        //End Bomb explosion

        //Collosion with mystery box
        if (col.gameObject.name == "mysterybox" || col.gameObject.name == "mysterybox(Clone)")
        {
            float randomNumber = Random.Range(1, 1);
            if(randomNumber == 1){
                PlayerLightController.playerlightcolor = "#9C9CFF";
                PlayerLightController.changelightcolor = true;
                PlayerLightController.hasspecial = true;
                myPlayer.specialItem = "portals";
            }
            Destroy(col.gameObject);
        }
    }

  
    //Knockback when getting hit by bomb
    IEnumerator ApplyExplosionMove(Vector3 force)
    {
        float magnitude = 5000;
        force.Normalize();
        for (int i = 0; i < 7; i++)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
            yield return new WaitForSeconds(.01f);
        }
    }
}
