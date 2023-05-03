using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Player player;

    public float INSTANTIATE_TIME = 1f;
    private float currentTime = 0;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > INSTANTIATE_TIME) {
            GameObject enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]);

            enemy.GetComponent<EnemyBase>().InitEnemy(player.gameObject, new Vector2(0, 0));

            currentTime = 0;
        }
    }
}
