using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{
    private Rigidbody RB;
    private GameManager Manager;
    [SerializeField] private ParticleSystem Explosion;
    [SerializeField] private int ScoreValue;

    private readonly float MaxSpd = 16f;
    private readonly float MinSpd = 12f;
    private readonly float MaxTorque = 10f;
    private readonly float xRange = 4f;
    private readonly float SpawnPosY = -6f;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();

        RB.AddForce(RandomForce(), ForceMode.Impulse);
        RB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(MinSpd, MaxSpd);
    }

    private float RandomTorque()
    {
        return Random.Range(-MaxTorque, MaxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), SpawnPosY);
    }

    private void OnMouseDown()
    {
        Manager.UpdateScore(ScoreValue);
        Instantiate(Explosion, transform.position, Explosion.transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
