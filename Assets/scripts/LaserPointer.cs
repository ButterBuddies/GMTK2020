using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserPointer : Item
{
    public float AttentionRadius = 10.0f;
    public float BatteryLife = 100f;
    public float usageDrain = 2f;
    public float rechargeRate = 1f;
    public float delayToRecharge = 1f;
    private float _t;
    public GameObject Pointers;

    // Hmmm..... interesting?
    private bool _isOn = false;
    private LineRenderer _laserBeam;

    private void Start()
    {
        _t = 0;
        _laserBeam = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        _isOn = Input.GetButton("Fire1");
    }

    public void FixedUpdate()
    {
        if ( BatteryLife <= 0 )
        {
            _isOn = false;
        }

        if ( _isOn )
        {
            _t = 0;
            // drain battery life for usage
            BatteryLife -= usageDrain * Time.fixedDeltaTime;
            if ( Pointers?.activeSelf == false )
            {
                Pointers?.SetActive(true);
                _laserBeam.enabled = true;
            }

            // assign location and position of where the laser will hit.
            // set end point of the laser
            Vector3 endPoint = transform.position;
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, this.transform.forward * 1000.0f, out hit ) )
            {
                endPoint = hit.point;
                if (Pointers != null)
                {
                    Pointers.transform.position = hit.point + hit.normal * 0.01f;
                    Pointers.transform.rotation = Quaternion.Euler(hit.normal);   // test and see if this works.
                }
            }
            else
            {
                endPoint = transform.forward * 1000f;
                if (Pointers?.activeSelf == true )
                {
                    Pointers?.SetActive(false);
                }
                // just draw the trail render instead to a straight vertical line...
            }
            // update the trail regardless of the condition above...
            _laserBeam.SetPosition( 0, transform.position );
            _laserBeam.SetPosition( _laserBeam.positionCount - 1, endPoint );
        }
        else
        {
            // turn off laser if they're still on?
            if ( Pointers != null && Pointers.activeSelf )
            {
                Pointers.SetActive(false);
                _laserBeam.enabled = false;
            }

            // recharge battery life
            if (BatteryLife < 100f)
            {
                _t += Time.fixedDeltaTime;
                if ( _t > delayToRecharge)
                {
                    BatteryLife += Time.fixedDeltaTime * rechargeRate;
                }
            }
        }
    }

}
