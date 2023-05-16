using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{
    protected GameObject player;

    protected float currentTime;
    private const float MOVETIME = 2f;
    private const float MOVE_MAGNITUDE = 120f;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Move();
    }

    public void InitEnemy(GameObject playerObj, Vector2 initPos) {
        player = playerObj;
        transform.position = initPos;
    }

    protected virtual void Move() {
        currentTime += Time.deltaTime;

        if (currentTime >= MOVETIME) {
            Vector2 deltaPos = player.transform.position - transform.position;

            rgbody.AddForce(deltaPos.normalized * MOVE_MAGNITUDE);

            currentTime = 0;
        }
    }
}
