using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]public bool isDead = false;
    Animator anim;
    [Header("Attribute")]
    public int enemyId;
    public float hp;
    public float maxHP;
    public int damage;
    public int def;
    public float firerate;
    public float movespd;
    public int coinDrop;
    [Header("Health Bar")]
    public GameObject healthBar;
    protected Image Bar;
    protected Image BarFilled;


    void Start()
    {
        Bar = Instantiate(healthBar, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        BarFilled = new List<Image>(Bar.GetComponentsInChildren<Image>()).Find(img => img != Bar);
        GetEnemyData();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 unitposition = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        Bar.transform.position = Camera.main.WorldToScreenPoint(unitposition);
        SettingAttribute();
    }
    public void SettingAttribute()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Destroy(Bar.gameObject);
            EnemyRespawn.monsterInField -= 1;
            DropCoin();
            hp = maxHP;
        }
    }
    public void GetHit()
    {
        float totalDamage = Turrets.instance.damage - (def - Turrets.instance.penetration);
        Debug.Log(totalDamage);
        if(totalDamage < 0)
        {
            totalDamage = 0;
        }
        hp -=  totalDamage;
        BarFilled.fillAmount = hp/maxHP;
        Debug.Log("Hp Remaining" + hp);
        SettingAttribute();
    }
    public void GetCheckPoint()
    {
        hp = 0;
        SettingAttribute();
    }
    public void DropCoin()
    {
        GameManager.currency += coinDrop;
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
