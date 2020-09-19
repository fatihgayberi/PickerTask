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
    [SerializeField] GameObject pitPath;
    [SerializeField] GameObject replayUI;
    int counter; // pite dusen firstObjleri sayar.
    Animator animLeft; // left barrierin animasyonu.
    Animator animRight; // right barrierin animasyonu.
    bool finish; // oyunun basarili oldugunu belirtir.
    float smooth = 3; // pith patin smooth lerp degerini saklar.

    private void Start()
    {
        animLeft = barrierLeft.GetComponent<Animator>();
        animRight = barrierRright.GetComponent<Animator>();
    }

    private void Update()
    {
        PitPathPositionUpdate();
    }

    // pite dusen objeleri siler ve particle olusturur.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(firstObj.name))
        {
            counter++;
            FirstObjDestroyer(other);
            StartCoroutine(FinishControl(counter));
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

    // finish icin counterin kontrolunu saglar.
    IEnumerator FinishControl(int counter)
    {
        yield return new WaitForSeconds(3f);

        // eger basarili ise win particleyi sesi ile beraber oynatip bariyerleri animasyon ile acar.
        if (counter >= 5 && !finish)
        {
            finish = true;
            Instantiate(winParticle, tool.transform.position, Quaternion.identity);
            animLeft.SetBool("LeftBarrier", true);
            animRight.SetBool("RightBarrier", true);
        }
        else
        {
            // basarisiz oldugunu soyleyn ekrani yukler.
            replayUI.SetActive(true);
        }
    }

    // pitPath ile yolu tamamlar.
    void PitPathPositionUpdate()
    {
        if (finish)
        {
            Vector3 newPosition = new Vector3(0f, 0f, 47.25f); // pitPathin yolu tamamlamak icin ideal pozisyonu.
            pitPath.transform.position = Vector3.Lerp(pitPath.transform.position, newPosition, Time.deltaTime * smooth);
        }
    }
}
