using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelObj : MonoBehaviour
{
    PlayerMoved playerMoved;
    [SerializeField] GameObject firstObj;
    float positionX; // firstObj' nin ilk spawn olacagi x pozisyonunu saklar.
    float positionZ; // firstObj' nin ilk spawn olacagi z pozisyonunu saklar.
    bool stopSpawn; // spawn yapilmasini durdurur.

    // Start is called before the first frame update
    void Start()
    {
        stopSpawn = true;
        playerMoved = FindObjectOfType<PlayerMoved>();
        positionX = -1f;
        positionZ = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ObjectSpawner());
    }

    // firstObj nin belirlenen konumda 0.15f birim saniye araliklar ile spawn olmasini saglar.
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

                Instantiate(firstObj, new Vector3(positionX, 0.125f, positionZ), Quaternion.identity);
                positionX++;
                positionZ++;

                yield return new WaitForSeconds(0.15f);
            }
        }
    }
}
