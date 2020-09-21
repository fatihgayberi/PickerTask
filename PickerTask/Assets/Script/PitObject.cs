using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitObject : MonoBehaviour
{
    FinishControl finishControl;
    [SerializeField] GameObject obj;
    [SerializeField] GameObject objParticle;
    [SerializeField] Text counterTxt;
    Vector3 empty;
    static int counter = 0; // pite dusen Objleri sayar.

    private void Start()
    {
        finishControl = gameObject.GetComponent<FinishControl>();
        CounterText(counter);
    }

    // pite dusen objeleri siler ve particle olusturur.
    void OnTriggerEnter(Collider other)
    {
        FirstObjDestroyer(other);
    }

    // pite dusen firstObj' yi particle olusturarak siler.
    void FirstObjDestroyer(Collider other)
    {
        if (other.gameObject.name.Contains(obj.name))
        {
            counter++;
            CounterText(counter);
            if (other.transform.gameObject != null)
            {
                empty = other.transform.position;
            }
            Instantiate(objParticle, empty, Quaternion.identity);
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
        string target = finishControl.GetTarget().ToString();
        counterTxt.text = count + " / " + target;
    }
}
