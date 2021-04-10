using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab1;
    [SerializeField]
    private GameObject effectPrefab2;
    public int tankHP;
    private void OnTriggerEnter(Collider other)
    {
        //もしぶつっかてきた相手のTagが”EnemyShell”であったならば
        if(other.gameObject.tag=="EnemyShell")
        {
            //HPを１ずつ減少させる
            tankHP -= 1;
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
            }
        }
    }
}
