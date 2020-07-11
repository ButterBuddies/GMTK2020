using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Templates = new List<GameObject>();
    public List<GameObject> SpawnerPoints = new List<GameObject>();
    [SerializeField]
    public Vector2 SpawnerInterval = Vector2.up;
    public bool ShowDebug = false;

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
        UpdateNextRandomTargetTimeToSpawn();
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
            Instantiate(Templates[t], SpawnerPoints[p].transform);
            UpdateNextRandomTargetTimeToSpawn();
        }
    }
}
