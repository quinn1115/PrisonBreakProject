using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [Range(2, 1024)]
    public int resolution = 10;
    public bool Normalize;
    public float frequency = 16;
    public float amplitude = 1;
    public float radius = 1;
    public Gradient gradient;
    public Material VertexMat;
    public float biomeAmplitude;
    public float biomeFrequency;

   // [SerializeField, HideInInspector]
   public  MeshFilter[] filters;
   public TerrainChunk[] terrainFaces;


    private void OnValidate()
    {
        initialize();
        GenerateMesh();
    }

    void initialize()
    {
        if(filters == null || filters.Length == 0)
        {
            filters = new MeshFilter[6];
        }

        terrainFaces = new TerrainChunk[6];
      
        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        for (int i = 0; i < 6; i++)
        {
            //Terrain
            if(filters[i] == null)
            { 
                GameObject meshObj = new GameObject("PlanetMesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>();
                filters[i] = meshObj.AddComponent<MeshFilter>();
                filters[i].sharedMesh = new Mesh();
                meshObj.GetComponent<MeshRenderer>().sharedMaterial = VertexMat;
            }

            terrainFaces[i] = new TerrainChunk(filters[i].sharedMesh, resolution, directions[i], amplitude, frequency, radius, gradient, biomeAmplitude, biomeFrequency);
            terrainFaces[i].transform = transform;
        }
    }

    void GenerateMesh()
    {
        foreach (TerrainChunk face in terrainFaces)
        {
            //Debug.Log("test");
            face.Normalize = Normalize;
            face.Construct();
        }
    }

}


