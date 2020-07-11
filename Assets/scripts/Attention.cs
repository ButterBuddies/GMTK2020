using UnityEngine;

/// <summary>
///  This script is design to draw attention to the cats. e.g. Strings, Catnips, etc. 
/// </summary>
[RequireComponent(typeof(SphereCollider))]
public class Attention : Item
{
    // Start is called before the first frame update
    public float timeDuration = 10f;
    [Range(0,1)]
    public float Threshold = 0.5f;
    public float Radius = 10f;

    //hmm interesting?
    private SphereCollider _sphereCol;

    private void Start()
    {
        _sphereCol = GetComponent<SphereCollider>();
        _sphereCol.radius = Radius; // so why is this guy not working?
        _sphereCol.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // see if the cat has enter the collider.... 
        // if the cat starts to enter... or at least make it visible in the scene? Then go ahead and make it draw attention towards it.
        Cat c = other.gameObject.GetComponent<Cat>();
        if( c != null )
        {
            //Debug.Log($"{other.gameObject.name} has enter this {this.gameObject.name} trigger.");
            c.MoveTowards(this.gameObject);
        }
    }
}
