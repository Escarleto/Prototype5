using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody RB;
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
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
