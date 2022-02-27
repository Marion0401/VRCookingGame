using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class RecipeDisplay : MonoBehaviour
{
    public Order CurrentOrder = new Order();
    public int displayNumber = 0;
    public bool recipeDisplayed = false;

    public Transform positionFood;
    Vector3 initialPositionFood;
    [SerializeField] GameObject plusPrefab;
    [SerializeField] GameObject VerticalLayoutPrefab;
    [SerializeField] Image ScreenColor;
    
    [SerializeField] List<GameObject> listDrink = new List<GameObject>();
    
    
    
    public List<GameObject> entireOrderObjects = new List<GameObject>();



    // Start is called before the first frame update
    void Awake()
    {
        positionFood = GetComponentInChildren<HorizontalLayoutGroup>().transform;
        ScreenColor = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        ScreenColor.color = new Color(80/255, 80/255, 80/255);
    }


    public Order GenerateOrder()
    {
        print(displayNumber);
        Order newOrder = new Order();

        if (Random.Range(0,2) == 0) { newOrder.hasDrink = true; newOrder.drink = Ingredient.Drink; newOrder.numberOfItem++; }
     
        if (Random.Range(0,2) == 0) { newOrder.hasFries = true; newOrder.fries = Ingredient.Fries; newOrder.numberOfItem++; }


        // Cas où de multiples plats sont proposés
        int mainCourseChoice = Random.Range(0, 1);
        switch (mainCourseChoice)
        {
            case 0:
                newOrder.numberOfItem++;
                newOrder.main = MainCourse.Burger;
                newOrder.mainIngredientList = newOrder.GenerateRandomBurger();
                break;
        }

        return newOrder;
    }

    public void StartDIsplay()
    {
        ScreenColor.color = new Color(1, 1, 1);
        recipeDisplayed = true;
        CurrentOrder = GenerateOrder();

        if(CurrentOrder.hasFries)
        {
            // pour les frites
            GameObject fries = Instantiate(IngredientToPrefab.instance.Fries, new Vector3(0, 0, 0), Quaternion.identity);
            fries.transform.SetParent(positionFood, false);
            entireOrderObjects.Add(fries);

            // Plus
            GameObject plus1 = Instantiate(plusPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            plus1.transform.SetParent(positionFood, false);
            entireOrderObjects.Add(plus1);
        }


        // pour le burger
        GameObject burgerLayout = Instantiate(VerticalLayoutPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        foreach (Ingredient ingr in CurrentOrder.mainIngredientList)
        {
            GameObject ingredient = null;
            switch (ingr)
            {

                case Ingredient.BottomBread:
                    ingredient = IngredientToPrefab.instance.BottomBread;
                    break;

                case Ingredient.TopBread:
                    ingredient = IngredientToPrefab.instance.TopBread;
                    break;

                case Ingredient.Salad:
                    ingredient = IngredientToPrefab.instance.Salad;
                    break;

                case Ingredient.Tomato:
                    ingredient = IngredientToPrefab.instance.Tomato;
                    break;

                case Ingredient.Steak:
                    ingredient = IngredientToPrefab.instance.Steak;
                    break;

                case Ingredient.HotDogBread:
                    ingredient = IngredientToPrefab.instance.HotDogBread;
                    break;

                case Ingredient.Sausage:
                    ingredient = IngredientToPrefab.instance.Sausage;
                    break;

            }
            GameObject burger = Instantiate(ingredient, new Vector3(0, 1f, 0), Quaternion.identity);
            burger.transform.SetParent(burgerLayout.transform, false);
            entireOrderObjects.Add(burger);
            
            //burger.transform.SetParent(positionIngredientBurger.transform, false);
        }
        entireOrderObjects.Add(burgerLayout);
        burgerLayout.transform.Rotate(0, 0, 0);

        burgerLayout.transform.SetParent(positionFood.transform, false);


        if(CurrentOrder.hasDrink)
        {
            // Plus
            GameObject plus2 = Instantiate(plusPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            plus2.transform.SetParent(positionFood, false);
            entireOrderObjects.Add(plus2);

            // pour la boisson
            int rand2 = Random.Range(0, listDrink.Count);
            GameObject drink = Instantiate(listDrink[rand2], new Vector3(0, 0, 0), Quaternion.identity);
            drink.transform.SetParent(positionFood, false);
            entireOrderObjects.Add(drink);
        }
        

    }

    public void ExitDisplay()
    {
        ScreenColor.color = new Color(80 / 255, 80 / 255, 80 / 255);

        recipeDisplayed = false;
        foreach (GameObject item in entireOrderObjects) Destroy(item);
        entireOrderObjects = new List<GameObject>();

        positionFood.transform.DetachChildren();
    }

    void Update()
    {

    }
}









public enum Ingredient
{
    None,
    BottomBread,
    Salad,
    Tomato,
    Steak,
    Cheese,
    TopBread,
    HotDogBread,
    Sausage,
    Fries,
    Drink
}

public enum MainCourse
{
    None,
    Burger,
    HotDog
}

public class Order
{
    // Boissons
    public bool hasDrink = false;
    public Ingredient drink = Ingredient.None;

    // Frites
    public bool hasFries = false;
    public Ingredient fries = Ingredient.None;

    // Plat Principal
    public MainCourse main = MainCourse.Burger;
    public List<Ingredient> mainIngredientList = new List<Ingredient>();

    public int numberOfItem = 0;

    public List<Ingredient> GenerateRandomBurger()
    {

        List<Ingredient> newBurger = new List<Ingredient>();

        List<Ingredient> notBread = new List<Ingredient>() { Ingredient.Salad, Ingredient.Tomato, Ingredient.Steak };
        int numberOfIngredients = Random.Range(1, 4);

        newBurger.Add(Ingredient.TopBread);

        for (int i = 0; i < numberOfIngredients; i++)
        {
            int ingr = Random.Range(0, notBread.Count);
            newBurger.Add(notBread[ingr]);
        }

        newBurger.Add(Ingredient.BottomBread);

        return newBurger;
    }

    public List<Ingredient> GenerateHotdog()
    {
        List<Ingredient> newHotDog = new List<Ingredient>() { Ingredient.HotDogBread, Ingredient.Sausage };
        return newHotDog;
    }

    public bool CompareWithOrder(Order other)
    {
        bool output = true;

        if (hasDrink != other.hasDrink || drink != other.drink || hasFries != other.hasFries || fries != other.fries || main != other.main) output = false;

        if (mainIngredientList.Count != other.mainIngredientList.Count) output = false;
        else
        {
            for (int i = 0; i< mainIngredientList.Count; i++)
            {
                if (mainIngredientList[i] != other.mainIngredientList[i]) output = false;
            }
        }

        return output;
    }

}
