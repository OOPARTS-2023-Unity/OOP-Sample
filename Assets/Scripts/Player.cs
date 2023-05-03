using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public GameObject bulletPrefab;

    const float VELOCITY = 5;
    const float JUMP_POWER = 150f;

    float xInput;
    bool jumpInput;
    bool attackInput;

    protected override void Update()
    {
        base.Update(); // 부모의 Update 호출

        GetInput();

        if (attackInput) {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Bullet>().InitAndMove(transform.position, spriteRenderer.flipX ? -1 : 1);
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate(); // 부모의 FixedUpdate 호출

        float v = xInput * VELOCITY;
        rgbody.velocity = new Vector2(v, rgbody.velocity.y);

        if (jumpInput && isOnGround) {
            rgbody.AddForce(new Vector2(0, JUMP_POWER));
        }
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Vertical") > 0 ? true : false;
        attackInput = Input.GetKeyDown(KeyCode.Space);
    }
}
