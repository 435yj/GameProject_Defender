using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    [SerializeField]
    private Button attackButton;
    [SerializeField]
    private Button healthButton;

    private void Start()
    {
        attackButton.onClick?.AddListener(AttackUp);
        healthButton.onClick?.AddListener(HealthUp);
    }

    private void AttackUp()
    {
        Time.timeScale = 1f;

        LevelUpManager.Instance.arrowDamage += 5;
        gameObject.SetActive(false);
    }

    private void HealthUp()
    {
        Time.timeScale = 1f;

        if (LevelUpManager.Instance.pfHQBuilding != null)
        {
            HealthSystem healthSystem = LevelUpManager.Instance.pfHQBuilding.GetComponent<HealthSystem>();
            healthSystem.PfHQ_Heal(150);
        }
        
        gameObject.SetActive(false);
    }
}
