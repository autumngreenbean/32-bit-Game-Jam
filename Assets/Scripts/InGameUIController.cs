using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{

  // Set images below in the Inspector!
  Image health_image;

  Image stamina_image;

  public Sprite health_sprite_1;

  public Sprite health_sprite_2;

  public Sprite health_sprite_3;

  public Sprite stamina_sprite_1;

  public Sprite stamina_sprite_2;

  public Sprite stamina_sprite_3;

  void Start() {

      health_image = GetComponent<Image>();

      stamina_image = GetComponent<Image>();

      health_image.sprite = health_sprite_1;

      stamina_image.sprite = stamina_sprite_1;
  }

    public void updateHealth() {

      void OnCollisionEnter(Collision col) {

          if (col.gameObject.tag == "Urchin" & image.sprite = health_sprite_1) {

              image.sprite = health_sprite_2;
          }

          if (col.gameObject.tag == "Urchin" & image.sprite = health_sprite_2) {

              image.sprite = health_sprite_3;
          }
      }
  }

    // Function for stamina UI
    public void updateStamina() {

        if (Input.GetMouseButton(0)) {

          // Update .png images here!
          pass
        }
    }
}
