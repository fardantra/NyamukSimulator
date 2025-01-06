using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 2f;    // Kecepatan dasar
    public float directionChangeInterval = 3f;  // Interval penggantian arah
    private Vector3 direction;  // Arah gerakan

    void Start()
    {
        // Tentukan arah awal
        ChangeDirection();
        // Ubah arah secara periodik
        InvokeRepeating(nameof(ChangeDirection), directionChangeInterval, directionChangeInterval);
    }

    void Update()
    {
        // Gerakkan objek
        transform.position += direction * speed * Time.deltaTime;
    }

    void ChangeDirection()
    {
        // Tentukan arah baru secara acak
        direction = Random.insideUnitCircle.normalized;
    }
}
