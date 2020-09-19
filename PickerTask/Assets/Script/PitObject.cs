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
    static int counter = 0; // pite dusen firstObjleri sayar.

    private void Start()
    {
        finishControl = FindObjectOfType<FinishControl>();
    }

    // pite dusen objeleri siler ve particle olusturur.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(firstObj.name) && other.transform.childCount > 0)
        {
            counter++;
            CounterText(counter);
            FirstObjDestroyer(other);
            StartCoroutine(finishControl.WinControl());
        }
    }

    // pite dusen firstObj' yi particle olusturarak siler.
    void FirstObjDestroyer(Collider other)
    {
        if (other.transform.childCount > 0)
        {
            Instantiate(firstObjParticle, other.transform.position, Quaternion.identity);
            Destroy(other.transform.GetChild(0).gameObject);
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
        counterTxt.text = count + " / 20";
    }
}
