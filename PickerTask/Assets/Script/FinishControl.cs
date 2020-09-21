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
    [SerializeField] GameObject toolParent;
    [SerializeField] GameObject winParticle;
    [SerializeField] GameObject replayUI;
    [SerializeField] GameObject gamePlayUI;
    [SerializeField] GameObject pitPath;
    [SerializeField] Sprite starActive;
    [SerializeField] GameObject star;
    Animation animLeft; // left barrierin animasyonu.
    Animation animRight; // right barrierin animasyonu.
    Animation animWin; // tool un platform degisme animasyonu.
    [SerializeField] AnimationClip winClip;
    [SerializeField] int target;
    float smooth = 3; // pith patin smooth lerp degerini saklar.
    bool finish; // oyunun basarili oldugunu belirtir.
    Vector3 newPosition;

    private void Start()
    {
        pitObject = FindObjectOfType<PitObject>();
        playerMoved = FindObjectOfType<PlayerMoved>();
        animLeft = barrierLeft.GetComponent<Animation>();
        animRight = barrierRright.GetComponent<Animation>();
        animWin = toolParent.GetComponent<Animation>();
        newPosition = new Vector3(0f, 0f, pitPath.transform.position.z);
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
        if (pitObject.GetCounter() >= target && !finish)
        {
            finish = true;
            Instantiate(winParticle, toolParent.transform.GetChild(0).position, Quaternion.identity);
            animLeft.Play();
            animRight.Play();
            star.gameObject.GetComponent<Image>().sprite = starActive;
            yield return new WaitForSeconds(2f);
            WinClipAnimation();
            pitObject.SetCounter(0);
        }
        // basarisiz oldugunu soyleyen ekrani yukler.
        if (pitObject.GetCounter() < target && !finish)
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
            pitPath.transform.position = Vector3.Lerp(pitPath.transform.position, newPosition, Time.deltaTime * smooth);
        }
    }

    void WinClipAnimation()
    {
        animWin.clip = winClip;
        animWin.Play();
    }

    public int GetTarget()
    {
        return target;
    }
}
