using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFinish : MonoBehaviour
{
    [SerializeField] GameObject finishTxt;
    [SerializeField] GameObject confettiParticle;
    [SerializeField] GameObject gamePlayUI;

    private void OnTriggerEnter(Collider other)
    {
        finishTxt.gameObject.SetActive(true);
        gamePlayUI.gameObject.SetActive(false);
        ConfettiMaker();
    }

    void ConfettiMaker()
    {
        Instantiate(confettiParticle, new Vector3(2f, -0.5f, 117f), Quaternion.identity);
        Instantiate(confettiParticle, new Vector3(-2f, -0.5f, 117f), Quaternion.identity);
    }
}
