using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataContainer : Singleton<EnemyDataContainer>
{
    private List<RawEnemyData> enemyData;
    public EnemyDataContainer()
    {
        string json = Resources.Load<TextAsset>("Data/EnemyData").text;
        enemyData = JsonConvert.DeserializeObject<List<RawEnemyData>>(json);
        Debug.Log(json);
    }

    public void SetData(List<RawEnemyData> data) => enemyData = data;

    public List<RawEnemyData> GetEnemyData()
    {
        return new List<RawEnemyData>(enemyData);
    }
}
