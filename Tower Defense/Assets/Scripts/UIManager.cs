using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Button")]
    public Button Gun1;
    public Button Gun2;
    public Button Gun3;
    private Button Sell;
    [Header("Text")]
    public Text Currency;
    public Text Time;
    public Text TowerPoints;
    [Header("Panel")]
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject starPanel1;
    public GameObject starPanel2;
    public GameObject starPanel3;
    [Header("GameObject")]
    public GameObject spawn;
    public GameObject node;
    public GameObject storage;
    public GameObject particleStorage;
    private EnemyAttribute enemyAttribute;
    private GameObject towerToSell;
    private int star;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        enemyAttribute = GetComponent<EnemyAttribute>();
        Gun1.onClick.AddListener(() => Shop.instance.PurchaseStandardTurrets());
        Gun2.onClick.AddListener(() => Shop.instance.PurchaseAnotherTurrets());
        Gun3.onClick.AddListener(() => Shop.instance.PurchaseSpecialTurrets());
        

        //Sell.onClick.AddListener(() => DestroyTower());
    }
    void Update()
    {
        SetEndPanel();
        UpdateCurrency();
        Updatetime();
        UpdateTowerPoint();
    }
    void UpdateCurrency()
    {
        Currency.text = GameManager.currency.ToString()+" $";
    }
    void Updatetime()
    {
        Time.text = GameManager.prepairingTime.ToString("0");
        if(GameManager.prepairingTime <= 0)
        {
            Time.text = GameManager.timeIngame.ToString("0");
        }
    }
    void UpdateTowerPoint()
    {
        TowerPoints.text = GameManager.towerPoint.ToString();
    }
    void resultStar()
    {
        if (EnemyRespawn.monsterInField <= 0 && GameManager.towerPoint >= 20)
        {
            star = 3;
            starPanel1.SetActive(false);
            starPanel2.SetActive(false);
            starPanel3.SetActive(true);
        }
        else if(EnemyRespawn.monsterInField > 0 && GameManager.towerPoint >=20)
        {
            star = 2;
            starPanel1.SetActive(false);
            starPanel2.SetActive(true);
            starPanel3.SetActive(false);
        }
        else if (EnemyRespawn.monsterInField > 4 && GameManager.towerPoint<=10)
        {
            star = 1;
            starPanel1.SetActive(true);
            starPanel2.SetActive(false);
            starPanel3.SetActive(false);
        }
    }
    void SetEndPanel()
    {
        if (GameManager.timeIngame <= 0 && GameManager.towerPoint > 0)
        {
            winPanel.SetActive(true);
            resultStar();
            losePanel.SetActive(false);
            spawn.SetActive(false);
            node.SetActive(false);
            storage.SetActive(false);
            particleStorage.SetActive(false);
            GameObject bar = GameObject.FindGameObjectWithTag("Bar");
            GameObject button = GameObject.FindGameObjectWithTag("SB");
            Destroy(bar);
            Destroy(button);
        }
        else if (GameManager.towerPoint <= 0)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
            spawn.SetActive(false);
            node.SetActive(false);
            storage.SetActive(false);
            particleStorage.SetActive(false);
            GameObject bar = GameObject.FindGameObjectWithTag("Bar");
            GameObject button = GameObject.FindGameObjectWithTag("SB");
            Destroy(button);
            Destroy(bar);

        }
    }
 
}
