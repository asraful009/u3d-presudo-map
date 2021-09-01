using UnityEngine;

public class Noise {
  public static float[,] GenerateNoise(int mapWidth, int mapHeight, float sacle) {
    if(sacle <= 0.0f) {
      sacle = 0.0001f;
    }
    float [,] noiseMap = new float[mapWidth, mapHeight];
    for(int y=0; y < mapHeight; y++) {
      float tmpY = y / sacle;
      for(int x=0; x < mapWidth; x++) {
        float tmpX = x / sacle;
        float perlinNoise = Mathf.PerlinNoise(tmpX, tmpY);
        //  Debug.Log("[" + x + ", " + y + "]=> " + perlinNoise);
        noiseMap[x, y] = perlinNoise;
      }
    }
    return noiseMap;
  }
}
