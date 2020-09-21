using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarted : MonoBehaviour
{
    PlayerMoved playerMoved;
    [SerializeField] GameObject levelObj;
    [SerializeField] float positionX; // firstObj' nin ilk spawn olacagi x pozisyonunu saklar.
    [SerializeField] float positionZ; // firstObj' nin ilk spawn olacagi z pozisyonunu saklar.
    bool stopSpawn = true; // spawn yapilmasini durdurur.

    // Start is called before the first frame update
    void Start()
    {
        playerMoved = FindObjectOfType<PlayerMoved>();
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(ObjectSpawner());
    }

    private void OnTriggerEnter(Collider other)
    {
        playerMoved = FindObjectOfType<PlayerMoved>();

        // toolun hareket etmesini saglar.
        StartTool();

        // secondObj olusturur.
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

                Instantiate(levelObj, new Vector3(positionX, levelObj.transform.position.y, positionZ), Quaternion.identity);
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
