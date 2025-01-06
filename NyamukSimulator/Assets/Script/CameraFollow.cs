using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // Referensi ke player
    public Transform background;    // Referensi ke background
    public float smoothSpeed = 1f;  // Kecepatan pergerakan kamera
    public Vector3 offset = new Vector3(0, 0, -10); // Offset kamera

    private float minX, maxX, minY, maxY;   // Batas kamera
    private float camHeight, camWidth;  // Ukuran kamera

    void Start()
    {
        // Hitung ukuran kamera berdasarkan Orthographic Size
        Camera cam = Camera.main;
        camHeight = cam.orthographicSize * 2f;
        camWidth = camHeight * cam.aspect;

        // Hitung batas background berdasarkan ukuran sprite
        SpriteRenderer bgRenderer = background.GetComponent<SpriteRenderer>();
        float bgWidth = bgRenderer.bounds.size.x;
        float bgHeight = bgRenderer.bounds.size.y;

        // Hitung batas minimum dan maksimum kamera
        minX = background.position.x - bgWidth / 2 + camWidth / 2;
        maxX = background.position.x + bgWidth / 2 - camWidth / 2;
        minY = background.position.y - bgHeight / 2 + camHeight / 2;
        maxY = background.position.y + bgHeight / 2 - camHeight / 2;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Posisi target kamera mengikuti pemain dengan batas
            float targetX = Mathf.Clamp(player.position.x + offset.x, minX, maxX);
            float targetY = Mathf.Clamp(player.position.y + offset.y, minY, maxY);

            Vector3 desiredPosition = new Vector3(targetX, targetY, offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update posisi kamera
            transform.position = smoothedPosition;
        }
    }
}
