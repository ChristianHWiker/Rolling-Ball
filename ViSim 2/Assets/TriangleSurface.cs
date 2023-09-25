using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriangleSurface : MonoBehaviour


{
    private Vector3[] vertices;
    private Vector3[] cachedVertices;
    
    // Start is called before the first frame update
    void Start()
    {
        Mesh surface = new Mesh();

        vertices = new Vector3[6];
        Vector2[] uv = new Vector2[6];
        int[] triangles = new int[12];
        

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 0.11f, 0.5191f);
        vertices[2] = new Vector3(0.5191f, 0, 0.5191f);
        vertices[3] = new Vector3(0.5191f, 0.21f, 0);
        vertices[4] = new Vector3(0, 0, 1.0382f);
        vertices[5] = new Vector3(0.5447f, 0.13f, 1.0688f);

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(0, 0);
        uv[3] = new Vector2(0, 0);
        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(0, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 4;
        triangles[7] = 2;
        triangles[8] = 1;

        triangles[9] = 4;
        triangles[10] = 5;
        triangles[11] = 2;
        

        surface.vertices = vertices;
        surface.triangles = triangles;
        
        surface.RecalculateNormals();
        
        GetComponent<MeshFilter>().mesh = surface;

        cachedVertices = surface.vertices;

    }

    public Vector3 CalculateGroundNormal()
    {
        Vector3 averageNormal = Vector3.zero;
    
        for (int i = 0; i < vertices.Length; i += 3)
        {
            Vector3 triangleNormal = CalculateTriangleNormal(vertices[i], vertices[i + 1], vertices[i + 2]);
            averageNormal += triangleNormal;
        }
    
        averageNormal /= (float)vertices.Length / 3;
    
        return averageNormal.normalized;
    }
    
    public Vector3 CalculateTriangleNormal(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
    {
        Vector3 edge1 = vertex2 - vertex1;
        Vector3 edge2 = vertex3 - vertex1;
        Vector3 normal = Vector3.Cross(edge1, edge2).normalized;
        return normal;
    }
    
    public Vector3[] GetCachedVertices()
    {
        return cachedVertices;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
