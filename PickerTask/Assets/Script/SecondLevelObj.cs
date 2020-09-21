using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelObj : MonoBehaviour
{
    //PlayerMoved playerMoved;
    //[SerializeField] GameObject tool;
    //[SerializeField] GameObject tool;
    //[SerializeField] GameObject tool;
    //[SerializeField] GameObject sizeUpTxt;
    //bool stopSpawn = true;
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    playerMoved = FindObjectOfType<PlayerMoved>();
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //}
    //
    //private void OnTriggerEnter(Collider other)
    //{
    //    // toolun hareket etmesini saglar.
    //    StartTool();
    //
    //    // secondObj olusturur.
    //    StartCoroutine(ObjectSpawner());
    //    
    //}
    //
    //void StartTool()
    //{
    //    playerMoved.SetPitControl(false);
    //}
    //
    //IEnumerator SizeUp()
    //{
    //    tool.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    //    sizeUpTxt.gameObject.SetActive(true);
    //    yield return new WaitForSeconds(0.75f);
    //    sizeUpTxt.gameObject.SetActive(false);
    //}
    //
    //IEnumerator ObjectSpawner()
    //{
    //    if (playerMoved.GetMove() && stopSpawn)
    //    {
    //        stopSpawn = false;
    //
    //        for (int i = 0; i < 35; i++)
    //        {
    //            if (positionX > 1)
    //            {
    //                positionX = -1;
    //            }
    //
    //            Instantiate(firstObj, new Vector3(positionX, 0.1f, positionZ), Quaternion.identity);
    //            positionX++;
    //            positionZ++;
    //
    //            yield return new WaitForSeconds(0.15f);
    //        }
    //    }
    //}
}
