using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Obstacles> obstaclesPref = new List<Obstacles>();
    public GameObject heart;
    public GameObject powerUp;

    public List<Transform> positions = new List<Transform>();
    [SerializeField]
    private int numberObstacles;

    private void Start()
    {
        Spawn(numberObstacles);
    }
    public void Spawn(int count)
    {
        
        //Instantiate(obstaclesPref[obsRandom]).SetPosition(positions[posRandom]).SetScale(1, 1, 1)
        for (int i = 0; i < count; i++)
        {
            var obsRandom = Random.Range(0, obstaclesPref.Count);
            var posRandom = Random.Range(0, positions.Count);
            var oa = Instantiate(obstaclesPref[obsRandom], positions[posRandom]);
            oa.transform.parent = gameObject.transform;
        }
    }
}
