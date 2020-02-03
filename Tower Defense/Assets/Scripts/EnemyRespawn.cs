using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public string spawnerid;
    public float Timer;
    public float Cooldown;
    public GameObject Enemy;
    public string EnemyName;
    public int spawnMonsterSize;
    public float repeat;
    public int round;

    [HideInInspector]public int monsterInField = 0;
    GameObject LastEnemy;
    void Start()
    {
        //round = FindObjectOfType<SetUIManager>().level;
        GetSpawnerData();
        this.gameObject.name = EnemyName + "spawn point";
        PoolManager.instance.CreatePool(Enemy, spawnMonsterSize);
        InvokeRepeating("SpawnMonster", Timer, repeat);
    }
    void SpawnMonster()
    {
        if(monsterInField < spawnMonsterSize) {
            Enemy.transform.position = transform.position;
            PoolManager.instance.ReusePool(Enemy, transform.position, Quaternion.identity);
            LastEnemy = GameObject.Find(Enemy.name + "(Clone)");
            monsterInField += 1;
        }
    }

    void GetSpawnerData()
    {
       //var spawnersData = SpawnDataContainer.Instance.GetSpawnerDatas();
       // Debug.Log(spawnersData);
       // for (int i = 0; i < spawnersData.Count; i++)
       // {
       //     if(spawnersData[i].spawnerid == spawnerid && spawnersData[i].round == round)
       //     {
       //         Debug.Log(round);
       //         this.spawnMonsterSize = spawnersData[i].spawnersize;
       //         this.repeat = spawnersData[i].repeat;
                
       //     }
       // }

    }

    //RawSpawnerData a = new RawSpawnerData();

    //public void Foo()
    //{
    //    RawSpawnerData b = a;

    //    a.spawnerid += 1;

    //    Debug.Log(b.spawnerid);
    //    Debug.Log(a.spawnerid);


    //}


}