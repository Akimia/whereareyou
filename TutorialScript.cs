using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    #region "public変数"
    //説明ボックス
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject TutorialBrow;
    public GameObject TutorialHit;
    
    //赤枠
    public GameObject ChoiceImage;
    public GameObject MainImage;
    public GameObject CheckImage;
    public GameObject TateImage;
    public GameObject YokoImage;

    //StartButton
    public GameObject StartButton;

    //TutorialPanel
    public GameObject TutorialPanel;
    public GameObject HitBlowTutorial;    
    #endregion

    #region "private変数"
    //Tutorialを表示したか管理するフラグ
    private bool _TutorialFlag1 = false;
    private bool _TutorialFlag2 = false;
    private bool _TutorialFlag3 = false;

    //StartButtonを表示するタイミングを管理する
    private bool _StartFlag = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Tutorial1表示
        Tutorial1.SetActive(true);
        ChoiceImage.SetActive(true);
        _TutorialFlag1 = true;

        //その他Tutorialは非表示
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        TutorialBrow.SetActive(false);
        TutorialHit.SetActive(false);        
        MainImage.SetActive(false);
        CheckImage.SetActive(false);
        TateImage.SetActive(false);
        YokoImage.SetActive(false);
        StartButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (_StartFlag == true)
        {
            StartButton.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
           

            //Tutorialを順番に表示する
            if (_TutorialFlag1 == true && _TutorialFlag2 == false)
            {
                //Tutorial1非表示
                Tutorial1.SetActive(false);
                ChoiceImage.SetActive(false);

                //Tutorial2表示
                Tutorial2.SetActive(true);
                MainImage.SetActive(true);
                _TutorialFlag2 = true;
            }else if (_TutorialFlag1 == true && _TutorialFlag2 == true && _TutorialFlag3 == false)
            {
                //Tutorial2非表示
                Tutorial2.SetActive(false);
                MainImage.SetActive(false);

                //Tutorial3表示
                Tutorial3.SetActive(true);
                CheckImage.SetActive(true);
                _TutorialFlag3 = true;
            }else if (_TutorialFlag1 == true && _TutorialFlag2 == true && _TutorialFlag3 == true)
            {
                //Hit&Blowの説明

                //Tutorial3非表示
                Tutorial3.SetActive(false);
                CheckImage.SetActive(false);

                TutorialBrow.SetActive(true);
                TutorialHit.SetActive(true);
                TateImage.SetActive(true);
                YokoImage.SetActive(true);

                _StartFlag = true;
            }
        }
    }

    //StartButtonを押したとき
    public void PushStartButton()
    {
        TutorialPanel.SetActive(false);
        HitBlowTutorial.SetActive(true);
    }

    //Skip
    public void PushSkipButton()
    {
        _StartFlag = true;
    }

}
