using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Button")]
    public Button Gun1;
    public Button Gun2;
    public Button Gun3;
    [Header("Text")]
    public Text Currency;
    public Text Time;
    
    void Start()
    {
        Gun1.onClick.AddListener(() => Shop.instance.PurchaseStandardTurrets());
        Gun2.onClick.AddListener(() => Shop.instance.PurchaseAnotherTurrets());
        Gun3.onClick.AddListener(() => Shop.instance.PurchaseSpecialTurrets());
    }
    void Update()
    {
        UpdateCurrency();
        Updatetime();
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
    

}
