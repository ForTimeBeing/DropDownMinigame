using System.Collections;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Animator PortalSpawn;

    public static bool canSpawnPortals = true;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && PortalController.canSpawnPortals == true && myPlayer.specialItem == "portals")
        {
            StartCoroutine(makesSureBothPortalsSpawn());
       

            BoxCollider2D boxcoll = gameObject.GetComponent<BoxCollider2D>();
            GameObject particlesObject = gameObject.transform.Find("Particles").gameObject;
            ParticleSystem particles = particlesObject.GetComponent<ParticleSystem>();
            PortalSpawn.SetBool("OpenPortal", true);

            //Enables box collider and particles for object
            boxcoll.enabled = true;
            particles.Play();
            StartCoroutine(ClosePortal(boxcoll, particles));
            PlayerLightController.hasspecial = false;
        }
    }
    IEnumerator makesSureBothPortalsSpawn()
    {
        yield return new WaitForSeconds(1);
        myPlayer.specialItem = "Nothing";
    }
    IEnumerator ClosePortal(BoxCollider2D boxcoll, ParticleSystem particles)
    {
        yield return new WaitForSeconds(10);
        PortalSpawn.SetBool("ClosePortal", true);
        particles.Stop();
        boxcoll.enabled = false;
    }
}
