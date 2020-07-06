using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{

    [SerializeField]public float enemySpeed = 5f;

    [SerializeField]public GameObject explosionFX;

    // AddScore取得のため gameManagementを追加
    GameManagement gameManagement;

    // Start is called before the first frame update
    void Start()
    {
        // gameManagementにヒエラルキー上のGemaMangement、Objectの中のGameManagementをGetComponentで取得
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position -= new Vector3(0, enemySpeed * Time.deltaTime, 0);
        
    }

    // Enemyにぶつかるとあたり判定
    private void OnTriggerEnter2D(Collider2D collision) 
    {

        if (collision.CompareTag("Player") == true) 
        {
            // Playerと当たった時にもExplosionFXが生成されるように設定
            Instantiate(explosionFX, collision.transform.position, transform.rotation);
            
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
