using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Targets;
    private readonly float SpawnRate = 1.0f;
    private int Score;

    [SerializeField] private TextMeshProUGUI ScoreTXT;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
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

}
