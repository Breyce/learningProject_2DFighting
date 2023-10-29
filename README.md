# learningProject_2DFighting

For my second Unity project, I also followed an online tutorial. This time, I'm working on a 2D platformer game. Since I have a game concept in mind that shares a similar game mechanic in the future, I want to build up my technical skills now. After completing the small project of Plants vs. Zombies, I have a basic understanding of Unity, so this tutorial didn't prove to be too challenging on my first day of development. Given the daily academic pressures, I only allocate a portion of my time each day to work on these projects – there's also the need to study for my thesis, graphics, and machine learning-related subjects.

## Development Day 1: 2023.10.18

I have to say, a good tutorial is indeed crucial. When the instructor's approach is clear, their code is well-structured, and their knowledge of Unity is deep, the quality of their teaching is exceptionally high. This time, the instructor has made me feel comfortable and provided clear guidance compared to the instructor from the first tutorial. I have learned a lot from following this instructor and taken plenty of notes. Here are some of the specific topics I covered (excluding detailed content):

1. I learned about the relevant parameters and functions of **Rigidbody** in Unity, as well as the differences between Box Collider and Capsule Collider. I also learned why Capsule Collider is often preferred.
1. I learned how to access and manipulate objects in Unity's engine through code. Previously, I only knew that I could search for objects within the game entities, but today I learned that I can directly assign the relevant entities by dragging and dropping them into the public variables in the corresponding script. Of course, I still prefer the flexibility and versatility of accessing entities through code because it's not limited to public variables. However, this operation has given me a clearer understanding of Unity's engine workflow.
1. I learned that in Unity, you can directly access key information by using the name associated with a bound key. For example, if the "space" key is bound to "Jump," you can use `GetButtonDown("Jump")` to check whether the space key is pressed. This significantly improves development efficiency. You can find the specific configuration in the corresponding options within the Project Manager.
1. I also learned about the significance of layers in Unity. We added a new layer, and these layers have a specific rendering order, starting from layer 0, with each new layer placed above all the previous layers. This mechanism helps us efficiently manage the development order of 2D games without having to worry about adjusting the entire layer order when adding new entities.



## Development Day 2: 2023.10.19

Today, I accomplished character movement and implemented a simple camera follow feature, which also involved background movement. The work I completed was quite extensive. In the process, I also learned a lot about how to operate and understand the principles of the Animator. Some of the newer points I learned include:

1. Creating sprite animations involves first slicing the sprite sheets and then adding the individual frames of the sliced sprites into an Animation.

2. In the Animator, there's a "Flip" option that allows you to horizontally or vertically flip 2D sprite animations. To do this, you need to first access the sprite rendering component, **SpriteRenderer**, and then use its flip functionality. The component also offers other features that are worth exploring in more detail.

   Accessing Components: 

   ```c#
   theSR = GetComponent<SpriteRenderer>();
   ```

   To invoke the sprite flipping functionality:

   ```C#
   if(theRB.velocity.x < 0) 
   {
       theSR.flipX = true;
   } else if (theRB.velocity.x > 0)
   {
       theSR.flipX = false;
   }
   ```

3. The method used to create a convincing parallax scrolling effect for the background is quite clever yet simple. It involves moving different layers of the background at different, but coordinated speeds. The tutorial provided detailed instructions for this. For instance, objects in the far distance move the same distance as the character, while closer elements move at a slower pace, perhaps at 0.5 times the character's speed. You can further consider how to handle this if you have a very large and long map because creating an extremely long and repetitive background is not the most efficient use of time and resources.

   Here is some of the code:

   ```c#
   float amountToMoveX = transform.position.x - lastXPos;
   farBackground.position = farBackground.position + new Vector3(amountToMoveX,0f,0f);
   middleBackground.position += new Vector3(amountToMoveX * 0.5f, 0f, 0f);
   
   lastXPos = transform.position.x;
   ```

4. I also used a physicsMaterial2D to eliminate friction, preventing the character from sticking to the environment. Additionally, by selecting "Collision Detection" as "Continuous," I implemented a feature that calculates whether objects will collide before the collision occurs, allowing them to stop before entering each other.

## Development Day 3: 2023.10.26

Today, I learned a few new things. One of them is how to use sprite sheets to create 2D maps, which will be very useful in future development. I even drew my first map, and it feels great. Secondly, I studied some aspects of camera following in 2D games and gained insights into the principles of implementing various mechanisms, including invincibility frames.



## Development Day 4: 2023.10.28

Today I sat in front of the computer all day and got more and more addicted. By now, I feel like I have a general idea of the content of Unity, but I’m more interested in how the teacher thinks about all the mechanisms and expressions, and how to make the game more detailed. However, I still learned a lot today. I learned how to create item pickups and how to convert special effects. After careful consideration, I found that when implementing an animation that only plays once, one way is to destroy the object after a certain amount of time, and fix the animation execution time to a certain period. Then, before the animation finishes playing and enters the next round of looping, you can destroy the game entity used by the animation.

Another knowledge is to put several sprite maps in a game entity, which can make it easier to operate jumping or three-dimensional moving game characters.



## Development Day 5: 2023.10.29

Today is the fifth day of development, and the sound effects part of the game has been completed. Starting tomorrow, we will begin to create some game panels. The tutorial is really well taught. The knowledge points learned today are listed below:

1. Animation curves in Animator

2. Adding restrictions in code

   ```C#
       [Range(0,100)] public float chanceToDrop; //[Range(0,100)] restricts the value of chanceToDrop to be between 0-100
   ```

3. Unity3D sound controls

   1. Sound play and stop
   2. Sound adjustment: pitch
   3. AudioMixer
