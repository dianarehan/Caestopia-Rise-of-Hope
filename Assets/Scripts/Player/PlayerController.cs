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

        if (horizontalInput > 0)
        {
            playerSprite.sprite = backSprite;
            PlayerRb.velocity = Vector3.right * playerSpeed * horizontalInput * Time.deltaTime;

        }
        else if (horizontalInput < 0)
        {
            playerSprite.sprite = frontSprite;
            PlayerRb.velocity = Vector3.right * playerSpeed * horizontalInput * Time.deltaTime;
        }
        else if (verticalInput > 0)
        {
            playerSprite.sprite = rightSprite;
            PlayerRb.velocity = Vector3.up * playerSpeed * verticalInput * Time.deltaTime;
        }
        else if (verticalInput < 0)
        {
            playerSprite.sprite = leftSprite;
            PlayerRb.velocity = Vector3.up * playerSpeed * verticalInput * Time.deltaTime;

        }
        else
            PlayerRb.velocity = Vector3.zero;

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
