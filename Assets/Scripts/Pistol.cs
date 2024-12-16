using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Pistol : MonoBehaviour
{
    public ParticleSystem particles;
    public GameObject sightline;

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
    }

    public void StopShoot()
    {
        particles.Stop();
    }
}
