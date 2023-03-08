using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DamageHandler : MonoBehaviour
{

    public GameObject explosionPrefab;
    
    public int hp = 3; //health points
    [SerializeField]
    private Sprite[] hearts;
    [SerializeField]
    private Image health;
    public float invulnerabilityPeriod = 0; //seconds
    float invulnerabilityState = 0; //state
    int defaultLayer;

    public bool givesScore = false;
    public int scoreAmount = 0;

    [SerializeField]
    private GameObject GameOverScreen;

    SpriteRenderer sprRend;

    void Start()
    {
        defaultLayer = gameObject.layer;
        sprRend = GetComponent<SpriteRenderer>();


        if(sprRend == null)
        {
            
            sprRend = transform.GetComponentInChildren<SpriteRenderer>();

            if(sprRend == null){

            Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }


    void OnTriggerEnter2D()
    {
        //Debug.Log("Trigger detected.");

        if(invulnerabilityState <= 0)
        {
            hp--;

            if(gameObject.layer == 8 || gameObject.layer == 10)
            {
                if (hearts.Length > 0)
                {
                    health.sprite = hearts[hp];
                }
            }

            invulnerabilityState = invulnerabilityPeriod; //provides tepmorary invul when the player receives damage.
            
            if(invulnerabilityPeriod != 0)
                gameObject.layer = 10; //10th layer is "Invulnerable" layer.
                
                
        }
    }

    void Update()
    {
        if (invulnerabilityState > 0)
        {
            invulnerabilityState -= Time.deltaTime;


            if (invulnerabilityState <= 0)
            {
                //--"BLINKING" SCRIPT--
                //make the player's sprite start "blinking" while they are in the invulnerabilty state.
                gameObject.layer = defaultLayer;

                if (sprRend != null)
                {
                    sprRend.enabled = true; //turns graphics back on
                }
            }
            else
            {
                if (sprRend != null)
                {
                    sprRend.enabled = !sprRend.enabled; //turns the player's graphics on and off in rapid succession until invuln period stops. 
                }
            }
        }

        if (hp <= 0)
        {


            if (gameObject.layer == 8 || gameObject.layer == 10)
            {
                GameObject playerExplosionGO = (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation); //spawn an explosion animation at object's death spot
                Die();

                //wait for 2 seconds 

                if (GameOverScreen != null)
                {

                    GameOverScreen.SetActive(GameOverScreen);
                }


                if (gameObject.tag == "PlayerBullet")
                {
                    
                    return;
                }

            }
            else if (gameObject.layer == 9) //if unit's layer is "Enemy"
            {
                if (givesScore == true)
                {
                    ScoreCounter.scoreValue += scoreAmount;   //add score  
                }

                GameObject EnemyExplosionGO = (GameObject)Instantiate(explosionPrefab, transform.position, transform.rotation);
                Die();
            }



        }
    }

    void Die()
    {
        
        Destroy(gameObject);
    }

    
}
