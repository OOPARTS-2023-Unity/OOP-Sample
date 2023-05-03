using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour, IHasHP
{
    protected Rigidbody2D rgbody;
    protected SpriteRenderer spriteRenderer;

    protected const int MAX_HP = 20;
    protected int hp;

    protected bool isOnGround = false;

    protected virtual void Awake() {
        rgbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        hp = MAX_HP;
    }

    protected virtual void Update()
    {
        if (hp <= 0)
        {
            OnDead();
        }
    }

    protected virtual void FixedUpdate() {
        if (rgbody.velocity.x > 0.1 && spriteRenderer.flipX == true)
        {
            spriteRenderer.flipX = false;
        }

        else if (rgbody.velocity.x < -0.1 && spriteRenderer.flipX == false)
        {
            spriteRenderer.flipX = true;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Wall") {
            Destroy(gameObject);
        }
    }

    public void RecoverHP(int cure)
    {
        hp += cure;
        if (hp > MAX_HP)
        {
            hp = MAX_HP;
        }
    }

    public void LoseHP(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
        }
    }

    public virtual void OnDead()
    {
        Destroy(gameObject);
    }
}
