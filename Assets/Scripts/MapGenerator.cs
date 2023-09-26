using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //Burada haritamizi define eden (tanimlayan) bir cok values (Deger,variables) sahibiz.
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public void GenerateMap()
    {
        //Noise class'indan noisemap'i aliyoruz.
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale);
        //MapDisplay ve NoiseMap'imi call ediyoruz.

        //MapDisplay reference'ini aliyoruz.
        MapDisplay mapDisplay = FindObjectOfType<MapDisplay>();
        //MapDisplay classindan DrawNoiseMap metodunu cagirip noiseMap gonderiyoruz.
        mapDisplay.DrawNoiseMap(noiseMap);
        
    }
}
