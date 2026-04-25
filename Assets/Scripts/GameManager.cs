using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Targets;
    private float SpawnRate = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
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

}
