using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Templates = new List<GameObject>();
    public List<SpawnNode> SpawnerPoints = new List<SpawnNode>();
    [SerializeField]
    public Vector2 SpawnerInterval = Vector2.up;
    public bool ShowDebug = false;
    public GameObject RatKing;

    private float _t = 0;
    private float _nextTarget = 0;

    private void OnDrawGizmos()
    {
        if (!ShowDebug) return;
        Gizmos.color = Color.yellow;
        foreach(var g in SpawnerPoints)
            Gizmos.DrawCube(g.transform.position, Vector3.one);
    }

    // Start is called before the first frame update
    void Start()
    {
        if( SpawnerPoints.Count == 0 || Templates.Count == 0 )
        {
            Debug.LogError("Please add least one spawn point or one template!");
            this.enabled = false;
        }
        // Rip Sarah and Gene - Subscribe events for each spawnerNode
        SpawnerPoints.ForEach(x => x.OnSpawnerEvent += X_OnSpawnerEvent);
        UpdateNextRandomTargetTimeToSpawn();
    }

    private void X_OnSpawnerEvent(object sender)
    {
        SpawnNode spawnNode = sender as SpawnNode;
        // unsubscribe event
        spawnNode.OnSpawnerEvent -= X_OnSpawnerEvent;
        SpawnerPoints.Remove(spawnNode);
        if( SpawnerPoints.Count == 0 )
        {
            // spawn Rat King
            Instantiate(RatKing, this.transform.position, Quaternion.identity);
            this.enabled = false;
        }
    }

    private void UpdateNextRandomTargetTimeToSpawn()
    {
        _nextTarget = Random.Range(SpawnerInterval.x, SpawnerInterval.y);
    }

    // Update is called once per frame
    void Update()
    {
        _t += Time.deltaTime;
        if (_t > _nextTarget)
        {
            _t = 0;
            int t = Random.Range(0, Templates.Count);
            int p = Random.Range(0, SpawnerPoints.Count);
            Instantiate(Templates[t], SpawnerPoints[p].transform.position, Quaternion.identity);
            UpdateNextRandomTargetTimeToSpawn();
        }
    }
}
