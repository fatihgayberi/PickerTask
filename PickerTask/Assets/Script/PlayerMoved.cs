using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoved : MonoBehaviour
{
    public Rigidbody rbPlayer;
    [SerializeField] float speedModifier; // ekranda kaydırma islemi hassasiyetini saglar
    [SerializeField] float speed; // oyuncunun hizini saklar
    bool moved;

    void FixedUpdate()
    {
        Move();
        MoveSpeed();
        WallControl();
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
                rbPlayer.velocity = new Vector3(rbPlayer.velocity.x + touch.deltaPosition.x * speedModifier, rbPlayer.velocity.y, rbPlayer.velocity.z);
            }
        }
        else
        {
            rbPlayer.velocity = Vector3.zero;
        }
    }

    // surekli olarak z ekseninde ilerlemesini saglar
    void MoveSpeed()
    {
        if (moved)
        {
            rbPlayer.velocity = new Vector3(rbPlayer.velocity.x, rbPlayer.velocity.y, speed * 1f);

        }
    }

    void WallControl()
    {
        float x = transform.position.x;
        x = Mathf.Clamp(x, -1.25f, 1.25f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public bool GetMove()
    {
        return moved;
    }
}
