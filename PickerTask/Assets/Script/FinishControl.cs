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
    Animation animLeft; // left barrierin animasyonu.
    Animation animRight; // right barrierin animasyonu.
    Animation animWin; // tool un platform degisme animasyonu.

    float smooth = 3; // pith patin smooth lerp degerini saklar.
    bool finish; // oyunun basarili oldugunu belirtir.

    private void Start()
    {
        pitObject = FindObjectOfType<PitObject>();
        playerMoved = FindObjectOfType<PlayerMoved>();
        animLeft = barrierLeft.GetComponent<Animation>();
        animRight = barrierRright.GetComponent<Animation>();
        animWin = tool.GetComponent<Animation>();
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
        if (pitObject.GetCounter() >= 10 && !finish)
        {
            finish = true;
            Instantiate(winParticle, tool.transform.position, Quaternion.identity);
            animLeft.Play();
            animRight.Play();
            star1.gameObject.GetComponent<Image>().sprite = starActive;
            yield return new WaitForSeconds(2f);
            animWin.Play();
        }
        // basarisiz oldugunu soyleyen ekrani yukler.
        if (pitObject.GetCounter() < 10 && !finish)
        {
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
