using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : MonoBehaviour
{
    private Vector2 Difference;
    private float RotorZ;
    [SerializeField] private float Offset = -60;
    public GameObject Missile;
    private float TimeBtwMissle;
    private float WaitBtwMissle = 0;


    private void Start()
    {
        TimeBtwMissle = Globals.TimeBtw4 / 2;
    }
    void Update()
    {
        Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotorZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;

        if (WaitBtwMissle <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) & Globals.Beat)
            {
                Instantiate(Missile, gameObject.transform.position, Quaternion.Euler(0f, 0f, RotorZ + Offset));
                Debug.Log("Hit");
                WaitBtwMissle = TimeBtwMissle;
            }
        } else
        {
            WaitBtwMissle -= Time.deltaTime;
        }
        
    }
}
