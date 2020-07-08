using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{

    // ミサイルの発車位置
    public Transform firePoint; 
    public GameObject missile;

    [SerializeField]public float playerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShot();

    }

    private void PlayerShot()
    {

        // Playerのミサイルを生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile, firePoint.position, transform.rotation);
        }

    }

    private void PlayerMovement()
    {
        // Playerの動き
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 validPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * playerSpeed;

        // playerの動ける範囲を制御
        validPosition = new Vector3(
            Mathf.Clamp(validPosition.x, -4.5f, 4.5f),
            Mathf.Clamp(validPosition.y, -9f, 7f),
            validPosition.z
        );

        transform.position = validPosition;
    }
}
