using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rgbody;

    const int DAMAGE = 5;
    const float VELOCITY = 5f;

    private void Awake()
    {
        rgbody = GetComponent<Rigidbody2D>();
    }

    public void InitAndMove(Vector2 initPos, int xDirection)
    {
        transform.position = initPos;

        rgbody.velocity = new Vector2(xDirection * VELOCITY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBase target = collision.gameObject.GetComponent<CharacterBase>();

        if (target != null && !collision.tag.Equals("Player"))
        {
            target.LoseHP(DAMAGE);
            Destroy(gameObject);
        }

        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
