using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColorMap };
    public DrawMode drawMode = DrawMode.ColorMap;
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
    public TerrainType[] ragions = { 
        new TerrainType() { name = "DeepWater",     height= 0.21f,  color = new Color32(0x4B, 0x65, 0x87, 0xFF)},
        new TerrainType() { name = "RiverWater",    height= 0.36f,  color = new Color32(0x50, 0x89, 0xC6, 0xFF)},
        new TerrainType() { name = "Sand",          height= 0.42f,  color = new Color32(0xE7, 0xE0, 0xC9, 0xFF)},
        new TerrainType() { name = "Gress",         height= 0.59f,  color = new Color32(0xBD, 0xD2, 0xB6, 0xFF)},
        new TerrainType() { name = "Forest",        height= 0.78f,  color = new Color32(0x18, 0x4D, 0x47, 0xFF)},
        new TerrainType() { name = "Mountain",      height= 0.91f,  color = new Color32(0x49, 0x54, 0x64, 0xFF)},
        new TerrainType() { name = "Mountain-ice",  height= 1.00f,  color = new Color32(0xF4, 0xF4, 0xF2, 0xFF)},
    };
    public bool AutoReGenerate = true;
    public void GeneratorMap()
    {
        float[,] noiseMap =
            Noise.GenerateNoise(
                mapWidth, mapWidth, scale,
                octaves, persistance, lacunarity,
                seed, offset);

        MapDisplay mapDisplay = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.ColorMap)
        {
            Color[] ColorMap = new Color[mapWidth * mapHeight];
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    float currentNoiceMap = noiseMap[x, y];
                    for (int i = 0; i < ragions.Length; i++)
                    {
                        if (ragions[i].height >= currentNoiceMap)
                        {
                            ColorMap[y * mapWidth + x] = ragions[i].color;
                            break;
                        }
                    }
                }
            }
            mapDisplay.DrowTextute(TextureGenerator.TextureFromColorMap(ColorMap, mapWidth, mapHeight));
        }
        else
        {
            mapDisplay.DrowTextute(TextureGenerator.TextureFromNoiseMap(noiseMap));

        }
    }

    void OnValidate()
    {
        if (mapWidth < 1) mapWidth = 1;
        if (mapHeight < 1) mapHeight = 1;
        if (lacunarity < 1) lacunarity = 1.0f;
        if (octaves < 1) octaves = 1;
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color color;
}
