using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishControl : MonoBehaviour
{
    PitObject pitObject;
    PlayerMoved playerMoved;
    [SerializeField] GameObject barrierLeft;
    [SerializeField] GameObject barrierRright;
    [SerializeField] GameObject tool;
    [SerializeField] GameObject winParticle;
    [SerializeField] GameObject replayUI;
    [SerializeField] GameObject gamePlayUI;
    [SerializeField] GameObject pitPath;
    [SerializeField] Sprite starActive;
    [SerializeField] GameObject star1;
    Animator animLeft; // left barrierin animasyonu.
    Animator animRight; // right barrierin animasyonu.

    float smooth = 3; // pith patin smooth lerp degerini saklar.
    bool finish; // oyunun basarili oldugunu belirtir.

    private void Start()
    {
        pitObject = FindObjectOfType<PitObject>();
        playerMoved = FindObjectOfType<PlayerMoved>();
        animLeft = barrierLeft.GetComponent<Animator>();
        animRight = barrierRright.GetComponent<Animator>();
    }

    private void Update()
    {
        PitPathPositionUpdate();
    }

    // finish icin counterin kontrolunu saglar.
    public IEnumerator WinControl()
    {
        yield return new WaitForSeconds(3f);

        // eger basarili ise win particleyi sesi ile beraber oynatip bariyerleri animasyon ile acar.
        if (pitObject.GetCounter() >= 20 && !finish)
        {
            finish = true;
            Instantiate(winParticle, tool.transform.position, Quaternion.identity);
            animLeft.SetBool("LeftBarrier", true);
            animRight.SetBool("RightBarrier", true);
            star1.gameObject.GetComponent<Image>().sprite = starActive;
            yield return new WaitForSeconds(2f);
            playerMoved.SetPitControl(false);
        }
        if (pitObject.GetCounter() < 20 && !finish)
        {
            // basarisiz oldugunu soyleyen ekrani yukler.
            replayUI.SetActive(true);
            gamePlayUI.SetActive(false);
            pitObject.SetCounter(0);
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
