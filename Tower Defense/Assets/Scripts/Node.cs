using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color colorHover;
    public Vector3 positionOffset;
    public GameObject storage;

    private Renderer rend;
    private Color startColor;
    private GameObject turrets;
    private int price;
    void Start()
    {
        storage = GameObject.FindGameObjectWithTag("Storage");
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void Update()
    {
        price = BuildManager.instance.GetPaymentTurrets();
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        GameObject turretsToBuild = BuildManager.instance.GetTurrentsToBuild();
        if(GameManager.currency < price)
        {
            Debug.LogError("Not Enough Money!!");
        }
        else if (turrets != null)
        {
            Debug.LogError("Can't Build in this Place");
        }
        else
        {
            turrets = Instantiate(turretsToBuild, transform.position + positionOffset, transform.rotation);
            turrets.transform.SetParent(storage.transform);
            GetPayment();
        }
    }
    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(BuildManager.instance.GetTurrentsToBuild() == null)
        {
            return;
        }
        rend.material.color = colorHover;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    void GetPayment()
    {
        GameManager.currency -= price;
        if(GameManager.currency < 0)
        {
            GameManager.currency = 0;
        }
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
}
