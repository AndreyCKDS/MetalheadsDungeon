using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioSource AudioSource;
    [SerializeField] private GameObject MainCamera;

    void Start()
    {
        Globals.Num4 = 1;
        Globals.Tempo = 45;
        Globals.TimeBtw4 = 60 * 0.25f / Globals.Tempo;
        AudioSource = GetComponent<AudioSource>();
        InvokeRepeating("BeatHit", 0, Globals.TimeBtw4);
    }

    private void BeatHit()
    {
        StartCoroutine(WaitBeat(Globals.TimeBtw4 * 0.4f));
    }

    IEnumerator WaitBeat(float WaitTime)
    {
        Globals.Beat = true;
        yield return new WaitForSeconds(WaitTime);
        if (Globals.Num4 == 1)
        {
            AudioSource.volume = 1;
            MainCamera.GetComponent<Animator>().SetTrigger("Shake");

        } else
        {
            AudioSource.volume = 0.3f;
        }
        AudioSource.Play();
        Globals.Num4++;
        if (Globals.Num4 == 5) Globals.Num4 = 1;
        yield return new WaitForSeconds(WaitTime);
        Globals.Beat = false;
    }
}
