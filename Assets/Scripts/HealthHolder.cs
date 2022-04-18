using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHolder : MonoBehaviour
{
    [SerializeField] private GameObject Heart;
    [SerializeField] private Sprite HeartSprite, HalfHeartSprite, EmptyHeartSprite;
    private GameObject HPContainer;

    public void InitializeHP(int HealthContainer, int Health)
    {
        for (int i = 0; i < HealthContainer; i++)
        {
            HPContainer = Instantiate(Heart, transform.position + new Vector3 (i * Screen.width/1920 * 100f, 0f, 0f), transform.rotation, gameObject.transform);
            HPContainer.name = $@"Heart{i}";
            if (Health - (i + 1) * 2 < 0) HPContainer.GetComponent<Image>().sprite = HalfHeartSprite;
            if (Health - (i + 1) * 2 <= -2) HPContainer.GetComponent<Image>().sprite = EmptyHeartSprite;
        }

    }

    public void TakeDamage(int Health)
    {

    }
}
