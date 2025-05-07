using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI restartText;
    public Button restartButton; 
    
    void Start()
    {
        // scoreText 체크
        if (scoreText == null)
        Debug.LogError("scoreText is null");
        // restartButton 체크
        if (restartButton == null) 
        Debug.LogError("restartButton is null");

        // 클릭 리스너 등록
        restartButton.onClick.AddListener(OnRestartClicked);

        // 게임 시작 시 숨겨두기
        restartButton.gameObject.SetActive(false);

        // if(restartText == null)
        //     Debug.LogError("restart text is null");

        // if(scoreText == null)
        //     Debug.LogError("score text is null");

        // restartText.gameObject.SetActive(false); // 오브젝트를 끈다. 
    }

   public void SetRestart()
   {
         restartButton.gameObject.SetActive(true);
        // restartText.gameObject.SetActive(true);
   }

     private void OnRestartClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
   public void UPdateScore(int score)
   {
        scoreText.text = score.ToString(); // 점수를 올려주는 최신화 작업?
   }
}
