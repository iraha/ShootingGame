using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    [SerializeField]public float enemySpeed = 2f;
    [SerializeField]public GameObject explosionFX;

    float offset;


    // AddScore取得のため gameManagementを追加
    GameManagement gameManagement;

    // Start is called before the first frame update
    void Start()
    {

        offset = Random.Range(0, 2f*Mathf.PI);
        // gameManagementにヒエラルキー上のGemaMangement、Objectの中のGameManagementをGetComponentで取得
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();

    }

    private void EnemyMovement()
    {
        transform.position -= new Vector3(
            Mathf.Cos(Time.frameCount*0.03f + offset) * 0.03f,
            enemySpeed * Time.deltaTime,
            0);
    }

    // Enemyにぶつかるとあたり判定
    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag("Player") == true) 
        {
            // Playerと当たった時にもExplosionFXが生成されるように設定
            Instantiate(explosionFX, collision.transform.position, transform.rotation);
            FindObjectOfType<GameManagement>().GameOver();
            
        } // Enemyがmissileにぶつかった時のみAddscoreされる
        else if (collision.CompareTag("Missile") == true) 
        {
            gameManagement.AddScore();
        }

        // Enemyにミサイルが当たるとデストロイ
        Destroy(gameObject);

        // Enemyにあったオブジェクトもデストロイ
        Destroy(collision.gameObject);

        // Enemyにオブジェクトがあたったら、ExplosionFXが生成
        Instantiate(explosionFX, transform.position, transform.rotation);

    }
}
