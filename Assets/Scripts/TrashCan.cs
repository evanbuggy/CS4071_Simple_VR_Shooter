using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TrashZone>().enterEvent.AddListener(DisableObject);
    }

    private void DisableObject(GameObject go)
    {
        go.SetActive(false);
    }
}
