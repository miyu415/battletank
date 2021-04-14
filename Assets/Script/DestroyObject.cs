using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;
    [SerializeField]
    private GameObject effectPrefab2;
    public int objectHP;
    //このメゾットはコライダー同士がぶつかった瞬間に呼び出してる
    private void OnTriggerEnter(Collider other)//戻り値なし
    {
        if(other.CompareTag("shell"))
        {
            objectHP -= 1;
            if (objectHP > 0)
            {
                Destroy(other.gameObject);//ぶつかってきた相手
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
            }
            else
            {
                Destroy(other.gameObject);
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);//引数にしていしたものを壊す、第二引数、指定した時間の後に壊す
                Destroy(this.gameObject);//このスクリプトがくっついているgameObject
            } 
        }
    }
}
