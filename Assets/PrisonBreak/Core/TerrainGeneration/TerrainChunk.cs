using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk
{

    public Mesh mesh;
    private int Resolution;
    private Vector3 localUp;
    private Vector3 axisA;
    private Vector3 axisB;
    private float PlanetRadius;
    private float amplitude;
    private float Frequency;
    private float biomeFreq;
    private float biomeAmp;
    private Gradient grad;

    public Transform transform;

    public bool Normalize;
    public MinMax elevationMinMax;


    public TerrainChunk(Mesh mesh, int resolution, Vector3 localUp, float amp, float freq, float planetRadius, Gradient gradient, float biomeAmp, float biomeFreq)
    {
        this.mesh = mesh;
        this.Resolution = resolution;
        this.localUp = localUp;
        this.amplitude = amp;
        this.Frequency = freq;
        this.PlanetRadius = planetRadius;
        this.grad = gradient;
        this.biomeAmp = biomeAmp;
        this.biomeFreq = biomeFreq;
        
        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
        elevationMinMax = new MinMax();

    }

   public void Construct()
    {
        Vector3[] verts = new Vector3[Resolution * Resolution];
        int[] triangles = new int[(Resolution - 1) * (Resolution - 1) * 6];
        int triIndex = 0;
        Vector3[] Normals= new Vector3[Resolution * Resolution];
        Color[] Colors = new Color[Resolution * Resolution];
        Vector2[] uvs = new Vector2[Resolution * Resolution];

        for (int y = 0; y < Resolution; y++)
        {
            for (int x = 0; x < Resolution; x++)
            {
                //Verts
                int i = x + y * Resolution;
                Vector2 percent = new Vector2(x, y) / (Resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - .5f) * 2 * axisA + (percent.y - 0.5f) * 2 * axisB;
                pointOnUnitCube.Normalize();
                //float elevation = PlanetRadius * (1 + LayerNoise(pointOnUnitCube));
                float elevation = PlanetRadius * (1 + BiomeGen(pointOnUnitCube, .4f));
                elevationMinMax.AddValue(elevation);
                verts[i] = (pointOnUnitCube * elevation);
                


                //triangles
                if (x != Resolution - 1 && y != Resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i+Resolution+1;
                    triangles[triIndex + 2] = i+Resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + Resolution+1;
                    triIndex+= 6;
                }

                uvs[i] = new Vector2((float)x / Resolution, (float)y / Resolution);


                float height = Mathf.InverseLerp(elevationMinMax.Min, elevationMinMax.Max, elevation);   
                Colors[i] = grad.Evaluate(height);
            }
        }

        mesh.Clear();
        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.colors = Colors;
        mesh.RecalculateNormals();

    }

    public float PerlinNoise3D(float x, float y, float z)
    {
        float xy = Mathf.PerlinNoise(x, y);
        float xz = Mathf.PerlinNoise(x, z);
        float yz = Mathf.PerlinNoise(y, z);
        float yx = Mathf.PerlinNoise(y, x);
        float zx = Mathf.PerlinNoise(z, x);
        float zy = Mathf.PerlinNoise(z, y);

        return (xy + xz + yz + yx + zx + zy) / 6;
    }

    public float LayerNoise(Vector3 Point)
    {
        float height;
        float h1 = PerlinNoise3D(transform.position.x + Point.x * Frequency, transform.position.y + Point.y *Frequency , transform.position.z + Point.z *Frequency ) / amplitude;
        float h2 = PerlinNoise3D(transform.position.x + Point.x * (Frequency * 2), transform.position.y + Point.y * (Frequency * 2), transform.position.z + Point.z * (Frequency * 2)) / (amplitude * 2);
        float h3 = PerlinNoise3D(transform.position.x + Point.x * (Frequency * 4), transform.position.y + Point.y * (Frequency * 4), transform.position.z + Point.z * (Frequency * 4)) / (amplitude * 4);
        float h4 = PerlinNoise3D(transform.position.x + Point.x * (Frequency * 8), transform.position.y + Point.y * (Frequency * 8), transform.position.z + Point.z * (Frequency * 8)) / (amplitude * 8);

        return height = h1 + h2 + h3 +h4;
    }

    public float BiomeGen(Vector3 Point, float biomeOffset)
    {
        float biNoise = PerlinNoise3D(transform.position.x + Point.x * biomeFreq, transform.position.z + Point.z * biomeFreq, transform.position.z + Point.z * biomeFreq) / biomeAmp;
        float h1 = PerlinNoise3D(transform.position.x + Point.x * Frequency, transform.position.y + Point.y * Frequency, transform.position.z + Point.z * Frequency) / amplitude;

        return Mathf.Lerp(h1, LayerNoise(Point), biNoise);
    }
}


