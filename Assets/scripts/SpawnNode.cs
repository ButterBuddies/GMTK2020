using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SpawnNode : Attention
{
    public delegate void SpawnerEvent(object sender);
    public event SpawnerEvent OnSpawnerEvent;
    public GameObject FX;

    public int MaxHit = 4;
    private int _hit = 0;

    public void OnCollisionEnter(Collision collision)
    {
        Cat cat = collision.transform.GetComponent<Cat>();
        if (cat != null)
        {
            _hit++;
            if( _hit >= MaxHit)
            {
                // destroy this object
                if(FX != null )
                {
                    GameObject go = Instantiate(FX, this.transform.position, Quaternion.identity);
                    go.transform.parent = this.transform.parent;
                }
                OnSpawnerEvent?.Invoke(this);
                Destroy(this.gameObject);
            }
        }
    }
}
