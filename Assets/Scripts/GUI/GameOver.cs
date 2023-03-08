using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Text leaderboardTextValueFirst;
    [SerializeField]
    private Text leaderboardTextNameFirst;

    [SerializeField]
    private Text leaderboardTextValueSecond;
    [SerializeField]
    private Text leaderboardTextNameSecond;

    [SerializeField]
    private Text leaderboardTextValueThird;
    [SerializeField]
    private Text leaderboardTextNameThird;

    [SerializeField]
    public TMP_InputField nicknameInputField;
    

    private int playerIndex;

    public struct Score
    {
        public string name;
        public int points;
    }
    public Text finalPoints;
    
    public Score[] scores = new Score[4];

    //public static int getScore = ScoreCounter.scoreValue;

    void OnEnable()
    {
        StartCoroutine(Wait());
    }
    
    //wait 2 seconds coroutine 
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        GetScores();
        ProcessCurrentScore();
        RenderScores();
    }
    
    
    public void SubmitNickName()
    {
        Debug.Log("submitting");
        if (nicknameInputField.text != null && nicknameInputField.text.Length > 2)
        {
            SaveScores();
            nicknameInputField.gameObject.SetActive(false);
            GetScores();
            RenderScores();
        }
    }
    
    void RenderScores()
    {
        leaderboardTextValueFirst.text = scores[0].points.ToString();
        leaderboardTextNameFirst.text = "1. " + scores[0].name;

        leaderboardTextValueSecond.text = scores[1].points.ToString();
        leaderboardTextNameSecond.text = "2. " + scores[1].name;

        leaderboardTextValueThird.text = scores[2].points.ToString();
        leaderboardTextNameThird.text = "3. " + scores[2].name;
    }
    
    public void onNickNameFieldValueChange()
    {
        nicknameInputField.text = nicknameInputField.text.ToUpper().Substring(0, Mathf.Min(3, nicknameInputField.text.Length));
        
    }
    
    void GetScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].name = PlayerPrefs.GetString("Name" + i);
            scores[i].points = PlayerPrefs.GetInt("Score" + i);
        }
    }
    
    void ProcessCurrentScore()
    {
        scores[3].name = nicknameInputField.text;
        scores[3].points = ScoreCounter.scoreValue;
        
        
        //sort score descending order
        for (int i = 0; i < scores.Length; i++)
        {
            for (int j = i + 1; j < scores.Length; j++)
            {
                if (scores[i].points < scores[j].points)
                {
                    Score temp = scores[i];
                    scores[i] = scores[j];
                    scores[j] = temp;
                }
                else if(scores[i].points == scores[j].points)
                {
                    if(scores[i].name.CompareTo(scores[j].name) > 0)
                    {
                        Score temp = scores[i];
                        scores[i] = scores[j];
                        scores[j] = temp;
                    }
                }
            }
        }

        scores[3].points = 0;

        bool isTopThree = false;
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i].points == ScoreCounter.scoreValue)
            {
                playerIndex = i;
                isTopThree = true;
                break;
            }
        }
        
        if(isTopThree)
        {
            Debug.Log("top 3");
            nicknameInputField.gameObject.SetActive(true);
        }
        
    }
    
    public void clearScores()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void SaveScores()
    {
        for (int i = 0; i < scores.Length - 1 ; i++)
        {
            if(playerIndex == i)
            {
                Debug.Log("saving player's nickname");
                PlayerPrefs.SetString("Name" + i, nicknameInputField.text);
            }
            else
            {
                PlayerPrefs.SetString("Name" + i, scores[i].name);
            }

            PlayerPrefs.SetInt("Score" + i, scores[i].points);
        }
    }


    private void Update()
    {
        finalPoints.text = "Final score: " + ScoreCounter.scoreValue.ToString();
        if (Input.GetKeyDown(KeyCode.Return) && nicknameInputField.gameObject.activeSelf)
        {
            SubmitNickName();
        }

    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0); //Scene number 0 is the Main Menu
    }

}
