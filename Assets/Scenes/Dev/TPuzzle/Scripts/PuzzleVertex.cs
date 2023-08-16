using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Positions { TopRight,TopLeft,BottomRight,BottomLeft}

public class PuzzleVertex : MonoBehaviour
{
    public Positions position;
    public PuzzleVertex targetVertex;
    public bool collidingWithTargetVertex;

    public void AdjustPosition(float width,float height,Vector3 parentPosition)
    {
        transform.position = parentPosition;
        switch (position)
        {
            case Positions.TopRight:
                transform.position = transform.position + new Vector3(width / 2, 0 ,-height/2);
                break;
            case Positions.TopLeft:
                transform.position = transform.position + new Vector3(-width / 2, 0, -height / 2);
                break;
            case Positions.BottomRight:
                transform.position = transform.position + new Vector3(width / 2, 0, height / 2);
                break;
            case Positions.BottomLeft:
                transform.position = transform.position + new Vector3(-width / 2, 0, height / 2);
                break;
            default:
                break;
        }
    }

    public void AdjustSize(float size)
    {
        transform.localScale = new Vector3(size,size,size);
    }

    public void SetTargetVertex(PuzzleVertex[] vertices)
    {
        if(vertices != null)
        {
            foreach (PuzzleVertex vertex in vertices)
            {
                if (vertex.position == position)
                {
                    targetVertex = vertex;
                    break;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == targetVertex.gameObject)
        {
            collidingWithTargetVertex = true;
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject == targetVertex.gameObject)
        {
            collidingWithTargetVertex = false;
        }
    }
}
