
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public int depth = 20;

    public float scale = 2;

    public float speed = 1.2f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    private void Start()
    {
        offsetX = Random.Range(0, 999);
        offsetY = Random.Range(0, 999);

    }


    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        offsetX += Time.deltaTime * speed;
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];

        for( int x = 0; x<width; x++)
        {
            for (int y = 0; y<height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);

            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xcoord = (float)x / width * scale + offsetX;
        float ycoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xcoord, ycoord);

    }
}
