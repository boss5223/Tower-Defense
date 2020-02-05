using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public string spawnerid;
    public float Timer;
    public GameObject Enemy;
    public string EnemyName;
    public int spawnMonsterSize;
    public float repeat;

    [HideInInspector]public int monsterInField = 0;
    GameObject LastEnemy;
    void Start()
    {
        this.gameObject.name = EnemyName + "spawn point";
        PoolManager.instance.CreatePool(Enemy, spawnMonsterSize);
        InvokeRepeating("SpawnMonster", Timer, repeat);
    }
    void SpawnMonster()
    {
        if(monsterInField < spawnMonsterSize) {
            PoolManager.instance.ReusePool(Enemy,transform.position, Quaternion.identity);
            //Instantiate(Enemy, transform.position, Quaternion.identity);
            LastEnemy = GameObject.Find(Enemy.name + "(Clone)");
            monsterInField += 1;
        }
    }
  
}