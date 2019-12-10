using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    public ParticleSystem emit;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            ScoreboardManager.Instance.addScore();
            CmdDetachParticles();
            Destroy(gameObject);
        }
    }

    // Call this immediately before you destroy your missile
    void CmdDetachParticles()
    {
        // This splits the particle off so it doesn't get deleted with the parent
        emit.transform.parent = null;

        // this stops the particle from creating more bits
        emit.Stop();
    }


}
