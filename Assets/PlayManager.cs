using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;
    public UnityEvent<int> OnScoreUpdate;
    int coin = 0; // TODO

    private void OnEnable() 
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);  
        playerWinEvent.OnInvoked.AddListener(PlayerWin); 
    }

    private void OnDisable() 
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);  
        playerWinEvent.OnInvoked.RemoveListener(PlayerWin); 
    }

    public void GameOver()
    {
        finishedText.text = "You Failed";
        finishedCanvas.SetActive(true);
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win!\nScore : " + GetScore();
        finishedCanvas.SetActive(true);
    }

    public void AddCoin(int value=1)
    {
        this.coin += value;
        OnScoreUpdate.Invoke(GetScore());
    }

    public int GetScore()
    {
        return coin;
    }
    public void Quit()
  {
    SceneManager.LoadScene("MainMenu");
  }
}
