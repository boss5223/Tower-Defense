using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class TurretsDataContainer : Singleton<TurretsDataContainer>
{

    private List<RawTurretsData> turretsData;
    public TurretsDataContainer()
    {
        string json = Resources.Load<TextAsset>("Data/TurretData").text;
        turretsData = JsonConvert.DeserializeObject<List<RawTurretsData>>(json);
        Debug.Log(json);
    }

    public void SetData(List<RawTurretsData> data) => turretsData = data;

    public List<RawTurretsData> GetTurretsData()
    {
        return new List<RawTurretsData>(turretsData);
    }
}
