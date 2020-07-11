using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public enum State { Alive, Dead }
    public float Health = 100f;
    public float MaxHealth = 120f;
    public State state = State.Alive;
    public GameObject Gibs;

    // we could play some animations here?
    public void InflictDamage(float d )
    {
        if (state == State.Dead) return;
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
}
