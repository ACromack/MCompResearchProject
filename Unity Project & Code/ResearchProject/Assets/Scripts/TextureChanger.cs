﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    float[,,] saved;
    private TerrainData tData;
    public Texture2D craterTex;
    public int xRes, yRes, layers;
    Color[] craterData;


    // Use this for initialization
    void Start ()
    {
        tData = Terrain.activeTerrain.terrainData;
        yRes = tData.alphamapHeight;
        xRes = tData.alphamapWidth;
        layers = tData.alphamapLayers;
        craterData = craterTex.GetPixels();
        saved = tData.GetAlphamaps(0, 0, xRes, yRes);
    }

    //Called when the application quits
    void OnApplicationQuit()
    {
        //Reset the texture of the terrain back to it's original state
        tData.SetAlphamaps(0, 0, saved);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int g = Mathf.RoundToInt(Mathf.Lerp(0, xRes, Mathf.InverseLerp(0, tData.size.x, Mouse.mousePos.x)));
            int b = Mathf.RoundToInt(Mathf.Lerp(0, yRes, Mathf.InverseLerp(0, tData.size.z, Mouse.mousePos.z)));
            g = Mathf.Clamp(g, craterTex.width / 2, xRes - craterTex.width / 2);
            b = Mathf.Clamp(b, craterTex.height / 2, yRes - craterTex.height / 2);
            var area = tData.GetAlphamaps(g - craterTex.width / 2, b - craterTex.height / 2, craterTex.width, craterTex.height);
            for (int x = 0; x < craterTex.height; x++)
            {
                for (int y = 0; y < craterTex.width; y++)
                {
                    for (int z = 0; z < layers; z++)
                    {
                        if (z == 1)
                        {
                            area[x, y, z] += craterData[x * craterTex.width + y].a;
                        }
                        else
                        {
                            area[x, y, z] -= craterData[x * craterTex.width + y].a;
                        }
                    }
                }
            }
            tData.SetAlphamaps(g - craterTex.width / 2, b - craterTex.height / 2, area);
        }
    }
}