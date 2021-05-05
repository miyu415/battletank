using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;//他のスクリプト等々見れたり、値を変えれる

    //privateの状態でもinspector上から設定できるようにするテクニック
    [SerializeField]
    private GameObject shellPrefab = null;

    [SerializeField]
    private AudioClip shotSound = null;

    private float timeBetweenShot = 0.75f;
    private float timer;
    public int shotCount;
    [SerializeField]
    private Text shellLabel;
    //残弾数の最大値を設定する
    public int shotMaxCount = 20;

    private void Start()
    {
        shotCount = shotMaxCount;
        shellLabel.text = "残弾" + shotCount;
    }
    void Update()
    {
        timer += Time.deltaTime;//1フレームあたりの差分値
        //もしもマウスの左ボタンを押したら
        if (Input.GetMouseButtonDown(0) && timer > timeBetweenShot && shotCount > 0)//&&＝かつ　マウスを押したとき前回弾丸を発射してから０．７５秒経っていて残段数がある場合
        {
            shotCount -= 1;
            shellLabel.text = "砲弾" + shotCount;
            timer = 0.0f;
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
    public void AddShell(int amount)
    {
        shotCount += amount;
        if (shotCount>shotMaxCount)
        {
            shotCount = shotMaxCount;
        }
        shellLabel.text = "残弾" + shotCount;
    }
}
