using UnityEngine;


public class SpawnItems : MonoBehaviour
{
    public GameObject DefaultItem;

    public GameObject BombItem;

    public GameObject MysteryBoxPrefab;

    float timeLeft = 1f;

    // Update is called once per frame
    void Update()
    {
        float randomSpawnTime = (Random.Range(.2f, .6f));
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Invoke("SpawnBomb", 0f);
            Invoke("SpawnDefaultFallingObjects", 0f);
            timeLeft = randomSpawnTime;
        }
    }
    void SpawnBomb()
    {
        int randomSpawnTime = (Random.Range(1, 100));
        float randomXspawn = Random.Range(10f, 70f);

        //Rate at which mystery boxes spawn
        if (randomSpawnTime > 95)
        {
            SpawnMysteryBox();
        }
        //Rate at which bombs spawn
        if (randomSpawnTime < 20)
        {
            SpawnBombs();
        }
    }
    void SpawnBombs()
    {
        float randomXspawn = Random.Range(10f, 70f);
        GameObject bombFallingObject = Instantiate(BombItem);
        Destroy(bombFallingObject, 12);
        bombFallingObject.transform.position = new Vector2(randomXspawn, 50);
        RandomDirection(bombFallingObject);
    }
    void SpawnDefaultFallingObjects()
    {
        float randomXspawn = Random.Range(10f, 70f);
        GameObject defaultFallingObject = Instantiate(DefaultItem);
        Destroy(defaultFallingObject, 12);
        defaultFallingObject.transform.position = new Vector2(randomXspawn, 50);
        RandomDirection(defaultFallingObject);
    }
    void SpawnMysteryBox()
    {
        float randomXspawn = Random.Range(10f, 70f);
        GameObject mysteryBox = Instantiate(MysteryBoxPrefab);
        Destroy(mysteryBox, 12);
        mysteryBox.transform.position = new Vector2(randomXspawn, 50);
        RandomDirection(mysteryBox);
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
