using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameObject firstObj;

    // geride kalan objeleri ekrandan temizler
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(firstObj.name))
        {
            Destroy(other.gameObject);
        }
    }
}
