using UnityEngine;

public class CameraContorl : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 EndPos;
    Vector3 EndPos2;
    float progress;
    bool Down;
    private void Start()
    {
        StartPos = transform.position;
        EndPos = new Vector3(1.073f, -0.87f, -5.889f);
        EndPos2 = new Vector3(1.073f, -1.1f, -5.889f);
        Down = true;
        
    }
    void FixedUpdate()
    {
        if (Down)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPos, 0.2f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPos2, 0.2f * Time.deltaTime);
        }

        if (transform.position.y == -0.87f)
        {
            Down = false;
        }
        if (transform.position.y == -1.1f)
        {
            Down = true;
        }

    }
}
