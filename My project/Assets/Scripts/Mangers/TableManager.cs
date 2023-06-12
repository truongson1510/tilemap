using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableManager : MonoBehaviour
{
    public static TableManager Instance;

    [SerializeField] GameObject[]       allIngredient;
    [SerializeField] List<FoodRecipe>   recipes = new();

    [SerializeField] int                selectedFood;
    [SerializeField] int                selectedTime;

    [SerializeField] GameObject         foodtoShow;
    [SerializeField] GameObject         player;
    [SerializeField] GameObject         playerPoint;
    [SerializeField] Animator           playerAnimator;

    [SerializeField] Vector3            initialPos;

    [SerializeField] bool               playerReached = false;
    [SerializeField] bool               foodServed = false;

    [SerializeField] TMP_Text           timeText;
    [SerializeField] GameObject         timmer;
    [SerializeField] SpriteRenderer     order;

    int rand = 0;
    bool lowPlayed;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPos = player.transform.position;
        InitializeTable();
    }

    void InitializeTable()
    {
        lowPlayed       = false;
        playerReached   = false;
        foodServed      = false;

        foodtoShow.SetActive(false);
        timmer.SetActive(false);

        player.transform.position = initialPos;

        rand            = Random.Range(0, 2);
        selectedFood    = Random.Range(0, 4);

        if (rand==0)
        { selectedTime = 30; }
        else
        { selectedTime = 60; }

        timeText.text=selectedTime.ToString();
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        playerAnimator.SetTrigger("Move");

        while (player.transform.position!=playerPoint.transform.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerPoint.transform.position, 5 * Time.fixedDeltaTime);
            yield return new WaitForSeconds(0.01f);
        }

        playerReached = true;
        timmer.SetActive(true);

        playerAnimator.SetTrigger("Sit");

        if (order != null) { order.sprite = recipes[selectedFood].foodImage; }
        
        player.transform.GetChild(0).gameObject.SetActive(true);

        FoodManager.Instance.TurnOnButtons();
        StartCoroutine(timeRoutine());
        yield return new WaitForSeconds(2f);
        player.transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator timeRoutine()
    {
        while ((selectedTime>0) && !foodServed)
        {
            yield return new WaitForSeconds(1);

            selectedTime--;
            timeText.text = selectedTime.ToString();

            if(selectedTime < 3 && !foodServed && !lowPlayed)
            {
                AudioManager.Instance.PlayOneShot(Sound.timeLow);
                lowPlayed = true;
            }

            if ((selectedTime<=0)&& !foodServed)
            {
                AudioManager.Instance.PlayOneShot(Sound.failToServe);

                StopAllCoroutines();
                LiveManager.instance.DecreaseLive();
                InitializeTable();
            }    
        }
    }
    public void CheckFood(GameObject gameObject)
    {
        if (playerReached)
        {
            if (recipes[selectedFood].ingredients[recipes[selectedFood].count].gameObject == gameObject)
            {
                recipes[selectedFood].count++;
                if (recipes[selectedFood].count == recipes[selectedFood].ingredients.Length)
                {
                    foodServed = true;

                    AudioManager.Instance.PlayOneShot(Sound.doneCooking);

                    foodtoShow.GetComponent<SpriteRenderer>().sprite = recipes[selectedFood].foodImage;
                    foodtoShow.SetActive(true);
                    playerReached = false;
                    StopAllCoroutines();
                    StartCoroutine(ResetTable());
                    recipes[selectedFood].count = 0;
                    ScoreManager.Instance.IncreaseScore();
                }
            }
            else
            {
                recipes[selectedFood].count = 0;
            }
        }
    }

    IEnumerator ResetTable()
    {
        yield return new WaitForSeconds(3);
        InitializeTable();
    }
}

[System.Serializable]
public class FoodRecipe
{
    public GameObject[] ingredients;
    public int count = 0;
    public Sprite foodImage;
}