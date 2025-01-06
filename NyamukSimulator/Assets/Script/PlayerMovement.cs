using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 2f; // Kecepatan dasar
    public float maxSpeedMultiplier = 1.1f; // multiplier kecepatan jika kursor lebih jauh
    public float maxSpeed = 4f; // Batas maksimum kecepatan

    private Vector3 previousCursorPosition; // To track cursor movement

    void Start()
    {
        // Cek posisi kursor sebelumnya
        Cursor.visible = false; // Menyembunyikan kursor
        Cursor.lockState = CursorLockMode.Confined; // Membatasi kursor dalam jendela game
        previousCursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        previousCursorPosition.z = 0; // tetap di 2D
    }

    void Update()
    {
        // Dapatkan current posisi mouse
        Vector3 currentCursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentCursorPosition.z = 0; // Keep in 2D plane

        // Hitung jarak player dengan cursor
        float distanceToCursor = Vector3.Distance(transform.position, currentCursorPosition);

        // Mengatur kecepatan berdasarkan jarak player dengan kursor
        float speed = baseSpeed + (distanceToCursor * maxSpeedMultiplier);
        speed = Mathf.Min(speed, maxSpeed); // Limit speed to maximum value

        // Menggerakan player ke kursor dengan smooth
        transform.position = Vector3.MoveTowards(transform.position, currentCursorPosition, speed * Time.deltaTime);

        // update posisi kursor sebelumnya
        previousCursorPosition = currentCursorPosition;
    }
}