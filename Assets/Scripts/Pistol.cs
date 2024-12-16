using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject sightline;
    public ParticleSystem killEffect;

    // Could revisit this and add a boolean so you can't hold shoot
    // or maybe a firing rate
    // ^^^ if this is implemented change particlesystem
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
        sightline.SetActive(true);
    }

    public void StartShoot()
    {
        particles.Play();
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit))
        {
            if (raycastHit.collider.CompareTag("Enemy"))
            {
                Instantiate(killEffect, raycastHit.point, Quaternion.identity);
                Destroy(raycastHit.collider.gameObject);
            }
        }
    }

    public void StopShoot()
    {
        particles.Stop();
    }
}
