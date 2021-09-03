using UnityEngine;

public class Noise
{
    public static float[,] GenerateNoise(
    int mapWidth, int mapHeight, float sacle,
    int octaves, float persistance, float lacunarity,
    int seed, Vector2 offset)
    {
        if (sacle <= 0.0f)
        {
            sacle = 0.0001f;
        }
        System.Random prand = new System.Random(seed);
        Vector2[] octaveOffset = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prand.Next(-100000, 100000) + offset.x;
            float offsetY = prand.Next(-100000, 100000) + offset.y;
            octaveOffset[i] = new Vector2(offsetX, offsetY);
        }
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        float halfWidth = mapWidth / 2.0f;
        float halfHeight = mapHeight / 2.0f;
        float[,] noiseMap = new float[mapWidth, mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1.0f;
                float frequency = 1.0f;
                float noiseHieght = 0.0f;
                for (int i = 0; i < octaves; i++)
                {
                    float tmpX = (x - halfWidth) / sacle * frequency + octaveOffset[i].x;
                    float tmpY = (y - halfHeight) / sacle * frequency + octaveOffset[i].y;
                    float perlinNoise = Mathf.PerlinNoise(tmpX, tmpY);
                    noiseHieght += perlinNoise * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                if (noiseHieght > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHieght;
                }
                if (noiseHieght < minNoiseHeight)
                {
                    minNoiseHeight = noiseHieght;
                }
                noiseMap[x, y] = noiseHieght;
            }
        }
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        return noiseMap;
    }
}
