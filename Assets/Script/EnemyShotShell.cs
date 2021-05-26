using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    [SerializeField]
    private GameObject enemyShellPrefab;
    [SerializeField]
    private AudioClip shotSound;
    private int interval;
    public float stopTimer = 5.0f;
    [SerializeField]
    private Text stopLabel;
    // Update is called once per frame
    void Update()
    {
        interval += 1;
        stopTimer -= Time.deltaTime;
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }
        stopLabel.text = "" + stopTimer.ToString("0");
        if (interval % 60 == 0)//余りが０の時
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);//enemyShellにInstantiateメソッドを代入してる、指定は不要
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();//rbをコンポーネントしている
            enemyShellRb = enemyShell.GetComponent<Rigidbody>();//.GetComponentを実行する対象となるGameObject型の指定が必要、＝の右側にあるメソッドは戻り値がある
            enemyShellRb.AddForce(transform.forward * shotSpeed);//戻り値なし
            AudioSource.PlayClipAtPoint(shotSound, transform.position);//戻り値なし
            Destroy(enemyShell, 3.0f);
        }
    }

        public void AddStopTimer(float amout)
        {
            stopTimer += amout;
            stopLabel.text = "" + stopTimer.ToString("0");
        }
    
}
