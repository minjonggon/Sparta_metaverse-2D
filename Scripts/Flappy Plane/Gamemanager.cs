using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
   static Gamemanager gameManager; // 싱글톤 패턴 기본적인 형태, 자기를 참조할 수 있는 static 변수
   public static Gamemanager Instance { get { return gameManager; } } // 변수를 외부로 가져갈 수 있는 프로퍼티 하나
    // 외부에서 instance라고 하는 프로퍼티를 통해 하나의 객체를 쉽게 접근할수있다.

    private int currentScore = 0;

    UIManager uiManager; // ui매니저 접근하게 만든다.
    public UIManager UIManager { get { return uiManager; } } // 외부에서 ui매니저를 쓸수도 있어서 만듬
    private void Awake() // 가장 최초의 객체를 설정해주는 작업
    {
        gameManager = this;
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Start()
    {
        uiManager.UPdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
       currentScore += score;
       Debug.Log("Score: " + currentScore); 
       uiManager.UPdateScore(currentScore);
    }
}
