using UnityEngine;
using UnityEngine.UI;

public class DIfficultyButton : MonoBehaviour
{
    private Button DIFButton;
    private GameManager Manager;
    [SerializeField] private int Difficulty;

    private void Start()
    {
        DIFButton = GetComponent<Button>();
        DIFButton.onClick.AddListener(SetDifficulty);
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SetDifficulty()
    {
        Manager.StartGame(Difficulty);
    }
}
