Added jump and roll animations.

This is the code part for jump and roll.

void Jump()
    {

        if (MovementT == MovementType.Directional && Input.GetKeyDown(KeyCode.Space))//Normal yani directional hareket modundayken ise ziplayabiliyoruz. Fakat roll atamiyoruz.
        {
            Anim.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce); //Bug oldugu icin simdilik ForceMode eklemedim.
            Debug.Log("jumped");
        }
        else if (MovementT == MovementType.Strafe && Input.GetKeyDown(KeyCode.Space))// Strafe hareket modundaysak yani elimizde silah varken ziplayamiyoruz. Sadece roll atabiliyoruz.
        {
            Anim.SetTrigger("Roll");
            Debug.Log("roll");
        }
        

        
    }