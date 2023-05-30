using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    #region "public�ϐ�"
    //�����{�b�N�X
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject TutorialBrow;
    public GameObject TutorialHit;
    
    //�Ԙg
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

    #region "private�ϐ�"
    //Tutorial��\���������Ǘ�����t���O
    private bool _TutorialFlag1 = false;
    private bool _TutorialFlag2 = false;
    private bool _TutorialFlag3 = false;

    //StartButton��\������^�C�~���O���Ǘ�����
    private bool _StartFlag = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Tutorial1�\��
        Tutorial1.SetActive(true);
        ChoiceImage.SetActive(true);
        _TutorialFlag1 = true;

        //���̑�Tutorial�͔�\��
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
           

            //Tutorial�����Ԃɕ\������
            if (_TutorialFlag1 == true && _TutorialFlag2 == false)
            {
                //Tutorial1��\��
                Tutorial1.SetActive(false);
                ChoiceImage.SetActive(false);

                //Tutorial2�\��
                Tutorial2.SetActive(true);
                MainImage.SetActive(true);
                _TutorialFlag2 = true;
            }else if (_TutorialFlag1 == true && _TutorialFlag2 == true && _TutorialFlag3 == false)
            {
                //Tutorial2��\��
                Tutorial2.SetActive(false);
                MainImage.SetActive(false);

                //Tutorial3�\��
                Tutorial3.SetActive(true);
                CheckImage.SetActive(true);
                _TutorialFlag3 = true;
            }else if (_TutorialFlag1 == true && _TutorialFlag2 == true && _TutorialFlag3 == true)
            {
                //Hit&Blow�̐���

                //Tutorial3��\��
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

    //StartButton���������Ƃ�
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
