using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompareOrders : MonoBehaviour
{
    [SerializeField] OrderView Screen;
    [SerializeField] OrderView Plateau;

    public bool areTheSame = false;
    [SerializeField] bool DebugForceValidate = false;

    float counter = 0;

    public bool manualTestValues = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateOrder();
    }

    public void UpdateOrder()
    {
        if (Plateau.order.mainIngredientList.Count >=0)
        {
            bool same = CompareWithOrder(Screen, Plateau);

            if (same && !areTheSame)
            {
                OrderIsValid();
            }

            areTheSame = same;
        }

    }

    void OrderIsValid()
    {
        //Debug.LogWarning("Valid");
        int displayNumber = Screen.GetComponent<RecipeDisplay>().displayNumber;

        QueueManager.instance.ClientExit(displayNumber + 1);
        Plateau.GetComponent<IngredientOnPlateau>().ResetPlateau();
    }

    // Update is called once per frame
    void Update()
    {
        if (DebugForceValidate)
        {
            DebugForceValidate = false;
            OrderIsValid();

        }

        if (manualTestValues)
        {
            TestValues(Screen, Plateau);
            manualTestValues = false;
        }

        counter += Time.deltaTime;
        if (counter>=0.1f) { UpdateOrder(); }
        
    }

    void TestValues(OrderView order, OrderView other)
    {
        bool output = true;

        if (order.hasDrink != other.hasDrink) 
        { 
            output = false; 
        }
        Debug.LogWarning("has Drink : " + order.hasDrink.ToString() + " and " + other.hasDrink.ToString() + ", output now at " + output.ToString());

        if (order.drink != other.drink) 
        { 
            output = false; 
        }
        Debug.LogWarning("drink : " + order.drink.ToString() + " and " + other.drink.ToString() + ", output now at " + output.ToString());

        if (order.hasFries != other.hasFries) 
        { 
            output = false;
        }
        Debug.LogWarning("has Fries : " + order.hasFries.ToString() + " and " + other.hasFries.ToString() + ", output now at " + output.ToString());

        if (order.fries != other.fries) 
        { 
            output = false;
        }
        Debug.LogWarning("fries : " + order.fries.ToString() + " and " + other.fries.ToString() + ", output now at " + output.ToString());

        if (order.main != other.main) 
        { 
            output = false;
        }
        Debug.LogWarning("main : " + order.main.ToString() + " and " + other.main.ToString() + ", output now at " + output.ToString());

        if (order.numberOfItem != other.numberOfItem) 
        { 
            output = false;
            Debug.LogWarning("number of Item : " + order.numberOfItem.ToString() + " and " + other.numberOfItem.ToString() + ", output now at " + output.ToString());
        }
        Debug.LogWarning("number of Item : " + order.numberOfItem.ToString() + " and " + other.numberOfItem.ToString() + ", output now at " + output.ToString());

        if (order.mainIngredientList.Count != other.mainIngredientList.Count) 
        { 
            output = false; 
            Debug.LogWarning("Main Ingredient List Length : " + order.mainIngredientList.Count.ToString() + " and " + other.mainIngredientList.Count.ToString() + ", output now at " + output.ToString()); 
        }
        else
        {
            Debug.LogWarning("Main Ingredient List Length : " + order.mainIngredientList.Count.ToString() + " and " + other.mainIngredientList.Count.ToString() + ", output now at " + output.ToString());
            for (int i = 0; i < order.mainIngredientList.Count; i++)
            {
                if (order.mainIngredientList[i] != other.mainIngredientList[i])
                {
                    output = false;
                }
                Debug.LogWarning("Main Ingredient List " + i.ToString() + " : " + order.mainIngredientList[i].ToString() + " and " + other.mainIngredientList[i].ToString() + ", output now at " + output.ToString());
            }
        }
    }

    public bool CompareWithOrder(OrderView order, OrderView other)
    {
        bool output = true;

        if (order.hasDrink != other.hasDrink) { output = false; }
        if (order.drink != other.drink) { output = false; }
        if (order.hasFries != other.hasFries) { output = false; }
        if (order.fries != other.fries) { output = false; }
        if (order.main != other.main) { output = false; }
        if (order.numberOfItem != other.numberOfItem) { output = false; }
        if (order.mainIngredientList.Count != other.mainIngredientList.Count) { output = false; }
        else
        {
            for (int i = 0; i < order.mainIngredientList.Count; i++)
            {
                if (order.mainIngredientList[i] != other.mainIngredientList[i])
                {
                    output = false;
                }
            }
        }

        return output;
    }
}
