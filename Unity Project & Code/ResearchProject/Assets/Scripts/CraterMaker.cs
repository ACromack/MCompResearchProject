using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraterMaker : MonoBehaviour {

    // Variables relating to the terrain deformation
    private TerrainData tData;
    private float[,] saved;
    //float[,] areaT;
    public Texture2D craterTex;
    int xRes, yRes;
    int test;
    Color[] craterData;
    static public bool done = false;
    public bool tdBlocked = false;

    // Variables relating to the deformation meter
    public int startingDeformUsage = 100;
    public int currentDeformUsage;
    public Slider deformUseSlider;

    // Variables related to logging
    public int downDeformUsage = 0;
    public int upDeformUsage = 0;

    // When the script is awakened, reset the deformation usage meter
    void Awake()
    {
        currentDeformUsage = startingDeformUsage;
    }


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
        // Check if the level is complete/being reset, then reset the terrain to default and the logged usage of the deformation
        if(done == true)
        {
            tData.SetHeights(0, 0, saved);
            downDeformUsage = 0;
            upDeformUsage = 0;
            done = false;
}

        // If the terrain deformation usage meter is above 0 and the usage is not blocked, execute the following
        if(currentDeformUsage > 0 && tdBlocked == false)
        {
            // If the player presses the button to deform the terrain downwards
            if (Input.GetKey(KeyCode.Q) || Input.GetAxis("Fire1") > 0)
            {
                int x = Mathf.RoundToInt(Mathf.Lerp(0, xRes, Mathf.InverseLerp(0, tData.size.x, Player.currentPosition.x)));
                int z = Mathf.RoundToInt(Mathf.Lerp(0, xRes, Mathf.InverseLerp(0, tData.size.z, Player.currentPosition.z)));

                x = Mathf.Clamp(x, craterTex.width / 2, xRes - craterTex.width / 2);
                z = Mathf.Clamp(z, craterTex.height / 2, yRes - craterTex.height / 2);

                float[,] areaT = tData.GetHeights(x - craterTex.width / 2, z - craterTex.height / 2, craterTex.width, craterTex.height);

                for (int i = 0; i < craterTex.height; i++)
                {
                    for (int j = 0; j < craterTex.width; j++)
                    {
                        areaT[i, j] = areaT[i, j] - craterData[i * craterTex.width + j].a * 0.0005f;
                    }
                }

                tData.SetHeights(x - craterTex.width / 2, z - craterTex.height / 2, areaT);
                //tData.SetHeights(x - craterTex.width / 2, z - 1, areaT);

                // Update the terrain deformation usage meter
                currentDeformUsage--;
                deformUseSlider.value = currentDeformUsage;

                // Log the usage of the downwards deformation
                downDeformUsage++;
            }

            // If the player presses the button to deform the terrain upwards
            if (Input.GetKey(KeyCode.E) || Input.GetAxis("Fire2") < 0)
            {
                int x = Mathf.RoundToInt(Mathf.Lerp(0, xRes, Mathf.InverseLerp(0, tData.size.x, Player.currentPosition.x)));
                int z = Mathf.RoundToInt(Mathf.Lerp(0, xRes, Mathf.InverseLerp(0, tData.size.z, Player.currentPosition.z)));

                x = Mathf.Clamp(x, craterTex.width / 2, xRes - craterTex.width / 2);
                z = Mathf.Clamp(z, craterTex.height / 2, yRes - craterTex.height / 2);

                float[,] areaT = tData.GetHeights(x - craterTex.width / 2, z - craterTex.height / 2, craterTex.width, craterTex.height);

                for (int i = 0; i < craterTex.height; i++)
                {
                    for (int j = 0; j < craterTex.width; j++)
                    {
                        areaT[i, j] = areaT[i, j] + craterData[i * craterTex.width + j].a * 0.0005f;
                    }
                }


                tData.SetHeights(x - craterTex.width / 2, z - craterTex.height / 2, areaT);

                // Update the terrain deformation usage meter
                currentDeformUsage--;
                deformUseSlider.value = currentDeformUsage;

                // Log the usage of the upwards deformation
                upDeformUsage++;
            }
        }



    }

    // Function to call when resetting the level
    public void craterReset()
    {
        tData.SetHeights(0, 0, saved);
        done = false;
    }
}
