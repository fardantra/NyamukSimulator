using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f; // Kecepatan konstan player

    private Vector3 currentCursorPosition;
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
        currentCursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentCursorPosition.z = 0; // Tetap di bidang 2D

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
        float targetX = Mathf.Clamp(currentCursorPosition.x, minX, maxX);
        float targetY = Mathf.Clamp(currentCursorPosition.y, minY, maxY);

        Vector3 clampedCursorPosition = new Vector3(targetX, targetY, 0);

        // Hitung arah pergerakan
        Vector3 directionToMove = clampedCursorPosition - transform.position;

        // Jika player sudah sangat dekat dengan target, jangan bergerak
        if (directionToMove.magnitude <= 0.01f)
            return;

        // Normalisasi arah agar gerakan selalu konstan
        Vector3 normalizedDirection = directionToMove.normalized;

        // Gerakkan player ke arah target dengan kecepatan konstan
        transform.position += normalizedDirection * moveSpeed * Time.deltaTime;
    }
}
