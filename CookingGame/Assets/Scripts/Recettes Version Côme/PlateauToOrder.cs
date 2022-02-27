using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauToOrder : MonoBehaviour
{
    public Order currentOrder = new Order();
    IngredientOnPlateau Plateau;
    // Start is called before the first frame update
    void Start()
    {
        Plateau = GetComponent<IngredientOnPlateau>();
    }

    public void UpdateOrder()
    {
        currentOrder.main = MainCourse.Burger;

        if (Plateau.frieIngredient == EnumIngredient.None) 
        {
            currentOrder.hasFries = false;
            currentOrder.fries = Ingredient.None;
        }
        else
        {
            currentOrder.hasFries = true;
            currentOrder.fries = Ingredient.Fries;
        }

        if (Plateau.sodaIngredient == EnumIngredient.None)
        {
            currentOrder.hasDrink = false;
            currentOrder.drink = Ingredient.None;
        }
        else
        {
            currentOrder.hasDrink = true;
            currentOrder.drink = Ingredient.Drink;
        }

        currentOrder.mainIngredientList = new List<Ingredient>();
        for (int i = Plateau.burgerIngredient.Count-1; i>=0; i--)
        {
            switch (Plateau.burgerIngredient[i])
            {

                case EnumIngredient.Pain:
                    if(currentOrder.mainIngredientList.Count ==0) { currentOrder.mainIngredientList.Add(Ingredient.BottomBread); }
                    else { currentOrder.mainIngredientList.Add(Ingredient.TopBread); }
                    break;

                case EnumIngredient.Salade:
                    currentOrder.mainIngredientList.Add(Ingredient.Salad);
                    break;

                case EnumIngredient.Tomate:
                    currentOrder.mainIngredientList.Add(Ingredient.Tomato);
                    break;

                case EnumIngredient.Steak:
                    currentOrder.mainIngredientList.Add(Ingredient.Steak);
                    break;

                case EnumIngredient.Fromage:
                    currentOrder.mainIngredientList.Add(Ingredient.Cheese);
                    break;

            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
