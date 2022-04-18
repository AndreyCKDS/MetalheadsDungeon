using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guitar : MonoBehaviour
{
    private Vector2 Difference;
    private float RotorZ;
    [SerializeField] private float Offset = -90;
    public GameObject Missile;
    private AudioSource AudioSource;


    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotorZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;

        if (Input.GetKeyDown(KeyCode.Space) & Globals.Beat)
        {
            //Quaternion.Euler(0f, 0f, RotorZ + Offset)
            Instantiate(Missile, gameObject.transform.position, Quaternion.Euler(0f, 0f, RotorZ + Offset));
            AudioSource.Play();
            Globals.Beat = false;
        }
        
        
    }
}
