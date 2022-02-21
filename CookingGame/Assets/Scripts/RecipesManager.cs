using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    public GameObject dialogueBubble;
    public List<Recipes> listHamburger = new List<Recipes>();
    public List<GameObject> listDrink = new List<GameObject>();
    public GameObject fries;
    //public float xPositionTopBread;
    //public float yPositionTopBread;
    



    // Start is called before the first frame update
    void Start()
    {
        
        // pour le burger
        int rand = Random.Range(0, listHamburger.Count);
        Recipes actualRecipe = listHamburger[rand];
        foreach (GameObject ingredient in actualRecipe.ingredientRecipes)
        {
            GameObject burger = Instantiate(ingredient, new Vector3(0,0, 0), Quaternion.identity);
            
            burger.transform.SetParent(dialogueBubble.transform, false);
            
        }

        // pour les frites

        // pour la boisson



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
