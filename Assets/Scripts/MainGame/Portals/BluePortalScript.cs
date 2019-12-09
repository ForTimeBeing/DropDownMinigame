using UnityEngine;

public class BluePortalScript : MonoBehaviour
{
    bool isEnabled = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "FallingObject(Clone)")
        {
            col.transform.position = new Vector3(19, 1f, 0);
            // how much the character should be knocked back
            float magnitude = 500;
            col.rigidbody.AddForce(transform.right * magnitude);
            col.rigidbody.AddForce(transform.up * magnitude);
        }
        else if (col.gameObject.name == "Bomb (Clone)")
        {
            col.transform.position = new Vector3(21, 1f, 0);
            // how much the character should be knocked back
            float magnitude = 500;
            col.rigidbody.AddForce(transform.right * magnitude);
            col.rigidbody.AddForce(transform.up * magnitude);
        }
        else if (col.gameObject.name == "Player")
        {
            col.transform.position = new Vector3(23, -.87f, 0);
            // how much the character should be knocked back
            float magnitude = 10000;
            col.rigidbody.AddForce(transform.right * magnitude);
            col.rigidbody.AddForce(transform.up * magnitude);
        }
    }
}