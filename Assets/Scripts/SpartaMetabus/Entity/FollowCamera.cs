using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform targetPlayer;
    float speed = 10f;
    Vector2 offsetVector2 = new Vector2(0, 0);

    void Start()
    {
        if (targetPlayer == null)
            return;

        offsetVector2.x = transform.position.x - targetPlayer.position.x;
        offsetVector2.y = transform.position.y - targetPlayer.position.y;
    }

    void Update()
    {
        if (targetPlayer == null)
            return;

        Vector3 pos = transform.position;
        pos.x = targetPlayer.position.x + offsetVector2.x;
        pos.y = targetPlayer.position.y + offsetVector2.y;
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
    }
}