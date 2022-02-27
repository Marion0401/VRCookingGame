using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareOrders : MonoBehaviour
{
    [SerializeField] OrderView Screen;
    [SerializeField] OrderView Plateau;
    Order screenOrder;
    Order plateauOrder;

    public bool areTheSame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateOrder()
    {
        screenOrder = Screen.order;
        plateauOrder = Plateau.order;


        areTheSame = screenOrder.CompareWithOrder(plateauOrder);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
