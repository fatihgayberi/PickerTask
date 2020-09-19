using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitObject : MonoBehaviour
{
    FinishControl finishControl;
    [SerializeField] GameObject firstObj;
    [SerializeField] GameObject firstObjParticle;
    [SerializeField] Text counterTxt;
    Vector3 empty;
    static int counter = 0; // pite dusen firstObjleri sayar.

    private void Start()
    {
        finishControl = FindObjectOfType<FinishControl>();
    }

    // pite dusen objeleri siler ve particle olusturur.
    void OnTriggerEnter(Collider other)
    {
        FirstObjDestroyer(other);
    }

    // pite dusen firstObj' yi particle olusturarak siler.
    void FirstObjDestroyer(Collider other)
    {
        if (other.gameObject.name.Contains(firstObj.name))
        {
            counter++;
            CounterText(counter);
            if (other.transform.gameObject != null)
            {
                empty = other.transform.position;
            }
            Instantiate(firstObjParticle, empty, Quaternion.identity);
            Destroy(other.transform.gameObject);
            StartCoroutine(finishControl.WinControl());
        }
    }

    public int GetCounter()
    {
        return counter;
    }

    public void SetCounter(int count)
    {
        counter = count;
    }

    void CounterText(int count)
    {
        counterTxt.text = count + " / 10";
    }
}
