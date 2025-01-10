using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 2f; // Kecepatan dasar
    public float maxSpeedMultiplier = 1.1f; // Multiplier kecepatan jika kursor lebih jauh
    public float maxSpeed = 8f; // Batas maksimum kecepatan

    private SpriteRenderer playerRenderer;

    void Start()
    {
        // Sembunyikan kursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        // Ambil komponen SpriteRenderer untuk menghitung ukuran player
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Dapatkan posisi kursor dalam dunia
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0; // Tetap di bidang 2D

        // Hitung ukuran objek player
        float halfWidth = playerRenderer.bounds.size.x / 2;
        float halfHeight = playerRenderer.bounds.size.y / 2;

        // Hitung batas layar berdasarkan ukuran kamera
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float minX = cam.transform.position.x - camWidth / 2 + halfWidth;
        float maxX = cam.transform.position.x + camWidth / 2 - halfWidth;
        float minY = cam.transform.position.y - camHeight / 2 + halfHeight;
        float maxY = cam.transform.position.y + camHeight / 2 - halfHeight;

        // Koreksi posisi target agar berada dalam batas kamera
        cursorPosition.x = Mathf.Clamp(cursorPosition.x, minX, maxX);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, minY, maxY);

        // Hitung arah pergerakan
        Vector3 directionToMove = cursorPosition - transform.position;

        // Hitung jarak ke kursor
        float distanceToCursor = directionToMove.magnitude;

        // Normalisasi arah agar panjangnya selalu 1
        Vector3 normalizedDirection = directionToMove.normalized;

        // Mengatur kecepatan berdasarkan jarak ke kursor
        float speed = baseSpeed + (distanceToCursor * maxSpeedMultiplier);
        speed = Mathf.Min(speed, maxSpeed); // Batasi kecepatan maksimum

        // Gerakkan player ke arah kursor dengan kecepatan yang dihitung
        transform.position += normalizedDirection * speed * Time.deltaTime;

        if (PauseMenu.isPaused == true) // Jika di-pause, cursornya akan muncul kembali
        {
            Cursor.visible = true; 
        }
        else 
        {
            Cursor.visible = false;
        }
    }
}
