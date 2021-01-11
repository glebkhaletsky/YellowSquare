using UnityEngine;

public class BlocksMove : MonoBehaviour
{
   
    float progress;
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(new Vector2(-2.2f,transform.position.y), new Vector2(4.7f, transform.position.y), progress);
        progress += 0.005f;
        transform.rotation *= Quaternion.Euler(0, 0, 1.9f);
        
        if (transform.position.x > 4.55f)
        {
            Destroy(gameObject, 1); 
        }
    }
}
