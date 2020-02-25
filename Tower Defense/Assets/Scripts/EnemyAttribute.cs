using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttribute : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool isDead = false;
    Animator anim;
    [Header("Attribute")]
    public int enemyId;
    public float hp;
    public float maxHP;
    public float enemyDamage;
    public float enemyDef;
    public float firerate;
    public float movespd;
    public int coinDrop;
    [HideInInspector]public bool Dead;
    [Header("Health Bar")]
    public GameObject healthBar;
    [HideInInspector] public Image Bar;
    [HideInInspector] public Image BarFilled;
    private Turrets turret;

    void Start()
    {
        Bar = Instantiate(healthBar, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        BarFilled = new List<Image>(Bar.GetComponentsInChildren<Image>()).Find(img => img != Bar);
        GetEnemyData();
        anim = GetComponent<Animator>();
        turret = GetComponent<Turrets>();
        //turret.enemyDead = false;

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
            StartCoroutine(waitDestroy(1.5f));    
        }
    }
    private IEnumerator waitDestroy(float time)
    {
        Enemy enemy = GetComponent<Enemy>();
        enemy.speed = 0;
        transform.gameObject.tag = "Dead";
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        EnemyRespawn.monsterInField -= 1;
        DropCoin();
        Destroy(Bar.gameObject);
    }
    public void GetHit(float damage, float penetration)
    {
        float totalDamage = damage - (enemyDef - penetration);
        Debug.Log(totalDamage);
        if (totalDamage < 0)
        {
            totalDamage = 0;
        }
        hp -= totalDamage;
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
                enemyDamage = enemyData[i].enemyDamage;
                enemyDef = enemyData[i].enemyDefense;
                movespd = enemyData[i].enemyMoveSpd;
                firerate = enemyData[i].enemyFirerate;
                coinDrop = enemyData[i].enemyCoinDrop;
            }
        }

    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}
