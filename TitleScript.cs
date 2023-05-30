using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    public AudioSource bgm_AudioSource;
    public Slider bgm_Slider;
   
    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
        bgm_AudioSource.volume = bgm_Slider.GetComponent<Slider>().normalizedValue;
    }

    public void PushStartButton()
    {
        //GameOverMethodÇ1ïbå„Ç…åƒÇ—èoÇ∑
        Invoke("GameScene", 1.0f);
    }

    private void GameScene()
    {
        //GameOver
        SceneManager.LoadScene("GameScene");
    }
}
