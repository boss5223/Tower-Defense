using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]public bool isDead = false;
    Animator anim;
    public int enemyId;
    public int hp;
    public int maxHP;
    public int damage;
    public int def;
    public float firerate;
    public float movespd;
    public int coinDrop;
    // Start is called before the first frame update

    void Start()
    {
        //level = FindObjectOfType<SetUIManager>().level;
        GetEnemyData();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        SettingAttribute();
    }
    public void SettingAttribute()
    {
        if (hp <= 0)
        {
            isDead = true;
            //SetUIManager.totalScore += score;
            this.gameObject.SetActive(false);
            hp = maxHP;
        }
    }
    public void GetHit()
    {
        //anim.SetTrigger("Hurt");
        int totalDamage = def - Turrets.instance.damage;
        if(totalDamage < 0)
        {
            totalDamage = 0;
        }
        this.hp = hp - totalDamage;
        SettingAttribute();
    }

    void GetEnemyData()
    {
        var enemyData = EnemyDataContainer.Instance.GetEnemyData();
        Debug.Log(enemyData);
        for (int i = 0; i < enemyData.Count; i++)
        {
            if (enemyData[i].enemyID == enemyId)
            {
                hp = enemyData[i].enemyHP;
                maxHP = enemyData[i].enemyMaxHP;
                damage = enemyData[i].enemyDamage;
                def = enemyData[i].enemyDefense;
                movespd = enemyData[i].enemyMoveSpd;
                firerate = enemyData[i].enemyFirerate;
                coinDrop = enemyData[i].enemyCoinDrop;
            }
        }

    }
}
