using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameover = false;

    public GameObject myPlayerObject;
    public Rigidbody2D myPlayerRigidbody;
    public SpriteRenderer myPlayerSpriteRender;
    public Collider2D myPlayerCollider;
    // Start is called before the first frame update
    void Start()
    {
        myPlayerObject = GameObject.Find("Player");
        myPlayerRigidbody = myPlayerObject.GetComponent<Rigidbody2D>();
        myPlayerSpriteRender = myPlayerObject.GetComponent<SpriteRenderer>();
        myPlayerCollider = myPlayerObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == true)
        {
            myPlayerRigidbody.isKinematic = true;
            myPlayerSpriteRender.enabled = false;
            myPlayerCollider.enabled = false;
        }
    }
}
