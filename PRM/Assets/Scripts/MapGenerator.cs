using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
  public int mapWidth = 100;
  public int mapHeight = 100;
  public float scale = 27.48f;
  [Range(1, 6)]
  public int octaves = 4;
  [Range(0, 1)]
  public float persistance = 0.57f;
  [Range(1, 20)]
  public float lacunarity = 1.48f;
  public int seed = 0;
  public Vector2 offset = new Vector3(0f, 0f);

  public bool AutoReGenerate = true;
  public void GeneratorMap() {
    float [,] noiseMap = Noise.GenerateNoise(mapWidth, mapWidth, scale, octaves, persistance, lacunarity, seed, offset);
    MapDisplay mapDisplay = FindObjectOfType<MapDisplay>();
    mapDisplay.DrowNoiseMap(noiseMap);
  }
  void OnValidate() {
    if(mapWidth <1) mapWidth = 1;
    if(mapHeight <1) mapHeight = 1;
    if(lacunarity<1) lacunarity = 1.0f;
    if(octaves <1) octaves = 1;
  }
}
