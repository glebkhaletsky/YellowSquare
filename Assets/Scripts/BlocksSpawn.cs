
using System.Collections;
using UnityEngine;

public class BlocksSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject Robj;
    [SerializeField]
    Transform SpawnPos;
    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    void Repet()
    {
        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(Random.Range(1f,2)); 
        Instantiate(Robj, new Vector3(-2.2f,Random.Range(-1.92f,-0.23f),0.9f), Quaternion.identity); 
        Repet();
    }
}
