using UnityEngine;
using UnityEngine.Events;

public class logic_timer : MonoBehaviour
{
    public bool PlayOnAwake = false;
    public float Interval = 5f;
    public bool IsLoop = false;
    public UnityEvent OnTimer;

    [SerializeField]
    public float _timer { get; private set; }
    private bool _isPlaying = false;

    private void Awake()
    {
        if (PlayOnAwake)
            Start();
    }

    public void Start()
    {
        _isPlaying = true;
    }

    public void Stop()
    {
        _isPlaying = false;
    }

    public void Reset()
    {
        _isPlaying = false;
        _timer = 0;
    }

    public void Update()
    {
        if (!_isPlaying) return;

        _timer += Time.deltaTime;
        if(_timer > Interval)
        {
            OnTimer.Invoke();
            if (IsLoop)
                _timer = 0;
            else
                _isPlaying = false;
        }
    }
}
