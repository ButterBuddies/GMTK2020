using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Renderer rend;

    [SerializeField] Material mat;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void SwitchMat()
    {
        rend.material = mat;
    }

    public void SwapHorse()
    {
        rend.enabled = false;
    }
}
