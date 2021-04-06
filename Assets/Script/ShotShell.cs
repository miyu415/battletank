using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;

    //privateの状態でもinspector上から設定できるようにするテクニック。
    [SerializeField]
    private GameObject shellPrefab;

    [SerializeField]
    private AudioClip shotSound;
    
    void Update()
    {
        //もしもマウスの左ボタンを押したら
        if(Input.GetKeyDown(KeyCode.Space))
        {
           //砲弾のプレハブを実体化する
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            //砲弾に付いてるRigidbodyにアクセスする
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            //forward（z軸）の方向に力を加える
            shellRb.AddForce(transform.forward * shotSpeed);
            //発射した砲弾を3秒後に破壊する
            Destroy(shell, 3.0f);
            //砲弾の発射音をだす
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }
}
