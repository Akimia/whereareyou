using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region "public変数"
    //メイン画面のボタン
    public GameObject[] MainButton = new GameObject[6];   

    //イメージ
    public Sprite[] ButtonImage = new Sprite[7];

    //CountText
    public GameObject[] HitRowText = new GameObject[3];
    public GameObject[] BlowRowText = new GameObject[3];
    public GameObject[] HitColText = new GameObject[2];
    public GameObject[] BlowColText = new GameObject[2];

    //あとn回
    public GameObject CountText;

    //Check後に表示1
    public GameObject[] SaveImage1 = new GameObject[16];
    //Check後に表示2
    public GameObject[] SaveImage2 = new GameObject[16];
    //Check後に表示3
    public GameObject[] SaveImage3 = new GameObject[16];
  
    //CheckButton
    public GameObject CheckButton;
    //GameClearPanel
    public GameObject GameClearPanel;
    //ScoreText
    public GameObject ScoreText;
    #endregion     

    #region "private変数"
    //ボタンの表示をこの番号で変える
    private int _selectNo;

    //MainButtonのイメージを数値化
    private int[] _mainButtonNo = new int[6];

    //答え
    private int[] _ansNo = new int[6];

    //チェックボタンを押せる回数
    private int _checkButtonCount = 4;  
    #endregion


    void Start()
    {
        //答えをランダム値で作成
        List<int> ans = new List<int>();

        for (int i = 1; i <= 6; i++)
        {
            ans.Add(i);
        }

        while (ans.Count > 0)
        {

            int index = Random.Range(0, ans.Count);

            int ransu = ans[index];
            _ansNo[ans.Count-1] = ransu;
            
            ans.RemoveAt(index);

        }

        //チェックボタンを押せる回数
        CountText.GetComponent<Text>().text = _checkButtonCount.ToString();
    }
       

    // Update is called once per frame
    void Update()
    {
        
    }  

    //ChoiceButtonを押したとき
    public void PushChoiceButton(int no)
    {
        ChangeButtonNo(no);
    }
    
    //ボタンの番号を保存
    private void ChangeButtonNo(int no)
    {
        _selectNo = no;
    }

    //メインボタンを押したとき
    public void PushMainButton(int no)
    {
        ChangeMainButtonNo(no);
    }

    //ChoiceButtonのイメージと入れ替える
    public void ChangeMainButtonNo(int no)
    {  
        MainButton[no].GetComponent<Image>().sprite = ButtonImage[_selectNo+1];
        _mainButtonNo[no] = _selectNo + 1;
    }

    public void PushCheckButton()
    {                
                 
        int[] hitCount = new int[5];
        int[] blowCount = new int[5];

        //Hitの判定
        //MainButton[0]
        //1行目
        for (int i = 0; i < 3; i++)
        {
            if (_mainButtonNo[i] == _ansNo[i])
            {
                hitCount[i] += 1;
                hitCount[3] += 1;
            }           
        }
        //2行目
        for (int i = 3; i < 6; i++)
        {
            if (_mainButtonNo[i] == _ansNo[i])
            {
                hitCount[i-3] += 1;
                hitCount[4] += 1;
            }          
        }

        //Blowの判定
        //1列目
        for (int i = 0; i < 3; i++)
        {
            for (int t = 0; t < 3; t++)
            {
                if (i == t)
                {
                    
                }else if (_ansNo[i] == _mainButtonNo[t])
                {
                    blowCount[3] += 1;
                }
            }               
        }

        //2列目
        for (int i = 3; i < 6; i++)
        {
            for (int t = 3; t < 6; t++)
            {
                if (i == t)
                {
                   
                }else if (_ansNo[i] == _mainButtonNo[t])
                {
                    blowCount[4] += 1;
                }
            }
        }

        //1行目
        if (_ansNo[0] == _mainButtonNo[3])
        {
            blowCount[0] += 1;
        }
        if (_ansNo[3] == _mainButtonNo[0])
        {
            blowCount[0] += 1;
        }

        //2行目
        if (_ansNo[1] == _mainButtonNo[4])
        {
            blowCount[1] += 1;
        }
        if (_ansNo[4] == _mainButtonNo[1])
        {
            blowCount[1] += 1;
        }

        //3行目
        if (_ansNo[2] == _mainButtonNo[5])
        {
            blowCount[2] += 1;
        }
        if (_ansNo[5] == _mainButtonNo[2])
        {
            blowCount[2] += 1;
        }

        HitRowText[0].GetComponent<Text>().text = hitCount[0].ToString();
        HitRowText[1].GetComponent<Text>().text = hitCount[1].ToString();
        HitRowText[2].GetComponent<Text>().text = hitCount[2].ToString();

        BlowRowText[0].GetComponent<Text>().text = blowCount[0].ToString();
        BlowRowText[1].GetComponent<Text>().text = blowCount[1].ToString();
        BlowRowText[2].GetComponent<Text>().text = blowCount[2].ToString();

        HitColText[0].GetComponent<Text>().text = hitCount[3].ToString();
        HitColText[1].GetComponent<Text>().text = hitCount[4].ToString();
       
        BlowColText[0].GetComponent<Text>().text = blowCount[3].ToString();
        BlowColText[1].GetComponent<Text>().text = blowCount[4].ToString();

        //結果を右のイメージに表示する
        SaveImage();

        //残り回数
        if (_checkButtonCount > 0)
        {
            _checkButtonCount -= 1;
        }

        //残りn回
        CountText.GetComponent<Text>().text = _checkButtonCount.ToString();

        GameClear(hitCount[3], hitCount[4]);
    }

    private void SaveImage()
    {
        if (_checkButtonCount == 4)
        {
            //チェック時の値を保存
            for (int i = 0; i < 6; i++)
            {
                SaveImage1[i].GetComponent<Image>().sprite = MainButton[i].GetComponent<Image>().sprite;
            }

            for (int i = 6; i < 9; i++)
            {
                SaveImage1[i].GetComponent<Text>().text = BlowRowText[i - 6].GetComponent<Text>().text;
            }
          
            for (int i = 9; i < 12; i++)
            {
                SaveImage1[i].GetComponent<Text>().text = HitRowText[i - 9].GetComponent<Text>().text;
            }

            for (int i = 12; i < 14; i++)
            {
                SaveImage1[i].GetComponent<Text>().text = BlowColText[i - 12].GetComponent<Text>().text;
            }

            for (int i = 14; i < 16; i++)
            {
                SaveImage1[i].GetComponent<Text>().text = HitColText[i - 14].GetComponent<Text>().text;
            }
        }

        if (_checkButtonCount == 3)
        {
            //チェック時の値を保存
            for (int i = 0; i < 6; i++)
            {
                SaveImage2[i].GetComponent<Image>().sprite = MainButton[i].GetComponent<Image>().sprite;
            }

            for (int i = 6; i < 9; i++)
            {
                SaveImage2[i].GetComponent<Text>().text = BlowRowText[i - 6].GetComponent<Text>().text;
            }

            for (int i = 9; i < 12; i++)
            {
                SaveImage2[i].GetComponent<Text>().text = HitRowText[i - 9].GetComponent<Text>().text;
            }

            for (int i = 12; i < 14; i++)
            {
                SaveImage2[i].GetComponent<Text>().text = BlowColText[i - 12].GetComponent<Text>().text;
            }

            for (int i = 14; i < 16; i++)
            {
                SaveImage2[i].GetComponent<Text>().text = HitColText[i - 14].GetComponent<Text>().text;
            }
        }

        if (_checkButtonCount == 2)
        {
            //チェック時の値を保存
            for (int i = 0; i < 6; i++)
            {
                SaveImage3[i].GetComponent<Image>().sprite = MainButton[i].GetComponent<Image>().sprite;
            }

            for (int i = 6; i < 9; i++)
            {
                SaveImage3[i].GetComponent<Text>().text = BlowRowText[i - 6].GetComponent<Text>().text;
            }

            for (int i = 9; i < 12; i++)
            {
                SaveImage3[i].GetComponent<Text>().text = HitRowText[i - 9].GetComponent<Text>().text;
            }

            for (int i = 12; i < 14; i++)
            {
                SaveImage3[i].GetComponent<Text>().text = BlowColText[i - 12].GetComponent<Text>().text;
            }

            for (int i = 14; i < 16; i++)
            {
                SaveImage3[i].GetComponent<Text>().text = HitColText[i - 14].GetComponent<Text>().text;
            }
        }
    }


    private void GameClear(int hitCount3, int hitCount4)
    {
        if ((hitCount3 == 3) & (hitCount4 == 3))
        {
            GameClearPanel.SetActive(true);
            CheckButton.GetComponent<Button>().enabled = false;               
            ScoreText.GetComponent<Text>().text = (4-_checkButtonCount).ToString() + "回で全員見つけた";

        }
        else if (_checkButtonCount <= 0)
        {
            //GameOverMethodを1秒後に呼び出す
            Invoke("GameOver", 1.0f);
        }
    }

    //クリア後にもう一度を押したとき
    public void PushReturnButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void GameOver()
    {
        //GameOver
        SceneManager.LoadScene("GameOver");
    }
}
