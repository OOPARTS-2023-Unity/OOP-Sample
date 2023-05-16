using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFly : EnemyBase
{
    private const float MOVE_MAGNITUDE = 2.0f;

    protected override void Move()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 3f) {
            Vector2 deltaPos = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

            rgbody.velocity = deltaPos * MOVE_MAGNITUDE;

            currentTime = 0;
        }   
    }
}
