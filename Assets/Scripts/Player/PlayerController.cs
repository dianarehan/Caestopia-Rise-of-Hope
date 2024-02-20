using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Sprite backSprite;
    [SerializeField]
    private Sprite frontSprite;
    [SerializeField]
    private Sprite rightSprite;
    [SerializeField]
    private Sprite leftSprite;

    public float playerSpeed = 250f;
    private SpriteRenderer playerSprite;
    private Rigidbody2D PlayerRb;

    [SerializeField]
    private UIDocument interactionUi;
    private VisualElement intractionRoot;
    private Interaction playerInteraction;

    private Vector2 playerVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerSprite.sprite = frontSprite;
        
        PlayerRb = GetComponent<Rigidbody2D>();
        intractionRoot = interactionUi.rootVisualElement;
        intractionRoot.style.display = DisplayStyle.None;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInteraction != null)
        {
            intractionRoot.style.display = DisplayStyle.None;
            playerInteraction.StartInteraction();
            playerInteraction = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerVelocity.x = playerSpeed * horizontalInput * Time.deltaTime;
        playerVelocity.y = playerSpeed * verticalInput * Time.deltaTime;

        if (horizontalInput > 0)
        {
            playerSprite.sprite = backSprite;
        }
        if (horizontalInput < 0)
        {
            playerSprite.sprite = frontSprite;
        }
        if (verticalInput > 0)
        {
            playerSprite.sprite = rightSprite;
        }
        if (verticalInput < 0)
        {
            playerSprite.sprite = leftSprite;
        }
        if (horizontalInput == 0 && verticalInput == 0) 
        {
            playerVelocity = Vector2.zero;
        }
        PlayerRb.velocity = playerVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interation"))
        {
            intractionRoot.style.display = DisplayStyle.Flex;
            playerInteraction = collision.gameObject.GetComponent<Interaction>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interation"))
        {
            intractionRoot.style.display = DisplayStyle.None;
            playerInteraction = null;
        }
    }


}
