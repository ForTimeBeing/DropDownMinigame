using UnityEngine;


public class SpawnItems : MonoBehaviour
{
    public GameObject prefab;
    float timeLeft = 1f;

    // Update is called once per frame
    void Update()
    {
        float randomSpawnTime = (Random.Range(.2f, .6f));
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Invoke("Spawn", 0f);
            timeLeft = randomSpawnTime;
        }
    }
    void Spawn()
    {
        float randomNumber = Random.Range(-4.5f, 5f);
        GameObject dip = Instantiate(prefab);
        Destroy(dip, 6);
        dip.transform.position = new Vector2(randomNumber, 6);
        RandomDirection(dip);
    }
    private void RandomDirection(GameObject dip)
    {
        Rigidbody2D myRigidbody = dip.GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range(0, 360), transform.eulerAngles.z);
        float speed = 200;
        myRigidbody.isKinematic = false;
        Vector3 force = transform.forward;
        force = new Vector3(force.x, 1, force.z);
        myRigidbody.AddForce(force * speed);
    }

}
