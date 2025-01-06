using UnityEngine;

public class AmoebaMovement : MonoBehaviour
{
    public float speed = 0.5f;  // Kecepatan dasar
    public float wobbleAmplitude = 0.5f; // Amplitudo gerakan terombang-ambing
    public float wobbleFrequency = 1f;  // Frekuensi gerakan terombang-ambing
    private Vector3 direction;  // Arah gerakan

    void Start()
    {
        // Tentukan arah gerakan awal secara acak
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Gerakan dasar
        Vector3 wobble = new Vector3(
            Mathf.Sin(Time.time * wobbleFrequency) * wobbleAmplitude,
            Mathf.Cos(Time.time * wobbleFrequency) * wobbleAmplitude,
            0);
        transform.position += (direction + wobble) * speed * Time.deltaTime;
    }
}
