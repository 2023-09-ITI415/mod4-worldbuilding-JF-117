using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickupController : MonoBehaviour
{

    public Text countText;
    public Text winText;
    public AudioSource pickupSound;
    public AudioSource carSound;
    public Image winScreen;

    private Rigidbody rb;
    private int count;

    float timer = 0;
    bool timerReached = false;

        void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            countText.gameObject.SetActive (true);
        }
        if (timerReached && timer < 9)
        {
            timer += Time.deltaTime;
        }
        else if (timerReached && timer >= 9)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
        void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            pickupSound.Play();
            SetCountText();
        }

        if(other.gameObject.CompareTag("Goal"))
        {
             if (count >= 6)
        {
            timerReached = true;
            winScreen.gameObject.SetActive(true);
            carSound.Play();

        }
        }
    
    }

    void SetCountText()
    {
        countText.text = "Items: " + count.ToString ();
        if (count >= 6)
        {
            winText.text = "I should head back to my car.";
        }

    }
}
