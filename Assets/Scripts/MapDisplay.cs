using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    //Bu class(Sinif), noise mapi alicak ve bunu bir textur'a donusturecek.
    //Daha sonra bu texture, scene'de bir objeye uygulayacak.

    //Texutur'u render etmek icin rendere'in referenacina ihtiyacimiz var.
    public Renderer textureRenderer;


    public void DrawNoiseMap(float[,] noiseMap)
    {
        //Gelen noise map'in en ve boyunu buluyoruz.
        int width = noiseMap.GetLength(0); // first(ilk) dimension icin
        int height = noiseMap.GetLength(1); // second(ikinci) dimension icin

        //2D texturu olusturuyoruz.
        Texture2D texture = new Texture2D(width, height);

        //simdi textur'un icindeki her bir pixel'in rengini belirliyoruz.
        //bunun yapmanin bir yolu, texture.SetPixel(x,y,color).
        //Ama Butun renklerin oldugu bir array generate edip, hepsini birden atamak daha hizli oluyor.

        //Color array olsuturoyoruz.
        Color[] colorMap = new Color[width * height]; //width * height ile colorMap arrayin size'ini belirliyoruz.

        //butun noiseMap degerlerini looptan geciriyoruz.
        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < height; x++)
            {
                //Burada color'i set ediyoruz.

                //colorMap'in index'ini bulmamiz gerekiyor.
                //colorMap'imiz 1 dimesion'li, fakat bizim noiseMap'imiz 2-Dimesion'li. 

                //y'yi width(En) ile carparak bize su an bulundugu sirayi veriyor. x ile toplayarak da sutunu elde ediyoruz.
                //asagidaki noktayi, noktanin o andaki degerine gore siyah ile beyaz arasinda bir renge atamak istiyoruz.
                //Lerp kullaniyoruz ve ona 0 ile 1 arasýnda bir yüzde veririz, bu da bizim noiseMap'imiz ile ayný aralýktýr.

                colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x,y]);
            }
        }
        //secilen color'lari bizim texutur'umuza uyguluyoruz.
        texture.SetPixels(colorMap); //SetPixels(Color[] colors) Gets the pixel color at coordinates (x, y), and Return The pixel color.
        texture.Apply(); //Reinitializes a Texture2D, making it possible for you to replace width, height,
                         //textureformat, and graphicsformat data for that texture.
        
        //Sadece runtime'da degil ayni zamanda editor icinde de gormek icin asagadiki metodu kullaniyoruz.
        textureRenderer.sharedMaterial.SetTexture("_BaseMap", texture);
        //Ayni zamanda uygulanacak obj nin scale'i ile Map'in scalinin ayni size olmasini sagliyoruz.
        textureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}
