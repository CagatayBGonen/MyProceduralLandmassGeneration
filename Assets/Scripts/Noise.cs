using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    //Her hangi bir objeye atanmayacagi icin MonoBehaviour'a gerek yok.
    //instance olusturmasini istemedigimiz icin Static bir class yapiyoruz.

    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight,float scale) //2D array of float values. Buradan bize 0 ve 1 arasinda grid values return edecek.
    {
        float[,] noiseMapp = new float[mapWidth, mapHeight];

        if(scale <= 0)
        {
            scale = 0.0001f;
        }

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
            }
        }

        return noiseMapp;
                    
    }
}
