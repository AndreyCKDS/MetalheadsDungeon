using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioSource AudioSource;
    

    void Start()
    {
        Globals.Num4 = 0;
        Globals.Tempo = 60;
        Globals.TimeBtw4 = 60 * 0.25f / Globals.Tempo;
        AudioSource = GetComponent<AudioSource>();
        InvokeRepeating("BeatHit", 0, Globals.TimeBtw4);

    }

    private void BeatHit()
    {
        if (Globals.Num4 == 4)
        {
            AudioSource.Play();
            Globals.Num4 = 0;
        }
        StartCoroutine(WaitBeat(Globals.TimeBtw4 * 0.75f));
        Globals.Num4++;
    }

    IEnumerator WaitBeat(float WaitTime)
    {
        Globals.Beat = true;
        yield return new WaitForSeconds(WaitTime);
        Globals.Beat = false;
    }
}
