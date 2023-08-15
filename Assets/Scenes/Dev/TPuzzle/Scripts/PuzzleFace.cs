using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//It works in editor mode.
public class PuzzleFace : MonoBehaviour
{
    public float width = 1f;
    public float height = 1f;
    public float colliderScale = .1f;
    public PuzzleFace targetFace;

    //From origin create 4 colliders.
    //Colliders will have a width and a height from the origin point(parent).
    //Collider size will be defined by a parameter. .1 by default.
    //Each collider will have a target to attach to. I can make that Vertex 1 ALWAYS have to collide with vertex 1 from the other part.

    //Triggered when width or height is changed in the editor.
    public void SetDimensions()
    {

    }

    //Triggered when the size is changed in the editor.
    public void ChageSize()
    {

    }

    //Used to check if the face is in the correct position with the targetFace
    public void CheckCollisions()
    {

    }

   

}
