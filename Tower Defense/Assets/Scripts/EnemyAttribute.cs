using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]public bool isDead = false;
    Animator anim;
    public string monsterId;
    public int hp;
    public int maxHP;
    public int level;
    public int score;

    


    // Start is called before the first frame update

    void Start()
    {
        //level = FindObjectOfType<SetUIManager>().level;
        GetMonsterData();
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
        this.hp = hp - 1;
        SettingAttribute();
    }

    void GetMonsterData()
    {
        //var monsterData = MonsterDataContainer.Instance.GetMonstersData();
        //Debug.Log(monsterData);
        //for (int i = 0; i < monsterData.Count; i++)
        //{
        //    if (monsterData[i].monsterid == monsterId && monsterData[i].level == level )
        //    {
        //        this.hp = monsterData[i].monsterhp;
        //        this.maxHP = monsterData[i].monstermaxhp;
        //        this.score = monsterData[i].monsterscore;

        //    }
        //}

    }
}
