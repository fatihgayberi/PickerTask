using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarted : MonoBehaviour
{
    PlayerMoved playerMoved;
    [SerializeField] GameObject levelObj;
    [SerializeField] float positionX; // obj' nin ilk spawn olacagi x pozisyonunu saklar.
    [SerializeField] float positionZ; // obj' nin ilk spawn olacagi z pozisyonunu saklar.
    bool stopSpawn = true; // spawn yapilmasini durdurur.

    // Start is called before the first frame update
    void Start()
    {
        playerMoved = FindObjectOfType<PlayerMoved>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerMoved = FindObjectOfType<PlayerMoved>();

        // toolun hareket etmesini saglar.
        StartTool();

        // secondObj olusturur.
        StartCoroutine(ObjectSpawner());
    }


    // obj nin belirlenen konumda 0.15f birim saniye araliklar ile spawn olmasini saglar.
    IEnumerator ObjectSpawner()
    {
        if (playerMoved.GetMove() && stopSpawn)
        {
            stopSpawn = false;

            for (int i = 0; i < 35; i++)
            {
                if (positionX > 1)
                {
                    positionX = -1;
                }

                Instantiate(levelObj, new Vector3(positionX, levelObj.transform.position.y, positionZ), Quaternion.Euler(0f, 0f, 90f));
                positionX++;
                positionZ++;

                yield return new WaitForSeconds(0.15f);
            }
        }
    }

    void StartTool()
    {
        playerMoved.SetPitControl(false);
    }
}
