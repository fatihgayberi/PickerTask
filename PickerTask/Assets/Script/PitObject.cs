using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitObject : MonoBehaviour
{
    [SerializeField] GameObject barrierLeft;
    [SerializeField] GameObject barrierRright;
    [SerializeField] GameObject firstObj;
    [SerializeField] GameObject firstObjParticle;
    [SerializeField] GameObject tool;
    [SerializeField] GameObject winParticle;
    int counter;
    Animator animLeft;
    Animator animRight;
    bool finish;

    private void Start()
    {
        animLeft = barrierLeft.GetComponent<Animator>();
        animRight = barrierRright.GetComponent<Animator>();
    }
    // pite dusen objeleri siler ve particle olusturur.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(firstObj.name))
        {
            counter++;
            StartCoroutine(FirstObjDestroyer(other));
            Debug.Log("first obj counter: " + counter);
            StartCoroutine(FinishControl(counter));
        }
    }

    IEnumerator FirstObjDestroyer(Collider other)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(firstObjParticle, other.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Destroy(other.gameObject);
    }

    IEnumerator FinishControl(int counter)
    {
        yield return new WaitForSeconds(4.5f);
        if (counter >= 5 && !finish)
        {
            finish = true;
            Instantiate(winParticle, tool.transform.position, Quaternion.identity);
            animLeft.SetBool("LeftBarrier", true);
            animRight.SetBool("RightBarrier", true);
            //animRight.Play();
        }
    }
}
