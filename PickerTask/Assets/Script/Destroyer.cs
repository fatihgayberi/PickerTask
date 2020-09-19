using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] GameObject firstObj;

    private void Update()
    {
        PositionUpdate();        
    }

    // geride kalan objeleri ekrandan temizler
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(firstObj.name))
        {
            Destroy(other.gameObject);
        }
    }

    // destroyerin sabit x ve y konumunda ilerlemesini saglar.
    void PositionUpdate()
    {
        transform.position = new Vector3(0, 1.1f, transform.position.z);
    }
}
