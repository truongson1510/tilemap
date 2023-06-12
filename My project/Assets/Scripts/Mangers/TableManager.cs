using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TableManager : MonoBehaviour
{
    public static TableManager Instance;
    [SerializeField] GameObject[] allIngredient;

    [SerializeField] List<FoodRecipe> recipes = new List<FoodRecipe>();

    [SerializeField] int            selectedFood;
    [SerializeField] int            selectedTime;

    [SerializeField] GameObject     foodtoShow;

    [SerializeField] GameObject     player;
    [SerializeField] GameObject     playerPoint;
    [SerializeField] Animator       playerAnimator;

    [SerializeField] GameObject     waiter;
    [SerializeField] GameObject     waiterPoint;
    [SerializeField] Animator       waiterAnimator;

    [SerializeField] GameObject     score;
    [SerializeField] Vector3        initialPos;
    [SerializeField] Vector3        waterInitialPos;


    [SerializeField] bool           playerReached = false;
    [SerializeField] bool           foodServed = false;

    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject timmer;
    [SerializeField] SpriteRenderer order;


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
        waterInitialPos = waiter.transform.position;

        InitializeTable();
    }

    void InitializeTable()
    {
        playerReached = false;
        foodServed = false;

        foodtoShow.SetActive(false);
        timmer.SetActive(false);

        player.transform.position = initialPos;
        waiter.transform.position = waterInitialPos;

        rand = Random.Range(0, 2);
        selectedFood = Random.Range(0, 4);
        if (rand == 0)
        {
            selectedTime = 30;
        }
        else
        {
            selectedTime = 60;
        }
        timeText.text = selectedTime.ToString();
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        playerAnimator.SetTrigger("Move");
        while (player.transform.position != playerPoint.transform.position)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerPoint.transform.position, 5 * Time.fixedDeltaTime);
            yield return new WaitForSeconds(0.01f);
        }

        playerReached = true;
        timmer.SetActive(true);

        playerAnimator.SetTrigger("Sit");

        if (order != null) { order.sprite = recipes[selectedFood].foodImage; }

        player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = recipes[selectedFood].foodImage;
        player.transform.GetChild(0).gameObject.SetActive(true);
        FoodManager.Instance.TurnOnButtons();
        StartCoroutine(timeRoutine());

        yield return new WaitForSeconds(2f);
        player.transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator timeRoutine()
    {
        while ((selectedTime > 0) && foodServed == false)
        {
            yield return new WaitForSeconds(1);

            selectedTime--;
            timeText.text = selectedTime.ToString();

            if (selectedTime < 3 && !foodServed && !lowPlayed)
            {
                AudioManager.Instance.PlayOneShot(Sound.timeLow);
                lowPlayed = true;
            }

            if ((selectedTime <= 0) && foodServed == false)
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
        if (playerReached == true)
        {
            if (recipes[selectedFood].ingredients[recipes[selectedFood].count].gameObject == gameObject)
            {
                recipes[selectedFood].count++;
                if (recipes[selectedFood].count == recipes[selectedFood].ingredients.Length)
                {
                    AudioManager.Instance.PlayOneShot(Sound.doneCooking);

                    playerReached = false;
                    foodServed = true;
                    StopAllCoroutines();
                    StartCoroutine(ResetTable());
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
        while (waiter.transform.position != waiterPoint.transform.position)
        {
            waiter.transform.position = Vector3.MoveTowards(waiter.transform.position, waiterPoint.transform.position, 5 * Time.fixedDeltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        foodtoShow.GetComponent<SpriteRenderer>().sprite = recipes[selectedFood].foodImage;
        foodtoShow.SetActive(true);
        recipes[selectedFood].count = 0;
        //score.SetActive(true);
        ScoreManager.Instance.IncreaseScore();
        player.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        //score.SetActive(false);
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