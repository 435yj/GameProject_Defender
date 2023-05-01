using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public static LevelUpManager Instance { get; private set; }

    public int levelUpGauge;

    public int arrowDamage;
    public int towerHp;

    public Building pfHQBuilding;
    
    private int currentExp;

    [SerializeField]
    private TMP_Text levelExpText;

    [SerializeField]
    private GameObject levelUpUI;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        levelUpUI.SetActive(false);

        LevelSetting();
    }

    private void LevelSetting()
    {
        arrowDamage = 10;

        LevelTextSetting();
    }

    public void EnemyKillGetExp()
    {
        int randomGetExp = Random.Range(1, 4);

        currentExp += randomGetExp;

        if(currentExp >= levelUpGauge)
        {
            LevelUp();
        }

        LevelTextSetting();
    }

    private void LevelUp()
    {
        currentExp = 0;

        levelUpGauge = (int)(levelUpGauge * 1.7);

        levelUpUI.gameObject.SetActive(true);

        Time.timeScale = 0f;
    }

    private void LevelTextSetting()
    {
        string str = "Exp : " + currentExp + " / " + levelUpGauge;

        levelExpText.SetText(str);
    }
}
