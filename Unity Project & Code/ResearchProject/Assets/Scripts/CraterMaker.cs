﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterMaker : MonoBehaviour {

    private TerrainData tData;
    private float[,] saved;
    float[,] areaT;
    public Texture2D craterTex;
    int xRes, yRes;
    Color[] craterData;

    // Use this for initialization
    void Start ()
    {
        //Set the terrain data to be that of the associated terrain
        tData = Terrain.activeTerrain.terrainData;

        //Store the width and height of the heightmap
        xRes = tData.heightmapWidth;
        yRes = tData.heightmapHeight;

        //Store the original state of the heightmap so that the terrain can be reset
        saved = tData.GetHeights(0, 0, xRes, yRes);

        craterData = craterTex.GetPixels();
    }

    // Upon quitting the application
    void OnApplicationQuit()
    {
        tData.SetHeights(0, 0, saved);
    }

    // Update is called once per frame
    void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            int x = Mathf.RoundToInt(Mathf.Lerp(0, xRes, Mathf.InverseLerp(0, tData.size.x, Mouse.mousePos.x)));
            int z = Mathf.RoundToInt(Mathf.Lerp(0, xRes, Mathf.InverseLerp(0, tData.size.z, Mouse.mousePos.z)));

            x = Mathf.Clamp(x, craterTex.width / 2, xRes - craterTex.width / 2);
            z = Mathf.Clamp(z, craterTex.height / 2, yRes - craterTex.height / 2);

            areaT = tData.GetHeights(x - craterTex.width / 2, z - craterTex.height / 2, craterTex.width, craterTex.height);

            for (int i = 0; i < craterTex.height; i++)
            {
                for(int j = 0; j < craterTex.width; j++)
                {
                    areaT [i,j] = areaT[i, j] - craterData[i * craterTex.width + j].a;
                    Debug.Log("Crater Negative : " + areaT[i, j]);
                }
            }

            tData.SetHeights(x - craterTex.width / 2, z - craterTex.height / 2, areaT);

        }
	}

}