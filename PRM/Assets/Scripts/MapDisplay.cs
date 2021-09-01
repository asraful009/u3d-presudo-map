using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {
  public Renderer textureRender;

  public void DrowNoiseMap(float[,] noiseMap) {
    int mapWidth = noiseMap.GetLength(0);
    int mapHeight = noiseMap.GetLength(1);
    Texture2D texture = new Texture2D(mapWidth, mapHeight);
    Color[] colorMap  = new Color[mapWidth * mapHeight];
    for(int y=0; y<mapHeight; y++) {
      for(int x =0; x<mapWidth; x++) {
        colorMap[y*mapWidth + x]  = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
      }
    }
    texture.SetPixels(colorMap);
    texture.Apply();
    textureRender.sharedMaterial.mainTexture = texture;
    textureRender.transform.localScale= new Vector3(mapWidth, 1, mapHeight);
  }
}
