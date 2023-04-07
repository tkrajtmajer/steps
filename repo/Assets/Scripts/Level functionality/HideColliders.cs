using UnityEngine;
using UnityEngine.Tilemaps;

public class HideColliders : MonoBehaviour
{
    Tilemap tilemap;

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();

        tilemap.color = new Color(255, 255, 255, 0);
    }

}
