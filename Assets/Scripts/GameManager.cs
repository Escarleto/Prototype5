using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Targets;
    private float SpawnRate = 1.0f;
    private int Score;
    [System.NonSerialized] public bool IsGameActive = true;

    [SerializeField] private TextMeshProUGUI ScoreTXT;
    [SerializeField] private TextMeshProUGUI GameOverTXT;
    [SerializeField] private TextMeshProUGUI TitleTXT;

    private void Start()
    {
        TitleTXT.gameObject.SetActive(true);
        GameOverTXT.gameObject.SetActive(false);
    }

    private IEnumerator SpawnTarget()
    {
        while (IsGameActive == true)
        {
            yield return new WaitForSeconds(SpawnRate);
            int Index = Random.Range(0, Targets.Count);
            Instantiate(Targets[Index]);
        }
    }

    public void UpdateScore(int AddAmount)
    {
        Score += AddAmount;
        ScoreTXT.text = "Score: " + Score;
    }

    public void StartGame(int Difficulty)
    {   
        SpawnRate /= Difficulty;
        IsGameActive = true;
        Score = 0;
        UpdateScore(0);
        TitleTXT.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
    }

    public void GameOver()
    {
        GameOverTXT.gameObject.SetActive(true);
        IsGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
