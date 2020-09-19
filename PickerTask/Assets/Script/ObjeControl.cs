using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeControl : MonoBehaviour
{
    [SerializeField] GameObject tool;
    [SerializeField] GameObject firstObj;
    PlayerMoved playerMoved;

    // Start is called before the first frame update
    void Start()
    {
        playerMoved = FindObjectOfType<PlayerMoved>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Tool"))
        {
            StopTool();
        }
        if (other.gameObject.name.Contains(firstObj.name))
        {
            other.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
        }
    }

    void StopTool()
    {
        playerMoved.SetPitControl(true);
        tool.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
