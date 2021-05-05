using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;
    [SerializeField]
    private AudioClip getSound;
    private TankHealth th;
    private int reward = 3;

    private void OnTriggerEnter(Collider other)//他のゲームオブジェクトのコライダー同士がぶつかった時
    {
        if (other.gameObject.tag == "Player")
        {
            th = other.gameObject.GetComponent<TankHealth>();

            th.AddHP(reward);
            Destroy(gameObject);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
        }
    }

}
