using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift: MonoBehaviour
{
    [SerializeField] GameObject giftParticle;
    [SerializeField] GameObject tool;
    [SerializeField] GameObject sizeUpTxt;
    Renderer rendThis;
    Vector3 thisPosition;

    private void Start()
    {
        thisPosition = this.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        rendThis = this.GetComponent<Renderer>();
        Instantiate(giftParticle, thisPosition, Quaternion.identity);
        StartCoroutine(SizeUp(other));
        this.rendThis.enabled = false;
        Destroy(this.gameObject, 0.75f);
    }

    IEnumerator SizeUp(Collider other)
    {
        tool.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        sizeUpTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sizeUpTxt.gameObject.SetActive(false);        
    }
}
