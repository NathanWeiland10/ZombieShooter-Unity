using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoofTiles : MonoBehaviour
{
    public Tilemap tileMap;
    private TilemapCollider2D collider;
    private TilemapRenderer renderer;

    void Start ()
    {
        collider = GetComponent<TilemapCollider2D>();
        renderer = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            renderer.enabled = false;
            renderer.enabled = false;
        }


    }

    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            renderer.enabled = true;
            renderer.enabled = true;
        }


    }

    


}
