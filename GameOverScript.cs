using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //クリア後にもう一度を押したとき
    public void PushReturnButton()
    {
        //GameOverMethodを1秒後に呼び出す
        Invoke("GameScene", 1.0f);       
    }

    private void GameScene()
    {
        //GameOver
        SceneManager.LoadScene("GameScene");
    }
}
