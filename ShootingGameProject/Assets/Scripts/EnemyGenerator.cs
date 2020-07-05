using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

        // InvokeRepeating("この関数を呼び出す", 秒後に, 秒刻みで)
        InvokeRepeating("Spawn", 2f, 0.5f);
        //Spawn();
    }

    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-5.0f, 5.0f),
            transform.position.y,
            transform.position.z
            );

        Instantiate(enemy, spawnPosition, transform.rotation);
    }

    



}
