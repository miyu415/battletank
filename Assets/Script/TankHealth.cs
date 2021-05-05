using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンを変える命令を出すための宣言
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab1;
    [SerializeField]
    private GameObject effectPrefab2;
    public int tankHP;
    [SerializeField]
    private Text HPLabel;
    private int tankMaxHP = 10;

    private void Start()
    {
        tankHP = tankMaxHP;
        HPLabel.text = "HP:" + tankHP;
    }
    private void OnTriggerEnter(Collider other)
    {
        //もしぶつっかてきた相手のTagが”EnemyShell”であったならば
        if(other.gameObject.tag=="EnemyShell")
        {
            //HPを１ずつ減少させる
            tankHP -= 1;
            HPLabel.text = "HP" + tankHP;
            //ぶつっかてきた相手側を破壊する
            Destroy(other.gameObject);
            if(tankHP>0)
            {
                GameObject effect1 = Instantiate(effectPrefab1,transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);
                Destroy(gameObject);
                this.gameObject.SetActive(false);//非表示にする
                Invoke("GoToGameOver", 1.5f);//1.5秒後にGoToGameOver実行する
            }
        }
    }
    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");//シーンを変えるためのメソッド、GameOverのシーンに移動する
    }

    public void AddHP(int amount)
    {
        tankHP += amount;
        if(tankHP>tankMaxHP)
        {
            tankHP = tankMaxHP;
        }
        HPLabel.text = "HP:" + tankHP;

    }
   
}

