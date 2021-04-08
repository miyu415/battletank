using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementlnputValue;
    private float turnlnputValue;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        TankMove();
        TankTurn();
    }

    void TankMove()
    {
        movementlnputValue = Input.GetAxis("Vertical");//文字列、input managerのverticalに登録されてるキーコン
        Vector3 movement = transform.forward * movementlnputValue * moveSpeed * Time.deltaTime;//forward(0,0,1)*1.0for-1.0f*moveSeed*1フレーム当たりの差分値(rite,up,forward)
        rb.MovePosition(rb.position + movement);//メソット、rbがアタッチされてるゲームオブジェクトを引数で指定した位置に移動させる
    }

    void TankTurn()
    {
        turnlnputValue=Input.GetAxis("Horizontal");
        float turn = turnlnputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotaition = Quaternion.Euler(0,turn,0);//回転情報を設定できる変数にＹ軸だけ回転させてる
        rb.MoveRotation(rb.rotation * turnRotaition);//Quaternionは掛け算
    }
}
