using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Button")]
    public Button Gun1;
    public Button Gun2;
    public Button Gun3;
    private Button Sell;
    public Button Continue;
    public Button Continue2;
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
    private GameObject[] bar;
    private GameObject[] sellButton;
    private GameObject barRemaining;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        enemyAttribute = GetComponent<EnemyAttribute>();
        Gun1.onClick.AddListener(() => Shop.instance.PurchaseStandardTurrets());
        Gun2.onClick.AddListener(() => Shop.instance.PurchaseAnotherTurrets());
        Gun3.onClick.AddListener(() => Shop.instance.PurchaseSpecialTurrets());
        Continue.onClick.AddListener(() => LoadScene());
        Continue2.onClick.AddListener(() => LoadScene());


        //Sell.onClick.AddListener(() => DestroyTower());
    }
    void LateUpdate()
    {
        SetEndPanel();
        UpdateCurrency();
        Updatetime();
        UpdateTowerPoint();
        CountBar();
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
        if (GameManager.monsterInField <= 0 && GameManager.towerPoint >= 20)
        {
            star = 3;
            starPanel1.SetActive(false);
            starPanel2.SetActive(false);
            starPanel3.SetActive(true);
        }
        else if(GameManager.monsterInField > 0 && GameManager.towerPoint >=20)
        {
            star = 2;
            starPanel1.SetActive(false);
            starPanel2.SetActive(true);
            starPanel3.SetActive(false);
        }
        else if (GameManager.monsterInField > 4 && GameManager.towerPoint<=10)
        {
            star = 1;
            starPanel1.SetActive(true);
            starPanel2.SetActive(false);
            starPanel3.SetActive(false);
        }
        else
        {
            star = 0;
            Debug.LogError("Fail");
        }
    }
    void SetEndPanel()
    {
        if (GameManager.timeIngame <= 0 && GameManager.towerPoint > 0)
        {
            winPanel.SetActive(true);
            resultStar();
            losePanel.SetActive(false);
            node.SetActive(false);
            GameManager.turretRemaining.SetActive(false);
            particleStorage.SetActive(false);
            barRemaining.SetActive(false);
            GameObject button = GameObject.FindGameObjectWithTag("SB");
            Destroy(button);
        }
        else if (GameManager.towerPoint <= 0)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
            node.SetActive(false);
            GameManager.turretRemaining.SetActive(false);
            particleStorage.SetActive(false);
            barRemaining.SetActive(false);
            GameObject button = GameObject.FindGameObjectWithTag("SB");
            Destroy(button);
        }
    }
    void CountBar()
    {
        bar = GameObject.FindGameObjectsWithTag("Bar");
       for (int i = 0; i < bar.Length; i++)
        {
            barRemaining = bar[i];
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
