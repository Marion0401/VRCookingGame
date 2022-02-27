using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderView : MonoBehaviour
{
    RecipeDisplay display;
    PlateauToOrder plateau;
    public Order order;

    public bool hasDrink = false;
    public Ingredient drink = Ingredient.None;

    // Frites
    public bool hasFries = false;
    public Ingredient fries = Ingredient.None;

    // Plat Principal
    public MainCourse main = MainCourse.Burger;
    public List<Ingredient> mainIngredientList = new List<Ingredient>();

    public int numberOfItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<RecipeDisplay>();
        plateau = GetComponent<PlateauToOrder>();
    }

    // Update is called once per frame
    void Update()
    {
        if(display || plateau)
        {

            if (display) order = display.CurrentOrder;
            else order = plateau.currentOrder;


            hasDrink = order.hasDrink;
            drink = order.drink;

            hasFries = order.hasFries;
            fries = order.fries;

            main = order.main;
            mainIngredientList = order.mainIngredientList;

            numberOfItem = order.numberOfItem;
        }
    }
}
