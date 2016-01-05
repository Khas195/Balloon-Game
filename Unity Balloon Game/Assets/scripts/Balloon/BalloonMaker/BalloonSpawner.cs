using UnityEngine;
using System.Collections;

namespace Assets.BalloonPack
{
    public class BalloonSpawner : MonoBehaviour
    {
        [SerializeField]
        Balloon.Type[] types;
       [SerializeField]
       Transform[] spawnPoints;
       //[SerializeField]
       // float[] spawnRate;
        [SerializeField]
        float spawnTime;

        float spawnTimer = 0;

        void Awake()
        {
            BalloonPoolManager.Instance.SetFactory(this.GetComponent<BalloonFactory>());
        }
        void Update()
        {
            if (spawnTimer < Time.time)
            {
                SpawnBalloon();

                spawnTimer += spawnTime;
            }
        }
        // Use this for initialization
        public void SpawnBalloon()
        {
            Balloon.Type balloonType = types[Random.Range(0, types.Length)];

            GameObject balloon = BalloonPoolManager.Instance.RequestPoolWithBalloonType(balloonType).RequestBalloonOfType();
            Transform point = spawnPoints[Random.Range(0,spawnPoints.Length)].transform;
            balloon.transform.position = point.position;
            balloon.SetActive(true);
        }
    }
}
