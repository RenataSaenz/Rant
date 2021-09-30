using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Obstacles[] obstacles;
    [SerializeField]
    public PositionList[] positionsWaves;

    public PositionList positionList;

    public GameObject heart;
    public GameObject powerUp;

    [SerializeField]
    private int numberObstacles;
    private int positionsWavesIndex = 0;

    private void Start()
    {
        Spawn(numberObstacles);
        //positionList = GetComponent<PositionList>();
    }
    public void Spawn(int count)
    {
        //Instantiate(obstaclesPref[obsRandom]).SetPosition(positions[posRandom]).SetScale(1, 1, 1)
        for (int i = 0; i < count; i++)
        {
            if (positionsWaves[positionsWavesIndex] != null)
            {
                positionsWavesIndex++;
                if (positionsWavesIndex > positionsWaves.Length - 1)
                {
                    positionsWavesIndex = 0;
                    //positionsDesigns.Reverse();
                }
            }

            var obsRandom = Random.Range(0, obstacles.Length);
            var posRandom = Random.Range(0, positionList.dots.Count);
            //var posPositions = positionsWaves[positionsWavesIndex(positionList.dots[posRandom])];
            var instance = Instantiate(obstacles[obsRandom]);
            
            instance.transform.parent = gameObject.transform;
        }
    }


    [System.Serializable]
    public class PositionList
     {
         public string name;
         public List<Transform> dots;
     }
}

 
