using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoved : MonoBehaviour
{

    [SerializeField] float speedModifier; // ekranda kaydırma islemi hassasiyetini saglar
    [SerializeField] float speed; // oyuncunun hizini saklar
    bool moved;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MoveSpeed();
        Move();
        SmoothDirection();
    }


    // sag sol yapmasini saglar
    void Move()
    {
        if (Input.touchCount > 0)
        {
            Touch touch;

            moved = true;
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }
    }

    // surekli olarak z ekseninde ilerlemesini saglar
    void MoveSpeed()
    {
        if (moved)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
    }

    void SmoothDirection()
    {
        float x = transform.position.x;
        x = Mathf.Clamp(x, -1.25f, 1.25f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
