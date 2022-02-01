using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    public GameObject dialogueBubble;
    public List<Recipes> listRecipes = new List<Recipes>();

    // Start is called before the first frame update
    void Start()
    {
        int rand=Random.Range(0, listRecipes.Count);
        Recipes actualRecipe = listRecipes[rand];
        foreach(GameObject ingredient in actualRecipe.ingredientRecipes)
        {
            GameObject burger = Instantiate(ingredient, new Vector3(-0.558f, 0.127f, 0), Quaternion.identity);
            burger.transform.SetParent(dialogueBubble.transform, false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
