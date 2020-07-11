using UnityEngine;

public class Threat : Item
{
    [SerializeField]
    public float Radius = 10f;
    public float IntervalRefire = 5f;
    private float _t = 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }

    /// <summary>
    /// make it so that once it's placed or how it's called, scare other cats in scene within the radius.
    /// </summary>
    public void Scare()
    {
        RaycastHit[] hit = Physics.SphereCastAll(this.transform.position, Radius, Vector3.down );
        foreach( RaycastHit h in hit )
        {
            Cat c = h.collider.GetComponent<Cat>();
            if (c != null)
                c.FleeFrom(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_t > 0) return;
        Scare();
        _t = IntervalRefire;
    }

    public void FixedUpdate()
    {
        if (_t > 0)
            _t -= Time.fixedDeltaTime;
    }
}
