using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObjects; // Array untuk amoeba, fish, dan frog
    public Transform player;          // Referensi ke player
    public float spawnDelay = 2f;     // Waktu jeda antar spawn
    private float camHeight, camWidth;

    void Start()
    {
        // Hitung ukuran kamera
        Camera cam = Camera.main;
        camHeight = cam.orthographicSize * 2f;
        camWidth = camHeight * cam.aspect;

        // Mulai proses spawn
        InvokeRepeating(nameof(SpawnObject), 1f, spawnDelay);
    }

    void SpawnObject()
    {
        // Pilih objek untuk di-spawn
        GameObject objToSpawn = spawnObjects[Random.Range(0, spawnObjects.Length)];

        if (objToSpawn != null)
        {
            // Tentukan posisi spawn di luar kamera
            Vector3 spawnPos = GetSpawnPosition();
            Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        }
    }

    Vector3 GetSpawnPosition()
    {
        // Pilih sisi spawn secara acak (atas, bawah, kiri, kanan)
        int side = Random.Range(0, 4);
        Vector3 spawnPos = Vector3.zero;

        switch (side)
        {
            case 0: // Atas
                spawnPos = new Vector3(Random.Range(-camWidth / 2, camWidth / 2), camHeight / 2 + 1f, 0);
                break;
            case 1: // Bawah
                spawnPos = new Vector3(Random.Range(-camWidth / 2, camWidth / 2), -camHeight / 2 - 1f, 0);
                break;
            case 2: // Kiri
                spawnPos = new Vector3(-camWidth / 2 - 1f, Random.Range(-camHeight / 2, camHeight / 2), 0);
                break;
            case 3: // Kanan
                spawnPos = new Vector3(camWidth / 2 + 1f, Random.Range(-camHeight / 2, camHeight / 2), 0);
                break;
        }

        // Offset dengan posisi kamera dan tambahkan offset Z
        spawnPos += Camera.main.transform.position;
        spawnPos.z = Camera.main.transform.position.z + 1f; // Pastikan objek berada di depan kamera
        return spawnPos;
    }
}
