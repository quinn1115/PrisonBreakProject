using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanFace
{
    
    private int Resolution;
    private Vector3 localUp;
    private Vector3 axisA;
    private Vector3 axisB;
    private float PlanetRadius;

    public Mesh mesh;
    public Transform transform;
    public bool Normalize;

    public OceanFace(Mesh mesh, int resolution, Vector3 localUp, float planetRadius)
    {
        this.mesh = mesh;
        this.Resolution = resolution;
        this.localUp = localUp;
        this.PlanetRadius = planetRadius;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }

    public void Construct()
    {
        Vector3[] verts = new Vector3[Resolution * Resolution];
        int[] triangles = new int[(Resolution - 1) * (Resolution - 1) * 6];
        int triIndex = 0;
        Vector2[] uvs = new Vector2[verts.Length];


        for (int y = 0; y < Resolution; y++)
        {
            for (int x = 0; x < Resolution; x++)
            {
                //Verts
                int i = x + y * Resolution;
                Vector2 percent = new Vector2(x, y) / (Resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - .5f) * 2 * axisA + (percent.y - 0.5f) * 2 * axisB;
                pointOnUnitCube.Normalize();

                float elevation = PlanetRadius + 15;

                verts[i] = pointOnUnitCube * elevation + transform.position;

                //triangles
                if (x != Resolution - 1 && y != Resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + Resolution + 1;
                    triangles[triIndex + 2] = i + Resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + Resolution + 1;
                    triIndex += 6;
                }
                

                uvs[i] = new Vector2((float)x / Resolution,(float)y / Resolution);

            }
        }

        mesh.Clear();
        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
    
}
