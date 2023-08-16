using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//It works in editor mode.
[ExecuteInEditMode]
public class PuzzleFace : MonoBehaviour
{
    public float width = 1f;
    public float height = 1f;
    //Hacer mas pequena esta escala si se quiere que el choque entre las partes se mas preciso. Hacer mas grande si se quiere dar mas facilidad de que se encuentren las caras.
    public float vertexScale = .1f;
    public PuzzleFace targetFace;
    public PuzzleVertex[] vertices;

    private void Awake()
    {
        vertices = transform.GetComponentsInChildren<PuzzleVertex>();
    }

    //From origin create 4 colliders.
    //Colliders will have a width and a height from the origin point(parent).
    //Collider size will be defined by a parameter. .1 by default.
    //Each collider will have a target to attach to. I can make that Vertex 1 ALWAYS have to collide with vertex 1 from the other part.

    public void SetVertexTargets()
    {
        foreach (PuzzleVertex vertex in vertices)
        {
            vertex.SetTargetVertex(targetFace.vertices);
        }
    }

    //Triggered when width or height is changed in the editor.
    public void SetDimensions() 
    { 
        foreach(PuzzleVertex vertex in vertices)
        {
            vertex.AdjustPosition(height, width,transform.position);
        }
    }

    //Triggered when the size is changed in the editor.
    public void ChageSize()
    {
        foreach (PuzzleVertex vertex in vertices)
        {
            vertex.AdjustSize(vertexScale);
        }

    }

    //Used to check if the face is in the correct position with the targetFace
    public bool CheckAllVertexColliding()
    {
        foreach (PuzzleVertex vertex in vertices)
        {
            if (!vertex.collidingWithTargetVertex) 
            { 
                return false;
            }
        }
        return true;
    }

    private void OnValidate()
    {
        SetDimensions();
        ChageSize();
        SetVertexTargets();
    }

}
