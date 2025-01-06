using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float bgMinX, bgMaxX, bgMinY, bgMaxY; // Batas background

    void Start()
    {
        // Referensi ke background
        SpriteRenderer bgRenderer = GameObject.Find("Background").GetComponent<SpriteRenderer>();

        // Hitung batas background berdasarkan ukuran sprite
        float bgWidth = bgRenderer.bounds.size.x;
        float bgHeight = bgRenderer.bounds.size.y;

        // Tentukan batas minimum dan maksimum background
        Vector3 bgPosition = bgRenderer.transform.position;
        bgMinX = bgPosition.x - bgWidth / 2;
        bgMaxX = bgPosition.x + bgWidth / 2;
        bgMinY = bgPosition.y - bgHeight / 2;
        bgMaxY = bgPosition.y + bgHeight / 2;
    }

    void Update()
    {
        // Periksa apakah posisi objek berada di luar batas background
        Vector3 pos = transform.position;
        if (pos.x < bgMinX || pos.x > bgMaxX || pos.y < bgMinY || pos.y > bgMaxY)
        {
            Destroy(gameObject);
        }
    }
}
