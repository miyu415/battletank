using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
// Update is called once per frame
    void Update()
    {
        TapToNextScene();
    }

    /// <summary>
    /// タップしたらシーン遷移する
    /// </summary>
    void TapToNextScene()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //メインシーンに移動する
            SceneManager.LoadScene("main");
        }
    }
}
