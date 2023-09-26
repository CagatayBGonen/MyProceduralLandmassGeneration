using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    //Her hangi bir objeye atanmayacagi icin MonoBehaviour'a gerek yok.
    //instance olusturmasini istemedigimiz icin Static bir class yapiyoruz.

    //2D array of float values. Buradan bize 0 ve 1 arasinda grid values return edecek.
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight,float scale) 
    {
        float[,] noiseMapp = new float[mapWidth, mapHeight];

        if(scale <= 0)
        {
            scale = 0.0001f; // burada scale'in 0 ya da eksi deger alirsa, 0 division hatasi aliriz.
                             // bunun olmamasi icin min bir deger belirliyoruz. 
        }

        //for loop'a alarak, haritanin genisiligi ve boyundaki her bir noktada 0-1 arasinda bir deger donmesini sagliyoruz.
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleX = x / scale;//scale ile bolerek, float bir deger almayi amacliyoruz.
                float sampleY = y / scale;

                //sampe kordinatlari aliyoruz.
                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                //gelen degerleri noisemap'imize ekliyoruz.
                noiseMapp[x, y] = perlinValue;
            }
        }

        return noiseMapp;
                    
    }
}
