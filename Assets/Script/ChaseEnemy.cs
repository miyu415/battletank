using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject target;//インスペクターから登録する情報
    private NavMeshAgent agent;//ターゲットを追跡するためのコンポーネント
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//省略してる場合このスクリプトがくっついているgameObjectから指定した情報を取得する
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)//!=右辺じゃない場合、null＝変数の中身がかっらぽ
        {
            agent.destination = target.transform.position;//ターゲットの位置を目的地に設定する
        }
    }
}
