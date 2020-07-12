using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public enum State { Alive, Dead }
    public float Health = 100f;
    public float MaxHealth = 120f;
    public State state = State.Alive;
    public GameObject Gibs;
    public int MaxHitBeforeOblierate = 4;
    public float TimeToResetMaxhit = 2f;

    public bool LoadSceneIfDead = false;
    public string SceneToLoad;

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
        if (Health <= 0)
        {
            Died();
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
        if (Gibs != null)
        {
            // SPAWN BLOODS
            GameObject go = Instantiate(Gibs, this.transform.position, Gibs.transform.rotation);
            // DETATCH FROM PARENT
            go.transform.parent = this.transform.parent;
            // DESCEND TO HELL!
            Destroy(go, 15f);
            // THIS IS DOOM!
        }
        Died();
    }

    private void Died()
    {
        if (LoadSceneIfDead)
            SceneManager.LoadScene(SceneToLoad);
        Health = 0;
        state = State.Dead;
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 15f);
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
