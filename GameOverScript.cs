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

    //�N���A��ɂ�����x���������Ƃ�
    public void PushReturnButton()
    {
        //GameOverMethod��1�b��ɌĂяo��
        Invoke("GameScene", 1.0f);       
    }

    private void GameScene()
    {
        //GameOver
        SceneManager.LoadScene("GameScene");
    }
}
