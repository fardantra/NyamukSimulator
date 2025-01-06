using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform player; // Referensi ke pemain
    public Transform background; // Referensi ke background

    private float minX, maxX, minY, maxY; // Batas kamera
    private float camHeight, camWidth; // Ukuran kamera

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
            // Posisi target kamera mengikuti pemain
            float targetX = Mathf.Clamp(player.position.x, minX, maxX);
            float targetY = Mathf.Clamp(player.position.y, minY, maxY);

            // Perbarui posisi kamera
            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}
