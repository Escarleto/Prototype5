using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Targets;
    private readonly float SpawnRate = 1.0f;
    private int Score;
    [System.NonSerialized] public bool IsGameActive = true;

    [SerializeField] private TextMeshProUGUI ScoreTXT;
    [SerializeField] private TextMeshProUGUI GameOverTXT;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        GameOverTXT.gameObject.SetActive(false);
        IsGameActive = true;
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

    public void GameOver()
    {
        Debug.Log("Gameover");
        GameOverTXT.gameObject.SetActive(true);
        IsGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
