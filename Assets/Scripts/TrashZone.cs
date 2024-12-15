using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrashZone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> enterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (targetTag.Contains(other.gameObject.tag))
        {
            enterEvent.Invoke(other.gameObject);
        }
    }
}
