using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float bgMinX, bgMaxX, bgMinY, bgMaxY; // Batas background
    private float objectHalfWidth, objectHalfHeight; // Setengah ukuran objek

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

        // Hitung ukuran objek berdasarkan bounds dari SpriteRenderer
        SpriteRenderer objectRenderer = GetComponent<SpriteRenderer>();
        if (objectRenderer != null)
        {
            objectHalfWidth = objectRenderer.bounds.size.x / 2;
            objectHalfHeight = objectRenderer.bounds.size.y / 2;
        }
        else
        {
            objectHalfWidth = 0;
            objectHalfHeight = 0;
        }
    }

    void Update()
    {
        // Periksa apakah posisi objek berada di luar batas background
        Vector3 pos = transform.position;
        if (pos.x + objectHalfWidth < bgMinX || pos.x - objectHalfWidth > bgMaxX ||
            pos.y + objectHalfHeight < bgMinY || pos.y - objectHalfHeight > bgMaxY)
        {
            Destroy(gameObject);
        }
    }
}
