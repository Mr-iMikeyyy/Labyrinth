using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSide : MonoBehaviour
{
    private MeshFilter meshFilter;

    /*void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        Mesh originalMesh = meshFilter.sharedMesh;

        // Create a new mesh
        Mesh doubleSidedMesh = new Mesh();

        // Duplicate the vertices and triangles
        doubleSidedMesh.vertices = originalMesh.vertices;
        
        int[] originalTriangles = originalMesh.triangles;
        int[] doubleSidedTriangles = new int[originalTriangles.Length];

        // Flip the normals
        Vector3[] flippedNormals = new Vector3[originalMesh.normals.Length];
        for (int i = 0; i < originalMesh.normals.Length; i++) {
                flippedNormals[i] = -originalMesh.normals[i];
        }

        doubleSidedMesh.normals = flippedNormals;

        for (int i = 0; i < originalTriangles.Length; i += 3) {
            // Reverse triangle winding order for back-facing polygons
            doubleSidedTriangles[i] = originalTriangles[i];
            doubleSidedTriangles[i + 1] = originalTriangles[i + 2];
            doubleSidedTriangles[i + 2] = originalTriangles[i + 1];

            // Duplicate the triangle for the front-facing side
            doubleSidedTriangles[originalTriangles.Length + i] = originalTriangles[i];
            doubleSidedTriangles[originalTriangles.Length + i + 1] = originalTriangles[i + 1];
            doubleSidedTriangles[originalTriangles.Length + i + 2] = originalTriangles[i + 2];
        }

        doubleSidedMesh.triangles = doubleSidedTriangles;

        // Assign the new mesh to the mesh filter
        meshFilter.mesh = doubleSidedMesh;
    }*/
}
