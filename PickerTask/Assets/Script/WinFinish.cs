using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFinish : MonoBehaviour
{
    [SerializeField] GameObject finishTxt;
    [SerializeField] GameObject confettiParticle;

    private void OnTriggerEnter(Collider other)
    {
        finishTxt.gameObject.SetActive(true);
        ConfettiMaker();
    }

    void ConfettiMaker()
    {
        Instantiate(confettiParticle, new Vector3(2f, -0.5f, 117f), Quaternion.identity);
        Instantiate(confettiParticle, new Vector3(-2f, -0.5f, 117f), Quaternion.identity);
    }
}
