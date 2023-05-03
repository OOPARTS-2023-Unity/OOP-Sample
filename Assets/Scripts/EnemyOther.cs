using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOther : EnemyBase
{
    private const float MOVE_MAGNITUDE = 2.0f;

    protected override void Move()
    {
        Vector2 deltaPos = player.transform.position - transform.position;

        rgbody.velocity = new Vector2(deltaPos.normalized.x * MOVE_MAGNITUDE, rgbody.velocity.y);
    }
}
