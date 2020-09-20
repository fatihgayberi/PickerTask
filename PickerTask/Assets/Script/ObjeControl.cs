using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeControl : MonoBehaviour
{  
    PlayerMoved playerMoved;
    [SerializeField] GameObject tool;
    [SerializeField] GameObject firstObj;  

    // Start is called before the first frame update
    void Start()
    {
        playerMoved = FindObjectOfType<PlayerMoved>();
    }

    // basarim icin gerekli kontrolleri saglar.
    private void OnTriggerEnter(Collider other)
    {
        // toolun durmasini saglar.
        if (other.gameObject.name.Contains("Tool"))
        {
            StopTool();
        }
        // firsObj nin Y pozisyonunda hareket edebilmesini serbest kilar.
        if (other.gameObject.name.Contains(firstObj.name))
        {
            other.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
        }
    }

    // toolu durdurur.
    void StopTool()
    {
        playerMoved.SetPitControl(true);
        tool.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
