using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
  public int mapWidth = 10;
  public int mapHeight = 10;
  public float scale = 0.1f;
  public bool AutoReGenerate = true;
  public void GeneratorMap() {
    float [,] noiseMap = Noise.GenerateNoise(mapWidth, mapWidth, scale);
    MapDisplay mapDisplay = FindObjectOfType<MapDisplay>();
    mapDisplay.DrowNoiseMap(noiseMap);
  }
}
