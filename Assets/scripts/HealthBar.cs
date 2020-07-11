using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public enum State { Alive, Dead }
    public float Health = 100f;
    public float MaxHealth = 120f;
    public State state = State.Alive;
    public GameObject Gibs;
    public int MaxHitBeforeOblierate = 4;
    public float TimeToResetMaxhit = 2f;

    private int hits = 0;
    private float _t = 0;

    // we could play some animations here?
    public void InflictDamage(float d )
    {
        if (state == State.Dead) return;
        hits++;
        if( hits >= MaxHitBeforeOblierate )
        {
            Oblierated();
            return;
        }
        _t = TimeToResetMaxhit;
        Health -= d;
        Health = Health < 0 ? 0 : Health;
        if (Health == 0)
        {
            state = State.Dead;
            this.gameObject.SetActive(false);
        }
    }

    // we could play some animations here?
    public void Recover(float d )
    {
        Health += d;
        Health = Health > MaxHealth ? MaxHealth : Health;
    }

    public void Oblierated()
    {
        Health = 0;
        state = State.Dead;
        if (Gibs != null)
            Destroy( Instantiate( Gibs, this.transform ), 30f );
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_t > 0 )
        {
            _t -= Time.deltaTime;
            if( _t <= 0 )
            {
                hits = 0;
                _t = 0;
            }
        }
    }
}
